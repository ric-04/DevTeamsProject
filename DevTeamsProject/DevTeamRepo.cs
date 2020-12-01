using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeamRepo
    {
        private readonly DeveloperRepo _developerRepo = new DeveloperRepo(); // this gives you access to the _developerDirectory so you can access existing Developers and add them to a team
        private readonly List<DevTeam> _devTeamsDirectory = new List<DevTeam>();

        //DevTeam Create -> is to add to the _deveTeamsDirectory
        public void CreateNewDevTeam(DevTeam devTeam)
        {
            _devTeamsDirectory.Add(devTeam);
        }

        //DevTeam Read

        public List<DevTeam> GetAllDevTeams()
        {
            return _devTeamsDirectory;
        }

        //DevTeam Update
        public bool UpdateExistingDevTeam(int oldDevTeamID, DevTeam newDevTeam)
        {
            DevTeam oldDevTeam = GetDevTeamByID(oldDevTeamID);
            if (oldDevTeam != null)
            {
                newDevTeam.DevTeamID = oldDevTeam.DevTeamID;
                oldDevTeam.DevTeamName = newDevTeam.DevTeamName;
                return true;
            }
            else
            {
                return false;
            }
        }

        // DevTeam Delete
        public bool DeleteExistingDevTeam(int devTeamID)
        {
            DevTeam devTeam = GetDevTeamByID(devTeamID);
            if (devTeam == null)
            {
                return false;
            }

            int initialCount = _devTeamsDirectory.Count();
            _devTeamsDirectory.Remove(devTeam);
            {
                if (initialCount > _devTeamsDirectory.Count())
                {
                    return true;
                }

                else
                {
                    return false;
                }

            }
        }

            //DevTeam Helper (Get Team by ID) // CAN'T FIGURE OUT HOW TO PLACE THIS CORRECTLY IN "{ }" !
            public DevTeam GetDevTeamByID(int ID)
            {
                
                foreach (DevTeam devTeam in _devTeamsDirectory)
                { 
                    if (devTeam.DevTeamID == ID)
                    {
                    return devTeam;
                    }
                }
             return null;   
            }
    }
}