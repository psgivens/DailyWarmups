using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TeamExplorer
{
    public class TeamViewModel : ViewModelBase
    {
        private string _selectedProject;
        private string _selectedView;


        public TeamViewModel()
        {
            SelectedView = "Sample View";
            SelectedProject = "Sample Project";
            Views = new CommandBase[]{
                new CommandBase { Title = "One" },
                new CommandBase { Title = "Two" }
            };
            Projects = new CommandBase[]{
                new CommandBase { Title = "One" },
                new CommandBase { Title = "Two" }
            };
           
        }

        public string SelectedView
        {
            get { return _selectedView; }
            set
            {
                _selectedView = value;
                RaisePropertyChanged("SelectedView");
            }
        }

        public string SelectedProject
        {
            get { return _selectedProject; }
            set
            {
                _selectedProject = value;
                RaisePropertyChanged("SelectedProject");
            }
        }

        private IEnumerable<CommandBase> _views;

        public IEnumerable<CommandBase> Views
        {
            get { return _views; }
            set
            {
                _views = value;
                RaisePropertyChanged("Views");
            }
        }

        private IEnumerable<CommandBase> _projects;

        public IEnumerable<CommandBase> Projects
        {
            get { return _projects; }
            set
            {
                _projects = value;
                RaisePropertyChanged("Projects");
            }
        }
    }
}
