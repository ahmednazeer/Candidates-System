using Candidates.Entities;
using Candidates.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Candidates.Dal.contracts
{
    public interface ICandidateDal
    {
        Task<CoreResponseModel<object>> UpsertCandidate(UpsertCandidateModel upsertCandidateModel);
    }
}
