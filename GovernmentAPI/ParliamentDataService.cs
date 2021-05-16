using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using ParliamentApp.GovernmentAPI.Models;
using ParliamentApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ParliamentApp.GovernmentAPI
{
    /// <summary>
    /// Service to load data from canada's parliament api
    /// </summary>
    public class ParliamentDataService : IParliamentDataService
    {
        private readonly IHttpWrapper _http;
        private readonly ILogger<ParliamentDataService> _logger;

        public ParliamentDataService(IHttpWrapper http, ILogger<ParliamentDataService> logger)
        {
            _http = http;
            _logger = logger;
        }

        public async Task<IEnumerable<GovernmentVote>> LoadVotesAsync(int parliamentNumber, int sessionNumber)
        {
            var session = $"{parliamentNumber}-{sessionNumber}";
            try
            {
                var voteData = await _http.GetXMLDataAsync<ArrayOfVote>($"https://www.ourcommons.ca/Members/en/Votes/XML?parlSession={session}&output=XML");
                return voteData.Votes;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Failed to fetch votes from ourcommons using session {session}");
                throw;
            }
        }

        public async Task<IEnumerable<GovernmentMemberVote>> LoadMemberVotesAsync(int parliamentNumber, int sessionNumber, int decisionDivisionNumber)
        {
            try
            {
                var voteItems = await _http.GetXMLDataAsync<ArrayOfVoteParticipant>($"https://www.ourcommons.ca/Members/en/Votes/{parliamentNumber}/{sessionNumber}/{decisionDivisionNumber}/xml");
                return voteItems.Participants;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Failed to load member votes for parliament={parliamentNumber} session={sessionNumber} decisionDivisionNumber={decisionDivisionNumber}");
                throw;
            }
        }

        public async Task<IEnumerable<GovernmentMemberOfParliament>> LoadMembersOfParliamentAsync(int parliamentNumber)
        {
            try
            {
                var data = await _http.GetXMLDataAsync<ArrayOfMemberOfParliament>($"https://www.ourcommons.ca/Members/en/search/xml?parliament={parliamentNumber}&caucusId=all&province=all&gender=all");
                // the xml data does not include their personId (which is used to link them to other areas, like member votes)
                // but the data is included in the raw html
                HtmlWeb browser = new();
                HtmlDocument pageContents = await browser.LoadFromWebAsync($"https://www.ourcommons.ca/members/en/search?parliament={parliamentNumber}&caucusId=all&province=all&gender=all");
                HtmlNodeCollection politicianCards = pageContents.DocumentNode.SelectNodes("//div[contains(@class, \"ce-mip-mp-tile-container \")]");
                foreach (var member in data.MemberOfParliament)
                {
                    // At this time, it's a reasonable assumption that this is unique (first + last + constituency)
                    var politicianCardForMember = politicianCards.SingleOrDefault(n =>
                                                           {
                                                               // need to decode special symbols
                                                               var content = HttpUtility.HtmlDecode(n.InnerText);
                                                               return content.Contains(member.PersonOfficialFirstName) && 
                                                                      content.Contains(member.PersonOfficialLastName) && 
                                                                      content.Contains(member.ConstituencyName);
                                                           });
                    if (politicianCardForMember == null)
                    {
                        _logger.LogError("Politican parsing failed", member);
                        throw new ArgumentException($"Invalid Member - {member.PersonOfficialFirstName} {member.PersonOfficialLastName}");
                    }
                    // the format of the id is mp-tile-person-id-XXXXXX
                    member.PersonId = int.Parse(politicianCardForMember.Id.Split('-').Last());
                }
                return data.MemberOfParliament;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Failed to load members for parliament {parliamentNumber}");
                throw;
            }
        }
    }
}
