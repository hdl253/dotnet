using System.Windows;
using GalaSoft.MvvmLight.Messaging;

namespace BookShelf
{
    internal class SavedBookDialogMessage : DialogMessage
    {
        public SavedBookDialogMessage(string content, string title)
            : base(content, null)
        {
            Button = MessageBoxButton.OK;
            Caption = title;
        }
    }
}