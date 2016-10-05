
using Data;
using Data.Interfaces;
using Data.Models;
using Data.Repositories;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private banquematacheContext dataContext;
        protected banquematacheContext DataContext
        {
            get
            {
                return dataContext = dbFactory.DataContext;
            }
        }

        IDatabaseFactory dbFactory;
        public UnitOfWork(IDatabaseFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }
        public void Commit()
        {
            DataContext.SaveChanges();
        }


        private ITrainingSessionRepository trainingSessionRepository;
     
        public ITrainingSessionRepository TrainingSessionRepository
        {
            get { return trainingSessionRepository = new TrainingSessionRepository(dbFactory); }
        }

        private ITrainingRepository trainingRepository;
        public ITrainingRepository TrainingRepository
        {
            get
            {
                return trainingRepository = new TrainingRepository(dbFactory);
            }
        }

        private ITrainerRepository trainerRepository;
        public ITrainerRepository TrainerRepository
        {
            get
            {
                return trainerRepository = new TrainerRepository(dbFactory);
            }
        }
        private IMaterielRepository materielRepository;
        public IMaterielRepository MaterielRepository
        {
            get
            {
                return materielRepository = new MaterielRepository(dbFactory);
            }
        }
        private IContratRepository contratRepository;
        public IContratRepository ContratRepository
        {
            get { return contratRepository = new ContratRepository(dbFactory); }
        }
        private IOffreRepository offreRepository;
        public IOffreRepository OffreRepository
        {
            get
            {
                return offreRepository = new OffreRepository(dbFactory);
            }
        }
        //private IUtilisateurRepository utilisateurRepository;
        //IUtilisateurRepository IUnitOfWork.UtilisateurRepository
        //{
        //    get
        //    {
        //        return utilisateurRepository ?? (utilisateurRepository = new
        // UtilisateurRepository(dbFactory));
        //    }
        //}
        private IUtilisateurRepository utilisateurRepository;

        public IUtilisateurRepository UtilisateurRepository
        {
            get { return utilisateurRepository = new UtilisateurRepository(dbFactory); }
        }




        private ICandidatureRepository candidatureRepository;

        public ICandidatureRepository CandidatureRepository
        {
            get { return candidatureRepository = new CandidatureRepository(dbFactory); }
        }

        public void Dispose()
        {
            DataContext.Dispose();
        }
        
    }
}
