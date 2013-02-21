using System.Collections.ObjectModel;
using BookShelf.Web.Models;

namespace BookShelf
{
    public class DesignCategories : ObservableCollection<Category>
    {
        public DesignCategories()
        {
            for (int i = 0; i < 10; i++)
            {
                Add(new Category()
                    {
                        CategoryID = i,
                        CategoryName = "Technical " + i,
                    });
            }
        }
    }
}