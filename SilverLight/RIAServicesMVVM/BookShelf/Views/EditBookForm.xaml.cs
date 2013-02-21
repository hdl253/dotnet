using System.Windows;
using System.Windows.Controls;

namespace BookShelf.Views
{
    public partial class EditBookForm : StackPanel
    {
        public EditBookForm()
        {
            InitializeComponent();
        }

        private void editForm_AutoGeneratingField(object sender, DataFormAutoGeneratingFieldEventArgs e)
        {
            if (e.PropertyName == "MemberID" || e.PropertyName == "BookID" || e.PropertyName == "Category" || e.PropertyName == "CategoryID" || e.PropertyName == "BookOfDays")
            {
                e.Cancel = true ;
            }
            if (e.PropertyName == "Description")
            {
                TextBox textDesc = (TextBox)e.Field.Content;
                textDesc.AcceptsReturn = true;
            }
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
