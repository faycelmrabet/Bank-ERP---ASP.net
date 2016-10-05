using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class candidature
    {
        public int id { get; set; }
        public string CandidateName { get; set; }
        public string Cv { get; set; }
        public string urlCv { get; set; }
        public DateTime? dateCreation { get; set; }

        public string ifFile { get; set; }
    }
}
