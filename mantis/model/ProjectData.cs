using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace mantis
{
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        public ProjectData() { }

        public string ProjectName { get; set; }

        public Status ProjectStatus = Status.development;

        public bool ProjectInheritGlobal { get; set; }

        public ViewState ProjectViewState { get; set; }
        public string ProjectDescription { get; set; }

        public bool Equals(ProjectData other)
        {
            if (Object.ReferenceEquals(this, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return ProjectName == other.ProjectName;
        }

        public int CompareTo(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return ProjectName.CompareTo(other.ProjectName);
        }

        public void GenerateRandom()
        {
            ProjectName = StringHelper.GenerateEngNumRandomString(15);
            ProjectInheritGlobal = new Random().Next(2) == 1;
            ProjectDescription = StringHelper.GenerateRandomString(100);
            ProjectStatus = Status.release;
            ProjectViewState = ViewState.Private;
        }
    }

    public enum Status {
        development = 10,
        release = 30,
        stable = 50,
        obsolete = 70
    }
    public enum ViewState
    { 
        Public = 10,
        Private = 50
    }
  


}
