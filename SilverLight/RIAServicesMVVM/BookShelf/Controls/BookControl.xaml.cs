using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BookShelf.Controls
{
    public partial class BookControl : UserControl
    {
        public BookControl()
        {
            InitializeComponent();
            this.btnEdit.SetBinding(Button.IsEnabledProperty, new Binding("User.IsAuthenticated") { Source = App.Current.Resources["WebContext"] });
            this.btnEdit.SetBinding(Button.VisibilityProperty,
                                    new Binding("DataContext")
                                        {Source = this, Converter = new VisibleWhenBoundConverter()});
          
            //if (DesignerProperties.IsInDesignTool)
            //{
            //    this.txbASIN.Text = "0000000000";
            //    this.txbAuthor.Text = "the gu";
                
            //    this.txbPublishedDate.Text = DateTime.Now.ToShortDateString();
            //    this.txbTitle.Text = "Visual Studio 2010 Launch";

            //    this.txbDescription.Text = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Proin turpis. Etiam ante tortor, ultrices vitae, fringilla sollicitudin, sagittis a, ante. Quisque luctus, magna vitae elementum mattis, dui massa ultricies ligula, eget posuere orci est vitae neque. Nam interdum molestie tellus. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin euismod euismod nunc. Praesent pretium sem in dolor. Maecenas velit ante, varius eu, volutpat ut, consequat ut, orci. Cras laoreet. Sed turpis. Mauris laoreet orci non diam.  Pellentesque consectetuer imperdiet neque. Aliquam sed nibh eget libero sodales imperdiet. Proin placerat faucibus enim. Nullam ante. Praesent venenatis. ";
            //}

            

        }

        //private void btnEdit_Click(object sender, RoutedEventArgs e)
        //{
        //    EditBookWindow editBook = new EditBookWindow();
        //    editBook.DataContext = this.DataContext;
        //    editBook.Show();
        //}
    }
}
