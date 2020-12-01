using DevTeamsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoDeveloperInfoApp
{
    public class Program_UI
    {
        // Accessing DeveloperRepo from this variable.
        private readonly DeveloperRepo _devRepo = new DeveloperRepo();
        private readonly DevTeamRepo _devTeamRepo = new DevTeamRepo();

        public void Run()
        {
            Seed();
            Menu();
        }

        

        private void Menu()
        {
            bool hasStarted = true;
            while (hasStarted)
            {
                Console.WriteLine("Welcome to Komodo Developer Info App\n" +
                    "1. Create New Developer\n" +
                    "2. View All Developers\n" +
                    "3. View Developer by Developer ID\n" +
                    "4. Update Existing Developer\n" +
                    "5. Delete Existing Developer\n" +
                    "6. View Developers Without Pluralsight\n" +
                    "7. Create New Developer Team\n" +
                    "8. View All Developer Teams\n" +
                    "9. View Developer Team by Developer Team ID\n" +
                    "10. Update Existing Developer Team\n" +
                    "11. Delete Existing Developer Team\n" +
                    "***********************************\n" +
                    "50.Exit Application");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        CreateNewDeveloper();
                        break;
                    case "2":
                        ViewAllDevelopers();
                        break;
                    case "3":
                        ViewDeveloperByID();
                        break;
                    case "4":
                        UpdateExistingDeveloper();
                        break;
                    case "5":
                        DeleteExistingDeveloper();
                        break;
                    case "6":
                        ViewDevelopersWithoutPluralsight();
                        break;
                    case "7":
                        CreateNewDeveloperTeam();
                        break;
                    case "8":
                        ViewAllDeveloperTeams();
                        break;
                    case "9":
                        ViewDeveloperTeamByTeamID();
                        break;
                    case "10":
                        UpdateExistingDeveloperTeam();
                        break;
                    case "11":
                        DeleteExistingDeveloperTeam();
                        break;
                    case "50":
                        hasStarted = false;
                        break;
                    default:
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void DeleteExistingDeveloperTeam()
        {
            Console.Clear();
            Console.WriteLine("Please input an developer team ID to delete an existing team.");
            int inputExistingDevTeam = Convert.ToInt32(Console.ReadLine());
            bool isSucessful = _devTeamRepo.DeleteExistingDevTeam(inputExistingDevTeam);

            if (isSucessful)
            {
                Console.WriteLine("Developer team has been deleted.");
            }
            else
            {
                Console.WriteLine("Developer team failed to be deleted.");
            }
        }

        private void UpdateExistingDeveloperTeam()
        {
            Console.Clear();
            DevTeam newDevTeam = new DevTeam();
            Console.WriteLine("Please input developer ID to update.");
            int inputOldDevTeamID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please input developer team name.");
            string inputNewDevTeamName = Console.ReadLine();
            newDevTeam.DevTeamName = inputNewDevTeamName;

           /* Console.WriteLine("Does developer team have Pluralsight access?: Y/N");
            string inputNewDevTeamPluralSight = Console.ReadLine();

            if (inputNewDevTeamPluralSight == "Y" || inputNewDevTeamPluralSight == "y")
            {
                newDevTeam.AccessToPluralsight = true;

            }
            else if (inputNewDevTeamPluralSight == "N" || inputNewDevTeamPluralSight == "n")
            {
                newDevTeam.AccessToPluralsight = false;
            }*/

            bool isSuccessful = _devTeamRepo.UpdateExistingDevTeam(inputOldDevTeamID, newDevTeam);

            if (isSuccessful)
            {
                Console.WriteLine("Developer has been updated.");
            }
            else
            {
                Console.WriteLine("Developer update has failed.");
            }

        }

        private void ViewDeveloperTeamByTeamID()
        {
            Console.Clear();
            Console.WriteLine("Please input developer team ID.");
            
            int inputDevTeamID = Convert.ToInt32(Console.ReadLine());

            DevTeam devTeam = _devTeamRepo.GetDevTeamByID(inputDevTeamID);
            DisplayDevTeamInfo(devTeam);            
        }
        // Helper Method 
        public void DisplayDevTeamInfo(DevTeam devTeam)
        {
            Console.WriteLine($"Team Name: {devTeam.DevTeamName}\n" +
                $"Team ID: {devTeam.DevTeamID}");
        }

        private void ViewAllDeveloperTeams()
        {
            Console.Clear();
            List<DevTeam> devTeams = _devTeamRepo.GetAllDevTeams();
            foreach (var devTeam in devTeams)
            {
                DisplayDevTeamInfo(devTeam);
                Console.WriteLine("*************************");
            }
        }

        private void CreateNewDeveloperTeam()
        {
            Console.Clear();
            DevTeam devTeam = new DevTeam();
            Console.WriteLine("Please input developer team ID.");
            int inputDevTeamID = Convert.ToInt32(Console.ReadLine());
            devTeam.DevTeamID = inputDevTeamID;


            Console.WriteLine("Please input developer team name.");
            string inputDevTeamName = Console.ReadLine();
            devTeam.DevTeamName = inputDevTeamName;

            /*Console.WriteLine("Does entire team have Pluralsight access?: Y/N");
            string inputAccess = Console.ReadLine();

            if (inputAccess == "Y" || inputAccess == "y")
            {
                devTeam.AccessToPluralsight = true;
            }
            else if (inputAccess == "N" || inputAccess == "n")
            {
                devTeam.AccessToPluralsight = false;
            } */
            _devTeamRepo.CreateNewDevTeam(devTeam);
        }

        private void ViewDevelopersWithoutPluralsight()
        {
            Console.Clear();
            // Need a container that holds list of developers
            List<Developer> developers = _devRepo.GiveMeDevelopersWithoutPluralsight();
            foreach (var developer in developers)
            {
                DisplayDeveloperInfo(developer);
                Console.WriteLine("*************************");
            }
        }

        private void DeleteExistingDeveloper()
        {
            Console.Clear();
            Console.WriteLine("Please input an ID to delete an existing developer.");
            int inputExistingDeveloper = Convert.ToInt32(Console.ReadLine());
            bool isSucessful = _devRepo.DeleteExistingDeveloper(inputExistingDeveloper);

            if (isSucessful)
            {
                Console.WriteLine("Developer has been deleted.");
            }
            else
            {
                Console.WriteLine("Developer failed to be deleted.");
            }
        }

        private void UpdateExistingDeveloper()
        {
            Console.Clear();
            Developer newDeveloper = new Developer();
            Console.WriteLine("Please input developer ID to update.");
            int inputOldDeveloperID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please input developer name.");
            string inputNewDeveloperName = Console.ReadLine();
            newDeveloper.DeveloperName = inputNewDeveloperName;

            Console.WriteLine("Does developer have Pluralsight access?: Y/N");
            string inputNewDevPluralSight = Console.ReadLine();

            if (inputNewDevPluralSight == "Y" || inputNewDevPluralSight == "y")
            {
                newDeveloper.AccessToPluralsight = true;
                
            }
            else if (inputNewDevPluralSight == "N" || inputNewDevPluralSight == "n")
            {
                newDeveloper.AccessToPluralsight = false;
            }

            bool isSuccessful = _devRepo.UpdateExistingDeveloper(inputOldDeveloperID, newDeveloper);

            if (isSuccessful)
            {
                Console.WriteLine("Developer has been updated.");
            }
            else
            {
                Console.WriteLine("Developer update has failed.");
            }
        }


        private void ViewDeveloperByID()
        {
            Console.Clear();
            // Ask user to input value for ID
            Console.WriteLine("Please input developer ID.");

            // User input ID stored in inputDeveloperID 
            int inputDeveloperID = Convert.ToInt32(Console.ReadLine());
            
            // This 'developer' container/variable is taking in the contents
            // Reutrned by '_devRepo.GetDeveloperById(inputDeveloperID)'
            // This gives us a developer, and puts it inside 'developer' variable
            Developer developer = _devRepo.GetDeveloperByID(inputDeveloperID);


            /* Now we place that developer inside this method to get all data we need   to display */
           DisplayDeveloperInfo(developer);
        }

        // Helper Method
        public void DisplayDeveloperInfo(Developer developer)
        {
            Console.WriteLine($"Devloper ID: {developer.DeveloperID}\n" +
                $"Developer Name: {developer.DeveloperName}\n" +
                $"{developer.AccessToPluralsight}"
                );
        }



        private void ViewAllDevelopers()
        {
            Console.Clear();
            List<Developer> developers = _devRepo.GetAllDevelopers();
            foreach (var developer in developers)
            {
                DisplayDeveloperInfo(developer);
                Console.WriteLine("*************************");
            }
        }

        private void CreateNewDeveloper()
        {
            Console.Clear();
            Developer developer = new Developer();
            Console.WriteLine("Please input developer ID.");
            int inputDeveloperID = Convert.ToInt32(Console.ReadLine());
            developer.DeveloperID = inputDeveloperID;


            Console.WriteLine("Please input developer name.");
            string inputDeveloperName = Console.ReadLine();
            developer.DeveloperName = inputDeveloperName;

            Console.WriteLine("Does developer have Pluralsight access?: Y/N");
            string inputAccess = Console.ReadLine();

            if (inputAccess == "Y" || inputAccess == "y")
            {
                developer.AccessToPluralsight = true;
            }
            else if (inputAccess == "N" || inputAccess == "n")
            {
                developer.AccessToPluralsight = false;
            }
           // This is where we add the developer to repository.
            _devRepo.CreateNewDeveloper(developer);
        }

        private void Seed() 
        {
            Developer christian = new Developer("Christian McBride", 1, false);
            Developer ray = new Developer("Ray Brown", 2, true);
            Developer dave = new Developer("Dave Holland", 4, false);
            Developer pino = new Developer("Pino Palladino", 5, true);
            Developer charles = new Developer("Charles Mingus", 6, false);

            // We have to add developers to developer repo.

            _devRepo.CreateNewDeveloper(christian);
            _devRepo.CreateNewDeveloper(ray);
            _devRepo.CreateNewDeveloper(dave);
            _devRepo.CreateNewDeveloper(pino);
            _devRepo.CreateNewDeveloper(charles);

            DevTeam bebop = new DevTeam("Bebop", 1);
            DevTeam straightAhead = new DevTeam("Straight Ahead", 2);

            _devTeamRepo.CreateNewDevTeam(bebop);
            _devTeamRepo.CreateNewDevTeam(straightAhead);

            //add devlopers to the team 
            bebop.Developers.Add(christian);
            bebop.Developers.Add(ray);

            straightAhead.Developers.Add(dave);
            straightAhead.Developers.Add(pino);
            straightAhead.Developers.Add(charles);

        }
      
    }
}
