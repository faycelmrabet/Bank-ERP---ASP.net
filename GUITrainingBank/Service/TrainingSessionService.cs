using Data.Infrastructure;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class TrainingSessionService : ITrainingSessionService
    {
        public static DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWork utwk = new UnitOfWork(dbFactory);
        public void AddTrainingSession(trainingsession ts)
        {
            utwk.TrainingSessionRepository.Add(ts);
            utwk.Commit();
        }

        public void DeleteTrainingSession(int id)
        {
            utwk.TrainingSessionRepository.Delete(getOneTrainingSession(id));
            utwk.Commit();
        }

        public List<trainingsession> getAllTrainingSession()
        {
            return utwk.TrainingSessionRepository.GetAll().ToList();
        }

        public trainingsession getOneTrainingSession(int id)
        {
            return utwk.TrainingSessionRepository.GetById(id);
        }

        public void UpdateTrainingSession(trainingsession tr)
        {
            utwk.TrainingSessionRepository.Update(tr);
        }
    }
    public interface ITrainingSessionService
    {
        void AddTrainingSession(trainingsession ts);
        List<trainingsession> getAllTrainingSession();

        trainingsession getOneTrainingSession(int id);

        void UpdateTrainingSession(trainingsession tr);
        void DeleteTrainingSession(int id);

    }
}
