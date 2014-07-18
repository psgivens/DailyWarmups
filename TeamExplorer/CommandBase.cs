using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamExplorer
{
    public class CommandBase : ViewModelBase
    {
        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged("Title");
            }
        }

    }
}
