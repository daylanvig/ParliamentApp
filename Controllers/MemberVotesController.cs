using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParliamentApp.Infrastructure;
using ParliamentApp.Infrastructure.Data;
using ParliamentApp.Infrastructure.QueryEvaluators;
using ParliamentApp.Models;
using ParliamentApp.Models.APIParameters;
using ParliamentApp.Models.Common;
using ParliamentApp.Utility;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ParliamentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberVotesController : ControllerBase
    {
        private readonly IReadOnlyRepository<MemberVote> _memberVotesRepository;
        private readonly IMemberVotesResourceParameterQueryEvaluator _queryEvaluator;

        public MemberVotesController(
            IReadOnlyRepository<MemberVote> memberVotesRepository,
            IMemberVotesResourceParameterQueryEvaluator queryEvaluator)
        {
            _memberVotesRepository = memberVotesRepository;
            _queryEvaluator = queryEvaluator;
        }

        // GET api/<MemberVotesController>
        [HttpGet]
        public Task<Pagination<MemberVote>> ListOfMemberVotesAsync([FromQuery] MemberVoteResourceParameters pagedListParameters)
        {
            return _memberVotesRepository.ListAsync(pagedListParameters, _queryEvaluator);
        }

        // GET api/<MemberVotesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<MemberVote>> GetByIdAsync(int id)
        {
            return ControllerUtilities.GetByIdAsync(_memberVotesRepository, id);
        }

    }
}
