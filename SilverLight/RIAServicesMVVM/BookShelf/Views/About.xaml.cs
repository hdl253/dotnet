namespace BookShelf
{
    using System.Windows.Controls;
    using System.Windows.Navigation;

    public partial class About : Page
    {
        public About()
        {
            InitializeComponent();
            this.Title = ApplicationStrings.AboutPageTitle;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}