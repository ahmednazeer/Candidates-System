using Candidates.Entities;
using CsvHelper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Candidates.Helpers
{
    public class CandidatesDataReader
    {
        private  string fileLocation=string.Empty;
        private readonly IConfiguration _configuration;
        public static Dictionary<string, Candidate> CandidatesDict;

        public CandidatesDataReader(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void LoadCandidates(){
            fileLocation = _configuration.GetSection("csvFileLocation").Value;
            if (File.Exists(fileLocation))
            {
                using (var reader = new StreamReader(fileLocation))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Candidate>()?.ToList();
                    if (records == null)
                        CandidatesDict = new Dictionary<string, Candidate>();
                    else
                        CandidatesDict = records.ToDictionary(rec => rec.Email, rec => rec);
                }
            }else
                CandidatesDict = CandidatesDict = new Dictionary<string, Candidate>();



        }
    }
}
