using Candidates.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Candidates.Data.contracts
{
    public interface ICandidatesContext<T>
    {
        public DbSet<Candidate> Candidate { get; set; }
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task<Candidate> SaveChanges(Candidate entity);


    }
}
