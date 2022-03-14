using DevTeams_Challenge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Console
{
    public class ProgramUI
    {
        private DevTeamRepo _teamRepo = new DevTeamRepo();
        public void Run()
        {
            SeedContent();
            Menu();
        }
        private void Menu()
        {
            bool runMenu = true;
            bool devMenu = true;
            while (runMenu)
            {
                if (devMenu)
                {

                    Console.Clear();
                    Console.WriteLine("The Komodo Insurance Developer Menu\n" +
                        "Please select the number option you'd like to use: \n" +
                        "1. Create New Developer\n" +
                        "2. Add Developer To a Team With Id\n" +
                        "3. Remove Developer From a Team By Id\n" +
                        "4. Display All Developers\n" +
                        "5. Developers that need Plural Access\n" +
                        "6. Update Existing Developer\n" +
                        "7. Delete Existing Developer\n" +
                        "8. Developer Team Menu\n" +
                        "9. Exit\n");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            CreateNewDeveloper();
                            break;
                        case "2":
                            AddDeveloperToTeamWithId();
                            break;
                        case "3":
                            RemoveDeveloperFromTeamById();
                            break;
                        case "4":
                            DisplayAllDevelopers();
                            break;
                        case "5":
                            NeedsPluralAccess();
                            break;
                        case "6":
                            UpdateExistingDeveloper();
                            break;
                        case "7":
                            DeleteExistingDeveloper();
                            break;
                        case "8":
                            devMenu = false;
                            break;
                        case "9":
                        case "exit":
                        case "e":
                            runMenu = false;
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("The Komodo Insurance Developer Team Menu\n" +
                        "Please enter the numebr option you'd like to use: \n" +
                        "1. Create New Developer Team\n" +
                        "2. Display All Developers By Team\n" +
                        "3. Display All Teams\n" +
                        "4. Update Existing Team\n" +
                        "5. Delete Existing Team\n" +
                        "6. Back to Developer Menu\n");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            CreateDevTeam();
                            break;
                        case "2":
                            DisplayDeveloperByTeam();
                            break;
                        case "3":
                            DisplayAllTeams();
                            break;
                        case "4":
                            UpdateExistingTeam();
                            break;
                        case "5":
                            DeleteExistingTeam();
                            break;
                        case "6":
                        default:
                            devMenu = true;
                            break;
                    }
                }
            }
        }
        private void CreateNewDeveloper()
        {
            Console.Clear();
            Developer developer = new Developer();
            Console.Write("FirstName: ");
            developer.FirstName = Console.ReadLine();
            Console.Write("LastName: ");
            developer.LastName = Console.ReadLine();
            Console.Write("Id Number: ");
            developer.DeveloperID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Select developer Specialty\n" +
                "1. FrontEnd\n" +
                "2. BackEnd\n" +
                "3. Testing\n");
            string devSpecialty = Console.ReadLine();
            switch (devSpecialty)
            {
                case "1":
                    developer.AssignedTeam = TeamAssignment.FrontEnd;
                    break;
                case "2":
                    developer.AssignedTeam = TeamAssignment.BackEnd;
                    break;
                case "3":
                    developer.AssignedTeam = TeamAssignment.Testing;
                    break;

            }
            Console.Write("Enter yes/no if Developer has access to PluralSight: ");
            string newDeveloper = Console.ReadLine().ToLower();
            if (newDeveloper == "yes")
            {
                developer.PluralSightAccess = true;
            }
            else
            {
                developer.PluralSightAccess = false;
            }
            bool newdeveloper = _teamRepo.AddDeveloperToDirectory(developer);
            if (newdeveloper == true)
            {
                Console.WriteLine($"Developer {developer.DeveloperID} Added");
            }
            else
            {
                Console.WriteLine("Developer not added");
            }
            AnyKey();
        }
        private void CreateDevTeam()
        {
            Console.Clear();
            HDisplayTeams();
            DevTeam devTeam = new DevTeam();
            Console.Write("Team Name: ");
            devTeam.TeamName = Console.ReadLine();
            Console.Write("Team Id Number: ");
            devTeam.TeamID = Convert.ToInt32(Console.ReadLine());
            bool newTeam = _teamRepo.AddDevTeamToDirectory(devTeam);
            if (newTeam == true)
            {
                Console.WriteLine($"Team {devTeam.TeamID} Added");
            }
            else
            {
                Console.WriteLine("Team Not Added");
            }
            AnyKey();
        }
        private void AddDeveloperToTeamWithId()
        {
            Console.Clear();
            HDisplayDevelopers();
            Console.Write("\nPlease enter the Developer Id you wish to add, if adding multiple developers please put a comma between each one: ");
            string devIds = Console.ReadLine();
            var devIdSplit = devIds.Split(',');
            HDisplayTeams();
            Console.Write("Please input the Team Id you would like to add the developer to: ");
            int teamId = int.Parse(Console.ReadLine());
            foreach (var id in devIdSplit)
            {
                if (_teamRepo.AddDeveloperToTeamById(int.Parse(id), teamId))
                {
                    Console.WriteLine($"Developer(s) {id} added to team {teamId}!");
                }
                else
                {
                    Console.WriteLine("Uh oh it didn't work.");
                }
            }
            AnyKey();
        }
        private void RemoveDeveloperFromTeamById()
        {
            Console.Clear();
            HDisplayDevelopers();
            Console.Write("Please enter the developer you'd like to remove: ");
            string devIds = Console.ReadLine();
            var devIdSplit = devIds.Split(',');
            HDisplayTeams();
            Console.Write("Please enter the Id of the Team you'd like to remove them from: ");
            int teamId = int.Parse(Console.ReadLine());
            foreach (var id in devIdSplit)
            {
                if (_teamRepo.RemoveDeveloperFromTeamById(int.Parse(id), teamId))
                {
                    Console.WriteLine($"Developer {id} has been take off of team {teamId}!");
                }
                else
                {
                    Console.WriteLine("Oh no something went wrong");
                }
            }
            AnyKey();
        }
        private void DisplayAllTeams()
        {
            Console.Clear();
            List<DevTeam> listOfDevTeams = _teamRepo.GetDevTeams();
            foreach (DevTeam devTeam in listOfDevTeams)
            {
                Console.WriteLine($"Development Team Id: {devTeam.TeamID}\n" +
                    $"Development Team Name: {devTeam.TeamName}");
            }
            AnyKey();
        }
        private void DisplayAllDevelopers()
        {
            Console.Clear();
            List<Developer> listOfDevelopers = _teamRepo.GetDevelopers();
            foreach (Developer developer in listOfDevelopers)
            {
                Console.WriteLine($"Developer Name: {developer.FirstName} {developer.LastName}\n" +
                    $"Developer ID Number: {developer.DeveloperID}\n" +
                    $"Developer has PluralSight Access: {developer.PluralSightAccess}\n" +
                    $"Developers Team Assignment: {developer.AssignedTeam}\n");
            }
            AnyKey();
        }
        private void DisplayDeveloperByTeam()
        {
            Console.Clear();
            List<DevTeam> listOfDevTeams = _teamRepo.GetDevTeams();
            foreach (DevTeam devTeams in listOfDevTeams)
            {
                Console.WriteLine($"Development Team Id Number: {devTeams.TeamID}\n" +
                    $"Development Team Name: {devTeams.TeamName}\n");
                foreach (Developer developer in devTeams.TeamMembers)
                {
                    Console.WriteLine($"Developer Id: {developer.DeveloperID}\n" +
                        $"Developer First Name: {developer.FirstName}\n" +
                        $"Developer Last Name: {developer.LastName}\n");
                }
            }
            AnyKey();
        }
        private void NeedsPluralAccess()
        {
            Console.Clear();
            List<Developer> pluralAccess = _teamRepo.GetDevelopers();
            foreach (Developer developer in pluralAccess)
            {
                if (developer.PluralSightAccess == false)
                {
                    Console.WriteLine($"Developer Name: {developer.FirstName} {developer.LastName}\n" +
                    $"Developer ID Number: {developer.DeveloperID}\n" +
                    $"Developer has PluralSight Access: {developer.PluralSightAccess}\n" +
                    $"Developers Team Assignment: {developer.AssignedTeam}\n");
                }
            }
            AnyKey();
        }
        private void UpdateExistingDeveloper()
        {
            Console.Clear();
            Developer newInfo = new Developer();
            HDisplayDevelopers();
            Console.Write("Enter the Id Number of Developer for Updating: ");
            int devId = int.Parse(Console.ReadLine());
            Developer oldDev = _teamRepo.GetDevByID(devId);
           
            Console.Write("Enter the Developer's New ID: ");
            newInfo.DeveloperID = Convert.ToInt32(Console.ReadLine());
           
            Console.Write("Enter the Developer's New First Name: ");
            newInfo.FirstName = Console.ReadLine();
            
            Console.Write("Enter the Developer's New Last Name: ");
            newInfo.LastName = Console.ReadLine();
            
            Console.Write("Enter (Yes/No) if the Developer has a Pluralsight License: ");
            string newLic = Console.ReadLine().ToLower();
            if (newLic == "yes" || newLic == "true" || newLic == "y")
            {
                newInfo.PluralSightAccess = true;
            }
            else
            {
                newInfo.PluralSightAccess = false;
            }
            if (_teamRepo.UpdateExistingDevelopers(oldDev, newInfo))
            {
                Console.WriteLine("The developers information was updated!");
            }
            else
            {
                Console.WriteLine("Oh no something went wrong");
            }
            AnyKey();
        }
        private void UpdateExistingTeam()
        {
            Console.Clear();
            HDisplayTeams();
            Console.Write("Enter the ID of the Team you would like to update: ");
            DevTeam oldDevTeam = _teamRepo.GetDevTeamById(int.Parse(Console.ReadLine()));
            if (oldDevTeam != null)
            {
                Console.Clear();
                Console.Write("Enter the new Team Id: ");
                string newTeamId = Console.ReadLine();
                if (newTeamId != "")
                {
                    oldDevTeam.TeamID = int.Parse(newTeamId);
                }
                Console.Write("Enter new team Name: ");
                string newTeamName = Console.ReadLine();
                if (newTeamName != "")
                {
                    oldDevTeam.TeamName = newTeamName;
                }
                Console.WriteLine("The team has been updated!!");
            }
            else
            {
                Console.WriteLine("Oh no something went wrong.");
            }
            AnyKey();

        }
        private void DeleteExistingDeveloper()
        {
            List<Developer> removeDeveloper = _teamRepo.GetDevelopers();
            Console.Clear();
            HDisplayDevelopers();
            Console.WriteLine("Enter the Developer ID Number for Removal.\n");
            int removeDevId = Convert.ToInt32(Console.ReadLine());
            Developer deleteDev = _teamRepo.GetDevByID(removeDevId);
            bool confirmDevDel = _teamRepo.DeleteExistingDevelopers(deleteDev);
            if (confirmDevDel == true)
            {
                Console.WriteLine($"Cofirmation, Developer {removeDevId} was Removed.\n");

            }
            else
            {
                Console.WriteLine("Uh oh something went wrong");
            }
            AnyKey();
        }
        private void DeleteExistingTeam()
        {
            List<DevTeam> removeDevTeam = _teamRepo.GetDevTeams();
            Console.Clear();
            HDisplayTeams();
            Console.WriteLine("Enter the Development Team you wish to delete: ");
            int removeDevTeamId = int.Parse(Console.ReadLine());
            DevTeam deleteDevTeam = _teamRepo.GetDevTeamById(removeDevTeamId);
            bool confirmDevTeamDel = _teamRepo.DeleteExistingDevTeam(deleteDevTeam);
            if (confirmDevTeamDel == true)
            {
                Console.WriteLine($"You have successfully deleted Team {removeDevTeamId}!");
            }
            else
            {
                Console.WriteLine("Oh no something went wrong.");
            }
            AnyKey();
        }
        private void SeedContent()
        {
            var dev1 = new Developer("Chris", "Pettigrew", 1, true, TeamAssignment.FrontEnd);
            var dev2 = new Developer("steve", "Johnson", 2, false, TeamAssignment.FrontEnd);
            var dev3 = new Developer("John", "Smitherson", 3, false, TeamAssignment.BackEnd);
            var dev4 = new Developer("Paul", "Jones", 4, true, TeamAssignment.BackEnd);
            var dev5 = new Developer("Jason", "Williams", 5, false, TeamAssignment.Testing);
            var dev6 = new Developer("Jamie", "Smith", 6, true, TeamAssignment.Testing);
            _teamRepo.AddDeveloperToDirectory(dev1);
            _teamRepo.AddDeveloperToDirectory(dev2);
            _teamRepo.AddDeveloperToDirectory(dev3);
            _teamRepo.AddDeveloperToDirectory(dev4);
            _teamRepo.AddDeveloperToDirectory(dev5);
            _teamRepo.AddDeveloperToDirectory(dev6);
            List<Developer> TeamMem1 = new List<Developer>();
            TeamMem1.Add(dev1);
            TeamMem1.Add(dev3);
            List<Developer> TeamMem2 = new List<Developer>();
            TeamMem2.Add(dev2);
            TeamMem2.Add(dev4);
            DevTeam devTeamOne = new DevTeam("devTeam1", 1, TeamMem1);
            DevTeam devTeamTwo = new DevTeam("devTeam2", 2, TeamMem2);
            _teamRepo.AddDevTeamToDirectory(devTeamOne);
            _teamRepo.AddDevTeamToDirectory(devTeamTwo);
        }
        private void AnyKey()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        private void HDisplayDevelopers()
        {
            Console.Clear();
            List<Developer> listOfDevelopers = _teamRepo.GetDevelopers();
            foreach (Developer developer in listOfDevelopers)
            {
                Console.WriteLine($"Developer Name: {developer.FirstName} {developer.LastName}\n" +
                    $"Developer ID Number: {developer.DeveloperID}\n" +
                    $"Developer has PluralSight Access: {developer.PluralSightAccess}\n" +
                    $"Developers Team Assignment: {developer.AssignedTeam}\n");
            }
        }
        private void HDisplayTeams()
        {
            Console.Clear();
            List<DevTeam> listOfDevTeams = _teamRepo.GetDevTeams();
            foreach (DevTeam devTeam in listOfDevTeams)
            {
                Console.WriteLine($"Development Team Id: {devTeam.TeamID}\n" +
                    $"Development Team Name: {devTeam.TeamName}");
            }
        }
    }
}