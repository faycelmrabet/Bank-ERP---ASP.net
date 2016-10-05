using Data.Infrastructure;
using Data.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MaterielService : IMaterielService
    {
        IDatabaseFactory dbfactory = null;
        IUnitOfWork uow = null;
        public MaterielService()
        {
            dbfactory = new DatabaseFactory();
            uow = new UnitOfWork(dbfactory);
        }
        public void AddMateriel(materiel materiel)
        {
            uow.MaterielRepository.Add(materiel);
            uow.Commit();
        }

        public void DeleteMateriel(materiel materiel)
        {
            uow.MaterielRepository.Delete(materiel);
        }

        public void Dispose()
        {
            uow.Dispose();
        }

        public void editMateriel(materiel materiel)
        {
            uow.MaterielRepository.Update(materiel);
            uow.Commit();
        }

        public IEnumerable<materiel> GetAllMateriels()
        {
            return uow.MaterielRepository.GetAll();
        }

        public virtual materiel GetById(string id)
        {
            return uow.MaterielRepository.GetById(id);
        }

        public virtual materiel GetById(long id)
        {
            return uow.MaterielRepository.GetById(id);
        }

        public void SaveChange()
        {
            uow.Commit();
        }
    }

}

