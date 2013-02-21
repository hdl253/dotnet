using GalaSoft.MvvmLight.Messaging;

namespace Papa.Common
{
    public abstract class ViewModel : NotifiableObject
    {
        private bool _isBusy;
        private int _serviceCallCounter;

        protected ViewModel()
        {
            IsBusy = false;
            ServiceCallCounter = 0;
            TotalServiceCalls = 0;

            RegisterCommands();
            RegisterMessages();
        }

        protected int TotalServiceCalls { get; set; }

        protected int ServiceCallCounter
        {
            get { return _serviceCallCounter; }
            set
            {
                _serviceCallCounter = value;
                if (_serviceCallCounter >= TotalServiceCalls)
                {
                    IsBusy = false;
                    _serviceCallCounter = 0; 
                }
            }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                RaisePropertyChanged("IsBusy");
                Messenger.Default.Send(new IsBusyMessage(_isBusy));
            }
        }

        public virtual void LoadData() { }

        protected virtual void RegisterCommands() { }

        protected virtual void RegisterMessages() { }

        protected void ResetServiceCalls()
        {
            SmartDispatcher.BeginInvoke(() =>
            {
                ServiceCallCounter = TotalServiceCalls = 0;
                IsBusy = false;
            });
        }
    }
}