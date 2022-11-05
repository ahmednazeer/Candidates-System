using Candidates.Core.Contracts;
using Candidates.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Candidates.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateCore _candidateCore;

        public CandidateController(ICandidateCore candidateCore)
        {
            _candidateCore = candidateCore;
        }

        [HttpPut]
        public async Task<IActionResult> UpsertCandidate([FromBody] UpsertCandidateModel upsertCandidateModel)
        {
            _candidateCore.UpsertCandidate(upsertCandidateModel);
            return Ok();
        }

    }
}
