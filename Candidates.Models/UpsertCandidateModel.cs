﻿using Candidates.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Candidates.Models
{
    public class UpsertCandidateModel
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Laststname { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        public string LinkedInProfileURL { get; set; }
        
        public string GitHubProfileURL { get; set; }
        [Required]
        public string FreeTextComment { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Email)&&IsEmail(Email)&&
                   !string.IsNullOrEmpty(Firstname) && !string.IsNullOrEmpty(Laststname)&&
                   !string.IsNullOrEmpty(PhoneNumber) && !string.IsNullOrEmpty(FreeTextComment);

        }
        private bool IsEmail(object emailAddress)
        {
            if (emailAddress != null)
            {
                return Regex.IsMatch(emailAddress.ToString(), Constants.EmailRegex, RegexOptions.IgnoreCase);
            }
            throw new ArgumentNullException("emailAddress", ErrorMessages.EmailAddressErrorMessage);
        }
    }
}