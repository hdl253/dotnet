using System;
using System.Collections.Generic;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using BookShelf.Web.Models;
using BookShelf.Web.Services;
using Microsoft.Windows.Data.DomainServices;
using Papa.Common;
using Ria.Common;

namespace BookShelf
{
    public class DesignBookDataService : IBookDataService
    {
        private readonly EntityContainer _entityContainer = new BookClubContext.BookClubContextEntityContainer();

        public EntityContainer EntityContainer
        {
            get { return this._entityContainer; }
        }

        public void SubmitChanges(Action<ServiceSubmitChangesResult> callback, object state)
        {
            throw new NotImplementedException("SubmitChanges shouldn't be called at design-time.");
        }

        public void LoadBooksByCategory(int categoryId, QueryBuilder<Book> query, Action<ServiceLoadResult<Book>> callback, object state)
        {
            this.Load(query.ApplyTo(new DesignBooks()), callback, state);
        }

        public void LoadBooksOfTheDay(Action<ServiceLoadResult<BookOfDay>> callback, object state)
        {
            this.Load(new DesignBooksOfTheDay(), callback, state);
        }

        public void LoadCategories(Action<ServiceLoadResult<Category>> callback, object state)
        {
            this.Load(new DesignCategories(), callback, state);
        }

        public void LoadCheckouts(Action<ServiceLoadResult<Checkout>> callback, object state)
        {
            this.Load(new DesignCheckouts(), callback, state);
        }

        private void Load<T>(IEnumerable<T> entities, Action<ServiceLoadResult<T>> callback, object state) where T : Entity
        {
            this.EntityContainer.LoadEntities(entities);
            callback(new ServiceLoadResult<T>(entities, state));
        }
    }
}