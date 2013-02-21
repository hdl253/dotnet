using GalaSoft.MvvmLight.Messaging;

namespace BookShelf
{
    internal class ErrorMessage : MessageBase
    {
        public Error Error { get; set; }
    }
}