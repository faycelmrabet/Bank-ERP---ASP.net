using Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Data.Interfaces;

namespace Service
{
   public class OffreService : IOffreService
    {
        IDatabaseFactory dbfactory = null;
        IUnitOfWork uow = null;


        public OffreService()
        {

            dbfactory = new DatabaseFactory();
            uow = new UnitOfWork(dbfactory);

        }

        public void AddOffre(offre of)
        {
            uow.OffreRepository.Add(of);
            uow.Commit();
        }

        public void DeleteOffre(offre of)
        {
            uow.OffreRepository.Delete(of);
        }

        public void Dispose()
        {
            uow.Dispose();
        }

        public void editOffre(offre of)
        {
            uow.OffreRepository.Update(of);
            uow.Commit();
        }

        public IEnumerable<offre> GetAllOffres()
        {
            return uow.OffreRepository.GetAll();
        }

        public offre GetById(long id)
        {
           return uow.OffreRepository.GetById(id);
        }

        public void SaveChange()
        {
            uow.Commit();
        }
    }
  
   
}
