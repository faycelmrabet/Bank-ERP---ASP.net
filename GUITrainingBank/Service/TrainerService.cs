using Data.Infrastructure;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class TrainerService : ITrainerService
    {
        public static DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork utwk = new UnitOfWork(dbFactory);
        public void addTrainer(utilisateur t)
        {
            utwk.TrainerRepository.Add(t);
            utwk.Commit();
        }

        public void DeleteTrainer(int id)
        {
            utwk.TrainerRepository.Delete(getOneTrainer(id));
            utwk.Commit();
        }

        public List<utilisateur> getAllTrainer()
        {
            return utwk.TrainerRepository.GetAll().ToList();
        }

        public utilisateur getOneTrainer(int id)
        {
            return utwk.TrainerRepository.GetById(id);
        }

        public void UpdateTrainer(utilisateur tr)
        {
            utwk.TrainerRepository.Update(tr);
        }
    }
    public interface ITrainerService
    {
        void addTrainer(utilisateur t);
        List<utilisateur> getAllTrainer();

        utilisateur getOneTrainer(int id);

        void UpdateTrainer(utilisateur tr);
        void DeleteTrainer(int id);

    }
}
