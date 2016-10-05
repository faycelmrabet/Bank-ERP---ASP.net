using Data.Models;
using Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interfaces;

namespace Service
{
    public class CandidatureService : ICandidatureService
    {
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork utwk = new UnitOfWork(dbFactory);
        public void AddCandidature(candidature a)
        {
            utwk.CandidatureRepository.Add(a);
            utwk.Commit();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void DeleteCandidature(int id)
        {
            candidature c = utwk.CandidatureRepository.GetById(id);
            utwk.CandidatureRepository.Delete(c);
            utwk.Commit();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public candidature getCandidature(int id)
        {
            return utwk.CandidatureRepository.GetById(id);
        }

        public List<candidature> getAllCandidatures()
        {
            return utwk.CandidatureRepository.GetAll().ToList();
        }
    }

    public interface ICandidatureService
    {
        void AddCandidature(candidature a);
        List<candidature> getAllCandidatures();
         void DeleteCandidature(int id);
        candidature getCandidature(int id);
    }


}
