using System;
using System.Collections.ObjectModel;
using System.ServiceModel.DomainServices.Client;
using BookShelf.Web.Models;
using BookShelf.Web.Services;
using Microsoft.Windows.Data.DomainServices;

namespace BookShelf.Old
{
    public class BookDataService : IBookDataService
    {
        private LoadOperation<Book> _booksLoadOperation;
        private LoadOperation<Category> _categoriesLoadOperation;
        private LoadOperation<BookOfDay> _booksOfTheDayLoadOperation;
        private LoadOperation<Checkout> _checkoutLoadOperation;
        private Action<ObservableCollection<Book>> _getBooksCallback;
        private Action<ObservableCollection<BookOfDay>> _getBooksOfTheDayCallback;
        private Action<ObservableCollection<Category>> _getCategoriesCallback;
        private Action<ObservableCollection<Checkout>> _getCheckoutsCallback;
        private int _pageIndex = 0;
        private BookClubContext Context { get; set; }
        public event EventHandler<HasChangesEventArgs> NotifyHasChanges;	 

        public BookDataService()
        {
            Context = new BookClubContext();
            Context.PropertyChanged += ContextPropertyChanged;
        }

        public void GetCheckouts(Action<ObservableCollection<Checkout>> getCheckoutsCallback)
        {
            ClearBooks();
            var query = Context.GetCheckoutsQuery();
            _getCheckoutsCallback = getCheckoutsCallback;
            _checkoutLoadOperation = Context.Load<Checkout>(query);
            _checkoutLoadOperation.Completed += OnLoadCheckoutsCompleted;
        }

        private void OnLoadCheckoutsCompleted(object sender, EventArgs e)
        {
            _checkoutLoadOperation.Completed -= OnLoadCheckoutsCompleted;
            var checkouts = new EntityList<Checkout>(Context.Checkouts, _checkoutLoadOperation.Entities);
            _getCheckoutsCallback(checkouts);
        }

        private void ContextPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (NotifyHasChanges != null)
            {
                NotifyHasChanges(this, new HasChangesEventArgs(){HasChanges  = Context.HasChanges});
            }
        }

        public void Save(Action<SubmitOperation> submitCallback, object state)
        {
            if (Context.HasChanges)
            {
                Context.SubmitChanges(submitCallback, state);
            }
        }

        public void GetBooksByCategory(
            Action<ObservableCollection<Book>> getBooksCallback,
            int categoryID, 
            int pageSize)
        {
            ClearBooks();
            var query = Context.GetBooksByCategoryQuery(categoryID).Take(pageSize);
            RunBooksQuery(query, getBooksCallback);
        }

        public void GetMoreBooksByCategory(
            Action<ObservableCollection<Book>> 
                getBooksCallback,
            int categoryID, int pageSize)
        {
            _pageIndex++;
            var query = Context.GetBooksByCategoryQuery(categoryID).Skip(_pageIndex * pageSize).Take(pageSize);
            RunBooksQuery(query, getBooksCallback);
        }

        public void GetBooksByTitle(Action<ObservableCollection<Book>> getBooksCallback, int categoryID, string titleFilter)
        {
            ClearBooks();
            var query = Context.GetBooksByCategoryQuery(categoryID)
                .Where(b => b.Title.Contains(titleFilter));
            RunBooksQuery(query, getBooksCallback);
        }

        private void ClearBooks()
        {
            _pageIndex = 0;
            Context.Books.Clear();
        }

        private void RunBooksQuery(EntityQuery<Book> query, Action<ObservableCollection<Book>> getBooksCallback)
        {
            _getBooksCallback = getBooksCallback;
            _booksLoadOperation = Context.Load<Book>(query);
            _booksLoadOperation.Completed += OnLoadBooksCompleted;
        }

        private void OnLoadBooksCompleted(object sender, EventArgs e)
        {
            _booksLoadOperation.Completed -= OnLoadBooksCompleted;
            var books = new EntityList<Book>(Context.Books, _booksLoadOperation.Entities);
            _getBooksCallback(books);
        }

        public void GetBooksOfTheDay(Action<ObservableCollection<BookOfDay>> getBooksOfTheDayCallback)
        {
            _getBooksOfTheDayCallback = getBooksOfTheDayCallback;
            Context.BookOfDays.Clear();
            _booksOfTheDayLoadOperation = Context.Load<BookOfDay>(Context.GetBookOfDaysQuery());
            _booksOfTheDayLoadOperation.Completed += OnLoadBookOfTheDayCompleted;
        }

        private void OnLoadBookOfTheDayCompleted(object o, EventArgs e)
        {
            _booksOfTheDayLoadOperation.Completed -= OnLoadBookOfTheDayCompleted;
            var booksOfTheDay = new EntityList<BookOfDay>(Context.BookOfDays, _booksOfTheDayLoadOperation.Entities);
            _getBooksOfTheDayCallback(booksOfTheDay);
        }

        public void GetCategories(Action<ObservableCollection<Category>> getCategoriesCallback)
        {
            _getCategoriesCallback = getCategoriesCallback;
            Context.Categories.Clear();
            _categoriesLoadOperation = Context.Load<Category>(Context.GetCategoriesQuery());
            _categoriesLoadOperation.Completed += OnLoadCategoriesCompleted;
        }

        private void OnLoadCategoriesCompleted(object sender, EventArgs e)
        {
            _categoriesLoadOperation.Completed -= OnLoadCategoriesCompleted;
            var categories = new EntityList<Category>(Context.Categories, _categoriesLoadOperation.Entities);
            _getCategoriesCallback(categories);
        }
    }
}