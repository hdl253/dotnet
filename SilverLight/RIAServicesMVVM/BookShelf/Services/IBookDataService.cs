using System;
using System.ServiceModel.DomainServices.Client;
using BookShelf.Web.Models;
using Microsoft.Windows.Data.DomainServices;
using Papa.Common;
using Ria.Common;

namespace BookShelf
{
    public interface IBookDataService
    {
        EntityContainer EntityContainer { get; }

        void SubmitChanges(Action<ServiceSubmitChangesResult> callback, object state);

        void LoadBooksByCategory(int categoryId, QueryBuilder<Book> query, Action<ServiceLoadResult<Book>> callback, object state);
        void LoadBooksOfTheDay(Action<ServiceLoadResult<BookOfDay>> callback, object state);
        void LoadCategories(Action<ServiceLoadResult<Category>> callback, object state);
        void LoadCheckouts(Action<ServiceLoadResult<Checkout>> callback, object state);
    }
}