using Candidates.Core.Contracts;
using Candidates.Helpers.filters;
using Candidates.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Candidates.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ApiBaseController
    {
        private readonly ICandidateCore _candidateCore;

        public CandidateController(ICandidateCore candidateCore)
        {
            _candidateCore = candidateCore;
        }
        
        [HttpPut]        
        public async Task<IActionResult> UpsertCandidate([FromBody] UpsertCandidateModel upsertCandidateModel)
        {
            
            return GetActionResultByModel( await _candidateCore.UpsertCandidate(upsertCandidateModel));
        }

    }
}
