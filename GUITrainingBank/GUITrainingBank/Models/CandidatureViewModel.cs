using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class CandidatureViewModel
    {  /// <summary>
       /// Id
       /// </summary>

        public int Id { get; set; }

        /// <summary>
        /// nomCandidate
        /// </summary>
        public string CandidateName { get; set; }

        /// <summary>
        /// Cv
        /// </summary>

        public string Cv { get; set; }
        /// <summary>
        /// urlCv
        /// </summary>

        public string urlCv { get; set; }
        /// <summary>
        /// idFile
        /// </summary>

        public string idFile { get; set; }

        /// <summary>
        /// dateCreation
        /// </summary>

        public DateTime dateCreation { get; set; }

    }
}
