using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParliamentApp.Infrastructure.Data;
using ParliamentApp.Infrastructure.QueryEvaluators;
using ParliamentApp.Models;
using ParliamentApp.Models.APIParameters;
using ParliamentApp.Models.Common;
using ParliamentApp.Utility;
using System.Threading.Tasks;

namespace ParliamentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersOfParliamentController : ControllerBase
    {
        private readonly IReadOnlyRepository<MemberOfParliament> _membersOfParliamentRepository;
        private readonly IMembersOfParliamentResourceParameterQueryEvaluator _queryEvaluator;

        public MembersOfParliamentController(IReadOnlyRepository<MemberOfParliament> membersOfParliamentRepository, IMembersOfParliamentResourceParameterQueryEvaluator queryEvaluator)
        {
            _membersOfParliamentRepository = membersOfParliamentRepository;
            _queryEvaluator = queryEvaluator;
        }

        // GET api/<MemberOfParliamentsController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<ActionResult<MemberOfParliament>> GetMemberOfParliamentByIdAsync(int id)
        {
            return ControllerUtilities.GetByIdAsync(_membersOfParliamentRepository, id);
        }

        // GET api/<MembersOfParliamentController>
        [HttpGet]
        public Task<Pagination<MemberOfParliament>> ListMembersOfParliamentAsync([FromQuery] MembersOfParliamentResourceParameters pagedListParameters)
        {
            return _membersOfParliamentRepository.ListAsync(pagedListParameters, _queryEvaluator);
        }


    }
}
