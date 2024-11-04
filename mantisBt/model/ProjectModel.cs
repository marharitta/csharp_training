using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Mantis;

namespace MantisTest
{
    public class ProjectModel : IEquatable<ProjectModel>, IComparable<ProjectModel>
    {
        public ProjectModel() { }
        public ProjectModel(ProjectData data)
        {
            ProjectName = data.name;
            ProjectInheritGlobal = data.inherit_global;
            ProjectDescription = data.description;
            //ProjectStatus = data.status;
            //ProjectViewState = data.view_state;
        }

        public string Id { get; set; }
        public string ProjectName { get; set; }

        public Status ProjectStatus = Status.development;

        public bool ProjectInheritGlobal { get; set; }

        public ViewState ProjectViewState { get; set; }
        public string ProjectDescription { get; set; }

        public bool Equals(ProjectModel other)
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

        public int CompareTo(ProjectModel other)
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
