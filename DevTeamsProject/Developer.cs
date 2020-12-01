using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class Developer
    {
        // Property for Name 
        public string DeveloperName { get; set; }


        // Property for ID # THIS IS MY KEY (UNIQUE IDENTIFIER)
        public int DeveloperID { get; set; }


        // Property for Access to Pluralsight
        public  bool AccessToPluralsight { get; set; }

        // Build Constructors

        // 1st Constructor = Empty (CTOR Tab, Tab = Shortcut)
        public Developer()
        {

        }

        // 2nd Constructor
        public Developer(string developerName, int developerID, bool accessToPluralSight)
        {
            DeveloperName = developerName;
            DeveloperID = developerID;
            AccessToPluralsight = accessToPluralSight;
        }
    }
}
