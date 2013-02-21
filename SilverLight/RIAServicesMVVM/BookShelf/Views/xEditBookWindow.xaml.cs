using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using GalaSoft.MvvmLight.Messaging;

namespace BookShelf.Views
{
    public partial class EditBookWindow : ChildWindow
    {
        public EditBookWindow()
        {
            InitializeComponent();
        }

        //void EditBookWindow_Loaded(object sender, RoutedEventArgs e)
        //{
        //    IEditableObject book = (IEditableObject)this.DataContext;
        //    book.BeginEdit();
        //}

        //private void OKButton_Click(object sender, RoutedEventArgs e)
        //{

        //    IEditableObject book = (IEditableObject)this.DataContext;
        //    book.EndEdit();
        //    this.DialogResult = true;
        //}

        //private void CancelButton_Click(object sender, RoutedEventArgs e)
        //{
        //    IEditableObject book = (IEditableObject)this.DataContext;
        //    book.CancelEdit();
        //    this.DialogResult = false;
        //}
    }
}