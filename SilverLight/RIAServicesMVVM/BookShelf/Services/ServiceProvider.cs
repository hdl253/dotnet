namespace BookShelf
{
    public class ServiceProvider : ServiceProviderBase
    {
        public ServiceProvider()
        {
            // Do this if you want one service for your app.
            //PageConductor = new PageConductor(); 
        }

        // Do this if you want one service per VM instance for your app.
        public override IPageConductor PageConductor
        {
            get { return new PageConductor(); }
        }

        public override IBookDataService BookDataService
        {
            get { return new BookDataService(); }
        }
    }
}