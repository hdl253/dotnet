namespace Papa.Common
{
    public class IsBusyMessage
    {
        public bool IsBusy { get; private set; }

        public IsBusyMessage(bool isBusy)
        {
            IsBusy = isBusy;
        }
    }
}