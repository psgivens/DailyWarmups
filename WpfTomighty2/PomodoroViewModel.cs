using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfTomighty
{
    public class PomodoroViewModel : ViewModelBase
    {
        private string _clockDisplay;
        private Timer _timer;
        private DateTime _startTime = DateTime.Now;
        private PomodoroState _state;
        private int _expectedElapsedTime;

        private enum PomodoroState
        {
            Interim,
            Pomodoro,
            PomodoroFinished,
            Break,
        }

        public PomodoroViewModel()
        {
            _timer = new Timer(TimerCallback);
            _clockDisplay = TimeSpan.FromMinutes(_expectedElapsedTime).ToString(@"mm\:ss");
            StartClockCommand = new ActionCommand(this, StartClock, "State", _ => _.State == PomodoroState.Interim || _.State == PomodoroState.PomodoroFinished);
            StopClockCommand = new ActionCommand(this, StopClock, "State", _ => _.State == PomodoroState.Pomodoro || _.State == PomodoroState.Break);
        }

        public string ClockDisplay
        {
            get { return _clockDisplay; }
            set
            {
                _clockDisplay = value;
                RaisePropertyChanged("ClockDisplay");
            }
        }

        private void TimerCallback(object state)
        {
            var currentTime = (TimeSpan.FromMinutes(_expectedElapsedTime) - (DateTime.Now - _startTime));
            if (currentTime <= TimeSpan.Zero)
            {
                currentTime = TimeSpan.Zero;
                _timer.Change(Timeout.Infinite, Timeout.Infinite);
            }
            ClockDisplay = currentTime.ToString(@"mm\:ss");

        }

        public void StartClock()
        {
            _startTime = DateTime.Now;
            _timer.Change(0, 1000);

            switch (_state)
            {
                case PomodoroState.PomodoroFinished:
                    _expectedElapsedTime = 5;
                    State = PomodoroState.Break;
                    break;
                case PomodoroState.Interim:
                    _expectedElapsedTime = 25;
                    State = PomodoroState.Pomodoro;
                    break;
                case PomodoroState.Pomodoro:
                case PomodoroState.Break:
                default:
                    break;
            }
        }

        public void StopClock()
        {
            _expectedElapsedTime = 0;
            _startTime = DateTime.Now;
            _timer.Change(0, 1000);

            switch (_state)
            {
                case PomodoroState.Pomodoro:
                    State = PomodoroState.PomodoroFinished;
                    break;
                case PomodoroState.Break:
                    State = PomodoroState.Interim;
                    break;
                case PomodoroState.PomodoroFinished:
                case PomodoroState.Interim:
                default:
                    break;
            }
        }


        public System.Windows.Input.ICommand StartClockCommand { get; private set; }
        public System.Windows.Input.ICommand StopClockCommand { get; private set; }

        private PomodoroState State
        {
            get { return _state; }
            set
            {
                _state = value;
                RaisePropertyChanged("State");
            }
        }


        private class ActionCommand : System.Windows.Input.ICommand
        {
            private readonly PomodoroViewModel _viewModel;
            private readonly Action _action;
            private readonly Predicate<PomodoroViewModel> _canExecute;
            public ActionCommand(PomodoroViewModel viewModel, Action action, string propertyName, Predicate<PomodoroViewModel> canExecute)
            {
                _viewModel = viewModel;
                _action = action;
                _canExecute = canExecute;
                _viewModel.PropertyChanged += (s, e) =>
                {
                    if (e.PropertyName == propertyName
                        && CanExecuteChanged != null)
                        CanExecuteChanged(this, EventArgs.Empty);
                };
            }

            void _viewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
            {
            }

            bool System.Windows.Input.ICommand.CanExecute(object parameter)
            {
                return _canExecute(_viewModel);
            }

            public event EventHandler CanExecuteChanged;

            void System.Windows.Input.ICommand.Execute(object parameter)
            {
                _action();
            }
        }


    }
}
