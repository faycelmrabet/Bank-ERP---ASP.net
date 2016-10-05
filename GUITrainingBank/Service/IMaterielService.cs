using Data.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IMaterielService : IDisposable
    {
        void AddMateriel(materiel materiel);
        void DeleteMateriel(materiel materiel);
        void editMateriel(materiel materiel);
        materiel GetById(long id);
        materiel GetById(string id);
        System.Collections.Generic.IEnumerable<materiel> GetAllMateriels();

        void SaveChange();

    }
}
