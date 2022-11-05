using Candidates.Core.Contracts;
using Candidates.Dal.contracts;
using Candidates.Models;
using System;

namespace Candidates.Core
{
    public class CandidateCore : ICandidateCore
    {
        private readonly ICandidateDal _candidateDal;

        public CandidateCore(ICandidateDal candidateDal)
        {
            _candidateDal = candidateDal;
        }
        public CoreResponseModel<object> UpsertCandidate(UpsertCandidateModel upsertCandidateModel)
        {
            var candidate=_candidateDal.UpsertCandidate(upsertCandidateModel);
            throw new NotImplementedException();
        }
    }
}
