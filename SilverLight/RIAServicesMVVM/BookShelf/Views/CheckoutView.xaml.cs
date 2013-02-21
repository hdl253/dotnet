using System.Windows.Controls;
using System.Windows.Navigation;

namespace BookShelf
{
    public partial class CheckoutView : Page
    {
        public CheckoutView()
        {
            InitializeComponent();

            this.Title = ApplicationStrings.CheckoutPageTitle;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}