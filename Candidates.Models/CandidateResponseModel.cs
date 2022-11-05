using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Candidates.Models
{
    public class UpsertCandidateModel
    {
        public string Firstname { get; set; }
        public string Laststname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string LinkedInProfileURL { get; set; }
        public string GitHubProfileURL { get; set; }
        public string FreeTextComment { get; set; }

    }
}
