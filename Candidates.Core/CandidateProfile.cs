using AutoMapper;
using Candidates.Entities;
using Candidates.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Core
{
    public class CandidateProfile:Profile
    {
        public CandidateProfile()
        {
            CreateMap<Candidate, UpsertCandidateModel>().ReverseMap();
        }
    }
}
