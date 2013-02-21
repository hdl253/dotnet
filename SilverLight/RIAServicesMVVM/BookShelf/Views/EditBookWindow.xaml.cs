using System.Windows;
using System.Windows.Controls;

namespace BookShelf
{
    public partial class EditBookWindow : ChildWindow
    {
        public EditBookWindow()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

