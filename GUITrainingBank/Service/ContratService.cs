using Data.Infrastructure;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ContratService : IContratService

    {
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork utwk = new UnitOfWork(dbFactory);

        public void AddContrat(contrat c)
        {
            utwk.ContratRepository.Add(c);
            utwk.Commit();
        }

        public void DeleteContact(contrat c)
        {
            utwk.ContratRepository.Delete(c);
            utwk.Commit();
        }

        public List<contrat> getAllContrats()
        {
            return utwk.ContratRepository.GetAll().ToList();
        }

        public contrat getById(int id)
        {
            return utwk.ContratRepository.GetById(id);
        }

        public void Update(contrat c)
        {
            utwk.ContratRepository.Update(c);
            utwk.Commit();
        }
    }

    public interface IContratService {

        void AddContrat(contrat c);
        List<contrat> getAllContrats();
        contrat getById(int id);
        void DeleteContact(contrat c);

        void Update(contrat c);

    }
}

