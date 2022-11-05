using Candidates.Core.Contracts;
using Candidates.Dal.contracts;
using Candidates.Entities;
using Candidates.Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Candidates.Core
{
    public class CandidateCore : ICandidateCore
    {
        private readonly ICandidateDal _candidateDal;

        public CandidateCore(ICandidateDal candidateDal)
        {
            _candidateDal = candidateDal;
        }
        public async Task< CoreResponseModel<object>> UpsertCandidate(UpsertCandidateModel upsertCandidateModel)
        {
            if(upsertCandidateModel.IsValid())
                return await _candidateDal.UpsertCandidate(upsertCandidateModel);
            else
                return new CoreResponseModel<object> ( null,  System.Net.HttpStatusCode.BadRequest );
            
        }
    }
}
