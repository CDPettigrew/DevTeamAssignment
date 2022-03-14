using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Repository
{
    public enum TeamAssignment { FrontEnd, BackEnd, Testing }
    public class Developer
    {
        public Developer() { }
        public Developer(string firstName, string lastName, int id, bool pluralSightAccess, TeamAssignment assignedTeam)
        {
            FirstName = firstName;
            LastName = lastName;
            DeveloperID = id;
            AssignedTeam = assignedTeam;
            PluralSightAccess = pluralSightAccess;
        }
        public string FirstName { get; set; }
        public int DeveloperID { get; set; }
        public string LastName { get; set; }
        public TeamAssignment AssignedTeam { get; set; }
        public bool PluralSightAccess { get; set; }
    }
}
