using Data.Infrastructure;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class TrainingService : ITrainingService
    {

        public static DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork utwk = new UnitOfWork(dbFactory);
        public void addTraining(training t)
        {
            utwk.TrainingRepository.Add(t);
            utwk.Commit();
        }

        public void DeleteTraining(int id)
        {
            utwk.TrainingRepository.Delete(getOneTraining(id));
            utwk.Commit();
        }

        public List<training> getAllTraining()
        {
            return utwk.TrainingRepository.GetAll().ToList();
        }

        public training getOneTraining(int id)
        {
            return utwk.TrainingRepository.GetById(id);
        }

     

        public void UpdateTraining(training tr)
        {
            utwk.TrainingRepository.Update(tr);
        }
    }

    public interface ITrainingService
    {
        void addTraining(training t);
        List<training> getAllTraining();

        training getOneTraining(int id);

        void UpdateTraining(training tr);
        void DeleteTraining(int id);

    }
}
