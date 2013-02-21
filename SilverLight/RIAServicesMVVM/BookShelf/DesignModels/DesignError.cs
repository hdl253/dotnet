namespace BookShelf  
{
    public class DesignError : Error
    {
        public DesignError()
        {
            Description = "An error has occured. Your computer is about to explode. Run for the exits!";
            Title = "An Error Has Occurred";
        }
    }
}