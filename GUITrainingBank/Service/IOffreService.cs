using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Service
{
   public interface IOffreService : IDisposable
    {

        void AddOffre(offre of);
        void DeleteOffre(offre of);
        void editOffre(offre of);
        offre GetById(long id);
        System.Collections.Generic.IEnumerable<offre> GetAllOffres();
        void SaveChange();


    }
}
