using Candidates.Data.contracts;
using Candidates.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Candidates.Data
{
    public class CandidatesContext : ICandidatesContext<BaseEntity>
    {
        public DbSet<Candidate> Candidate { set; get; }
       
        public async Task<BaseEntity> Insert(BaseEntity entity)
        {
            var url = "https://localhost:44304/api/CsvTest/data.csv&#8221";

            var client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(url);

            var stream = await response.Content.ReadAsStreamAsync();

            var fileInfo = new FileInfo("candidates.csv");

            using (var fileStream = fileInfo.OpenWrite())

            {

                await stream.CopyToAsync(fileStream);

            }
            return null;
        }

        public Task<Candidate> SaveChanges(Candidate entity)
        {
            throw new NotImplementedException();
        }

        public Task<BaseEntity> Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
