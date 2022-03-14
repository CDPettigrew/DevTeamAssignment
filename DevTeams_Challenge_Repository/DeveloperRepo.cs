using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Repository
{
    public class DeveloperRepo
    {
        protected List<Developer> _devDirectory = new List<Developer>();
        // C
        public bool AddDeveloperToDirectory(Developer developer)
        {
            int initialTeamCount = _devDirectory.Count();
            _devDirectory.Add(developer);

            if (_devDirectory.Count() > initialTeamCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // R
        public List<Developer> GetDevelopers()
        {
            return _devDirectory;
        }
        public Developer GetDevByName(string firstName)
        {
            foreach(Developer developer in _devDirectory)
            {
                if(developer.FirstName == firstName)
                {
                    return developer;
                }
            }
            return null;
        }
        public Developer GetDevByID(int devId)
        {
            return _devDirectory.Where(d => d.DeveloperID == devId).SingleOrDefault();
        }
        public bool HasAccessToPluralSight(int id)
        {
            foreach(Developer developer in _devDirectory)
            {
                if(developer.DeveloperID == id)
                {
                    return developer.PluralSightAccess;
                }
            }
            return false;
        }
        // U
        public bool UpdateExistingDevelopers(Developer oldDev, Developer newDev)
        {
            Developer oldDeveloper = oldDev;
            if(oldDev != null)
            {
                oldDev.FirstName = newDev.FirstName;
                oldDev.LastName = newDev.LastName;
                oldDev.DeveloperID = newDev.DeveloperID;
                oldDev.AssignedTeam = newDev.AssignedTeam;

                return true;
            }
            else
            {
                return false;
            }
        }
        // D
        public bool DeleteExistingDevelopers(Developer existingDeveloper)
        {
            bool deleteResult = _devDirectory.Remove(existingDeveloper);
            return deleteResult;
        }
    }
}
