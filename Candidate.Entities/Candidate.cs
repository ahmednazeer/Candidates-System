using System;
using System.ComponentModel.DataAnnotations;

namespace Candidates.Entities
{
    public class Candidate
    {
        
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Laststname { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public string LinkedInProfileURL { get; set; }
        public string GitHubProfileURL { get; set; }
        [Required]
        public string FreeTextComment { get; set; }
    }
}
