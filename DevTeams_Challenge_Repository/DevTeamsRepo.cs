using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Repository
{
    public class DevTeamRepo : DeveloperRepo
    {
        protected List<DevTeam> _teamDirectory = new List<DevTeam>();
        // C
        public bool AddDevTeamToDirectory(DevTeam devTeam)
        {
            int initialTeamCount = _teamDirectory.Count();
            _teamDirectory.Add(devTeam);

            if (_teamDirectory.Count() > initialTeamCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // R
        public List<DevTeam> GetDevTeams()
        {
            return _teamDirectory;
        }
        public DevTeam GetDevTeamById(int teamId)
        {
            return _teamDirectory.Where(d => d.TeamID == teamId).SingleOrDefault();
        }
        //U
        public bool AddDeveloperToTeamById(int devId, int teamId)
        {
            DevTeam devTeam = GetDevTeamById(teamId);
            Developer developer = GetDevByID(devId);
            if (devTeam != default && devId != default)
            {
                int startingCount = devTeam.TeamMembers.Count();
                devTeam.TeamMembers.Add(developer);
                return devTeam.TeamMembers.Count() > startingCount ? true : false;
            }
            return false;
        }
        public bool RemoveDeveloperFromTeamById(int devId, int teamId)
        {
            DevTeam devTeam = GetDevTeamById(teamId);
            Developer developer = devTeam.TeamMembers.Where(d => d.DeveloperID == devId).SingleOrDefault();
            if (devTeam != default)
            {
                return devTeam.TeamMembers.Remove(developer);
            }
            else
                return false;
        }
        //D
        public bool DeleteExistingDevTeam(DevTeam existingDevTeam)
        {
            bool deleteResult = _teamDirectory.Remove(existingDevTeam);
            return deleteResult;
        }

    }
}
