using System.ComponentModel;

namespace BookShelf
{
    public abstract class ServiceProviderBase
    {
        public virtual IPageConductor PageConductor { get; protected set; }
        public virtual IBookDataService BookDataService { get; protected set; }

        private static ServiceProviderBase _instance;
        public static ServiceProviderBase Instance
        {
            get { return _instance ?? CreateInstance(); }
        }

        static ServiceProviderBase CreateInstance()
        {
            // TODO:  Uncomment
            return _instance = DesignerProperties.IsInDesignTool ?
                (ServiceProviderBase)new DesignServiceProvider() : new ServiceProvider();
            
            // TODO:  Comment
            // return _instance = new ServiceProvider();
        }
    }
}