using Candidates.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Core.Contracts
{
    public interface ICandidateCore
    {
        CoreResponseModel<object> UpsertCandidate(UpsertCandidateModel upsertCandidateModel);
    }
}
