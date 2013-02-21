using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows.Navigation;
using GalaSoft.MvvmLight.Messaging;

namespace BookShelf
{
    public partial class BookView : Page
    {
        public BookView()
        {
            InitializeComponent();
            //btnEdit.SetBinding(Button.IsEnabledProperty, new Binding("User.IsAuthenticated") { Source = Application.Current.Resources["WebContext"] });
            Title = ApplicationStrings.HomePageTitle;
            RegisterMessages();
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<LaunchEditBookMessage>(this, OnLaunchEditBook);
            Messenger.Default.Register<SavedBookDialogMessage>(this, OnSaveBookDialogMessageReceived);
        }

        private void OnLaunchEditBook(LaunchEditBookMessage msg)
        {
            var editBook = new EditBookWindow();
            editBook.Show();
        }

        private void OnSaveBookDialogMessageReceived(SavedBookDialogMessage msg)
        {
            MessageBox.Show(msg.Content, msg.Caption, msg.Button);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}