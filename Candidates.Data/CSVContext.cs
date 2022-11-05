using Candidates.Data.contracts;
using Candidates.Helpers;
using CsvHelper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Candidates.Data
{
    public class CSVContext : IDataContext
    {
        private readonly IConfiguration _configuration;
        public CSVContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void SaveChanges()
        {
            {
                using (var writer = new StreamWriter(_configuration.GetSection("csvFileLocation").Value))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    var records = CandidatesDataReader.CandidatesDict.Values.ToList();
                    csv.WriteRecords(records);
                }
            }
        }
    }
}
