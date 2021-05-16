using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParliamentApp.Infrastructure.Data;
using ParliamentApp.Models;
using ParliamentApp.Models.Common;
using ParliamentApp.Models.Entities;
using ParliamentApp.Services;
using ParliamentApp.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParliamentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ResponseCache(CacheProfileName = "Default")]
    public class VotesController : ControllerBase
    {
        private readonly IReadOnlyRepository<Vote> _voteRepository;

        public VotesController(IReadOnlyRepository<Vote> voteRepository, IGovernmentDataProcessingService service, IRepository<ParliamentPeriod> parliamentPeriodRepository)
        {
            _voteRepository = voteRepository;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<Vote>> GetVoteByIdAsync(int id)
        {
            return ControllerUtilities.GetByIdAsync(_voteRepository, id);
        }

        // TODO: this needs a VotesResourceListParameters to allow for specific filtering
        [HttpGet]
        public async Task<Pagination<Vote>> ListVotesAsync([FromQuery] PagedListParameters listParameters)
        {
            return await _voteRepository.ListAsync(listParameters);
        }
    }
}

