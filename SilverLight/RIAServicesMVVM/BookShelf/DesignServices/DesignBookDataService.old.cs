using System;
using System.Collections.ObjectModel;
using System.ServiceModel.DomainServices.Client;
using BookShelf.Web.Models;

namespace BookShelf.Old
{
    public class DesignBookDataService : IBookDataService
    {
        public event EventHandler<HasChangesEventArgs> NotifyHasChanges;

        public void Save(Action<SubmitOperation> submitCallback, object state)
        {
            submitCallback(null);
        }

        public void GetBooksByCategory(Action<ObservableCollection<Book>> getBooksCallback, int categoryID, int pageSize)
        {
            getBooksCallback(new DesignBooks());
        }

        public void GetMoreBooksByCategory(Action<ObservableCollection<Book>> getBooksCallback, int categoryID, int pageSize)
        {
            getBooksCallback(new DesignBooks());
        }

        public void GetBooksByTitle(Action<ObservableCollection<Book>> getBooksCallback, int categoryID, string titleFilter)
        {
            getBooksCallback(new DesignBooks());
        }

        public void GetBooksOfTheDay(Action<ObservableCollection<BookOfDay>> getBooksOfTheDayCallback)
        {
            getBooksOfTheDayCallback(new DesignBooksOfTheDay());
        }

        public void GetCategories(Action<ObservableCollection<Category>> getCategoriesCallback)
        {
            getCategoriesCallback(new DesignCategories());
        }

        public void GetCheckouts(Action<ObservableCollection<Checkout>> getCheckoutsCallback)
        {
            getCheckoutsCallback(new DesignCheckouts());
        }

        private void OnNotifyHasChanges(HasChangesEventArgs e)
        {
            this.NotifyHasChanges(this, e);
        }
    }
}