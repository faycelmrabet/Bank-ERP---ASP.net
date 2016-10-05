using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Data.Repositories;
using Service;
using Data.Interfaces;
using Data.Infrastructure;
using Data;
using GUITrainingBank.Controllers;
using Data.Repository;

namespace GUITrainingBank.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
             container.RegisterType<ITrainingSessionRepository, TrainingSessionRepository>(new PerRequestLifetimeManager());
            container.RegisterType<ITrainingSessionService, TrainingSessionService>(new PerRequestLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new PerRequestLifetimeManager());
            container.RegisterType<IDatabaseFactory, DatabaseFactory>(new PerRequestLifetimeManager());
            container.RegisterType<ITrainingRepository, TrainingRepository>(new PerRequestLifetimeManager());
            container.RegisterType<ITrainingService, TrainingService>(new PerRequestLifetimeManager());
            container.RegisterType<ITrainerService, TrainerService>(new PerRequestLifetimeManager());
            container.RegisterType<ITrainerRepository, TrainerRepository>(new PerRequestLifetimeManager());

            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());

            container.RegisterType<IMaterielService, MaterielService>(new PerRequestLifetimeManager());
            container.RegisterType<IMaterielRepository, MaterielRepository>(new PerRequestLifetimeManager());

            container.RegisterType<IContratService, ContratService>(new PerRequestLifetimeManager());
            container.RegisterType<IContratRepository, ContratRepository>(new PerRequestLifetimeManager());

            container.RegisterType<IOffreService, OffreService>(new PerRequestLifetimeManager());
            container.RegisterType<IOffreRepository, OffreRepository>(new PerRequestLifetimeManager());

            container.RegisterType<IUtilisateurService, UtilisateurService>(new PerRequestLifetimeManager());
            container.RegisterType<IUtilisateurRepository, UtilisateurRepository>(new PerRequestLifetimeManager());

            container.RegisterType<ICandidatureService, CandidatureService>(new PerRequestLifetimeManager());
            container.RegisterType<ICandidatureRepository, CandidatureRepository>(new PerRequestLifetimeManager());
        }
    }
}
