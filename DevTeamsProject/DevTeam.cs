using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeam
    {
        public string DevTeamName { get; set; }
        
        public int DevTeamID { get; set; }

        public List<Developer> Developers { get; set; } = new List<Developer>(); // <- NEED TO CHECK, SOMETHING STRANGE HAPPENED HERE! //
        public DevTeam()
        {
            Developers = new List<Developer>();
        }

        public DevTeam(string devTeamName, int devTeamID)
        {
            DevTeamName = devTeamName;
            DevTeamID = devTeamID;
           // Developers = new List<Developer>();
        }
    }



}
