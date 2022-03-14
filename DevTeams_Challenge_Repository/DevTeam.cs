using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Repository
{
    public class DevTeam
    {
        public DevTeam() { }
        public DevTeam(string teamName, int teamId, List<Developer> devTeamMembers) 
        {
            TeamName = teamName;
            TeamID = teamId;
            TeamMembers = devTeamMembers;
        }
        public string TeamName { get; set; }
        public int TeamID { get; set; }
        public List<Developer> TeamMembers { get; set; }
        

    }
}
