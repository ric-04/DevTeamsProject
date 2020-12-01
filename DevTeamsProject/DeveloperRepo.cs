using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DeveloperRepo
    {
        private readonly List<Developer> _developerDirectory = new List<Developer>(); // <- Simulates database

        // Developer Create
        public void CreateNewDeveloper(Developer developer)
        {
            // Add developer, I'm passing though my parameter to _developerDirectory
            _developerDirectory.Add(developer);
        }

        // Developer Read
        public List<Developer> GetAllDevelopers()
        {
            return _developerDirectory;
        }

        // Developer Update
        public bool UpdateExistingDeveloper(int oldDeveloperID, Developer newDeveloper)
        {
            Developer oldDeveloper = GetDeveloperByID(oldDeveloperID);
            if (oldDeveloper != null)
            {
                newDeveloper.DeveloperID = oldDeveloper.DeveloperID;
                oldDeveloper.DeveloperName = newDeveloper.DeveloperName;
                oldDeveloper.AccessToPluralsight = newDeveloper.AccessToPluralsight;
                return true;
            }
            else
            {
                return false;
            }
        }


        // Developer Delete
        public bool DeleteExistingDeveloper(int developerID)
        {
            Developer developer = GetDeveloperByID(developerID);
            if (developer == null)
            {
                return false;
            }

            int initalCount = _developerDirectory.Count();
            _developerDirectory.Remove(developer);

            if (initalCount > _developerDirectory.Count())
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        // Developer Helper (Get Developer by ID)
        public Developer GetDeveloperByID(int ID)
        {
            foreach (Developer developer in _developerDirectory)
            {
                if (developer.DeveloperID == ID)
                {
                    return developer;
                }
            }
            return null;
        }

        public List<Developer> GiveMeDevelopersWithoutPluralsight()
        {
            List<Developer> developersWithoutPluralsight = new List<Developer>();

            foreach (var developer in _developerDirectory)
            {
                if (developer.AccessToPluralsight == false)
                {
                    developersWithoutPluralsight.Add(developer);
                }
             
            }
            return developersWithoutPluralsight;
        }
    }
}
