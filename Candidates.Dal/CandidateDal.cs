using Candidates.Dal.contracts;
using Candidates.Data.contracts;
using Candidates.Entities;
using Candidates.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Candidates.Dal
{
    public class CandidateDal : ICandidateDal
    {
        private readonly ICandidatesContext<Candidate> _candidatesContext;

        public CandidateDal(ICandidatesContext<Candidate> candidatesContext)
        {
            _candidatesContext = candidatesContext;
        }
        public async  Task<CoreResponseModel<Candidate>> UpsertCandidate(UpsertCandidateModel upsertCandidateModel)
        {
            var candidate = await _candidatesContext.Candidate.FirstOrDefaultAsync(ca => ca.Email == upsertCandidateModel.Email);
            if (candidate == null)
                //return _candidatesContext.Insert();
                return null;

            throw new NotImplementedException();
        }
    }
}
