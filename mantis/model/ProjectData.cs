using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis
{
    public class ProjectData
    {
        public string ProjectName { get; set; }
        public Status ProjectStatus = Status.development;
        public bool ProjectInheritGlobal { get; set; }
        public ViewState ProjectViewState = ViewState.Public;
        public string ProjectDescription { get; set; }
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
