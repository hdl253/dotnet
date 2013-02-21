namespace BookShelf
{
    public class DesignServiceProvider : ServiceProviderBase
    {
        public DesignServiceProvider()
        {
            PageConductor = new DesignPageConductor(); 
            BookDataService = new DesignBookDataService(); 
        }        
    }
}