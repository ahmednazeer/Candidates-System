using AutoMapper;
using Candidates.Dal.contracts;
using Candidates.Data;
using Candidates.Data.contracts;
using Candidates.Entities;
using Candidates.Helpers;
using Candidates.Models;
using CsvHelper.Configuration.Attributes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Candidates.Dal
{
    public class CandidateDal : ICandidateDal
    {
        private readonly IDataContext _context;
        private readonly IMapper _mapper;

        public CandidateDal(IDataContext dataContext,IMapper mapper)
        {
            _context = dataContext;
            _mapper = mapper;
        }
        public async  Task<CoreResponseModel<object>> UpsertCandidate(UpsertCandidateModel upsertCandidateModel)
        {
            CandidatesDataReader.CandidatesDict.TryGetValue(upsertCandidateModel.Email, out Candidate candidate);
            candidate = _mapper.Map<Candidate>(upsertCandidateModel);

            CandidatesDataReader.CandidatesDict[upsertCandidateModel.Email] =candidate;
            _context.SaveChanges();
            return new CoreResponseModel<object> ( candidate,System.Net.HttpStatusCode.OK );
            
        }
    }
}
