using System.Windows;
using GalaSoft.MvvmLight.Messaging;

namespace BookShelf
{
    internal class SavedCheckoutDialogMessage : DialogMessage
    {
        public SavedCheckoutDialogMessage(string content, string title)
            : base(content, null)
        {
            Button = MessageBoxButton.OK;
            Caption = title;
        }
    }
}