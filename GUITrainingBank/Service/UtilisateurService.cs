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
   public class UtilisateurService : IUtilisateurService
    {
        static public DatabaseFactory dbFactory = new DatabaseFactory();

        IUnitOfWork utwk = new UnitOfWork(dbFactory);

        public void AddEmployee(utilisateur a)
        {
            utwk.UtilisateurRepository.Add(a);
            utwk.Commit();
        }

        public List<utilisateur> getAllEmployees()
        {
            return utwk.UtilisateurRepository.GetAll().ToList();
        }

        public void UpdateEmployee(utilisateur u)
        {
            utwk.UtilisateurRepository.Update(u);
            utwk.Commit();
        }

        public void DeleteEmployee(utilisateur a)
        {
            utwk.UtilisateurRepository.Delete(a);
            utwk.Commit();
        }

        public utilisateur GetEmployee(long id)
        {
            return utwk.UtilisateurRepository.GetById(id);
        }

        public void DeleteEmployeeById(int id)
        {
            utilisateur u = utwk.UtilisateurRepository.GetById(id);
            utwk.UtilisateurRepository.Delete(u);
            utwk.Commit();
        }
       
    }

   public interface IUtilisateurService
   {
       void AddEmployee(utilisateur a);
       List<utilisateur> getAllEmployees();

       void UpdateEmployee(utilisateur u);

       void DeleteEmployee(utilisateur a);

       utilisateur GetEmployee(long id);
       void DeleteEmployeeById(int id);

       
   }
}
