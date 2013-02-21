using System;
using System.Collections.ObjectModel;
using System.ServiceModel.DomainServices.Client;
using BookShelf.Web.Models;

namespace BookShelf.Old
{
    public interface IBookDataService
    {
        event EventHandler<HasChangesEventArgs> NotifyHasChanges;	

        void Save(Action<SubmitOperation> submitCallback, object state);

        void GetBooksByCategory(
            Action<ObservableCollection<Book>> getBooksCallback,
            int categoryID, 
            int pageSize);
        void GetMoreBooksByCategory(
            Action<ObservableCollection<Book>> getBooksCallback,
            int categoryID, 
            int pageSize);

        void GetBooksByTitle(
            Action<ObservableCollection<Book>> getBooksCallback, 
            int categoryID, 
            string titleFilter);

        void GetBooksOfTheDay(Action<ObservableCollection<BookOfDay>> getBooksOfTheDayCallback);
        void GetCategories(Action<ObservableCollection<Category>> getCategoriesCallback);
        void GetCheckouts(Action<ObservableCollection<Checkout>> getCheckoutsCallback);
    }
}