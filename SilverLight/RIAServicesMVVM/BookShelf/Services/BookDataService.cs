using System;
using System.Collections.Generic;
using System.ServiceModel.DomainServices.Client;
using BookShelf.Web.Models;
using BookShelf.Web.Services;
using Microsoft.Windows.Data.DomainServices;
using Papa.Common;
using Ria.Common;

namespace BookShelf
{
    public class BookDataService : IBookDataService
    {
        private readonly IDictionary<Type, LoadOperation> _pendingLoads = new Dictionary<Type, LoadOperation>();
        private readonly BookClubContext _context = new BookClubContext();

        public BookDataService()
        {
        }

        public EntityContainer EntityContainer
        {
            get { return this._context.EntityContainer; }
        }

        public void SubmitChanges(Action<ServiceSubmitChangesResult> callback, object state)
        {
            this._context.SubmitChanges(so =>
                {
                    callback(this.CreateResult(so));
                }, state);
        }

        public void LoadBooksByCategory(int categoryId, QueryBuilder<Book> query, Action<ServiceLoadResult<Book>> callback, object state)
        {
            this.Load(query.ApplyTo(this._context.GetBooksByCategoryQuery(categoryId)), lo =>
                {
                    callback(this.CreateResult(lo, true));
                }, state);
        }

        public void LoadBooksOfTheDay(Action<ServiceLoadResult<BookOfDay>> callback, object state)
        {
            this.Load(this._context.GetBookOfDaysQuery(), lo =>
                {
                    callback(this.CreateResult(lo));
                }, state);
        }

        public void LoadCategories(Action<ServiceLoadResult<Category>> callback, object state)
        {
            this.Load(this._context.GetCategoriesQuery(), lo =>
                {
                    callback(this.CreateResult(lo));
                }, state);
        }

        public void LoadCheckouts(Action<ServiceLoadResult<Checkout>> callback, object state)
        {
            this.Load(this._context.GetCheckoutsQuery(), lo =>
                {
                    callback(this.CreateResult(lo));
                }, state);
        }

        private void Load<T>(EntityQuery<T> query, Action<LoadOperation<T>> callback, object state) where T : Entity
        {
            if (this._pendingLoads.ContainsKey(typeof(T)))
            {
                this._pendingLoads[typeof(T)].Cancel();
                this._pendingLoads.Remove(typeof(T));
            }

            this._pendingLoads[typeof(T)] = this._context.Load(query, lo =>
                {
                    this._pendingLoads.Remove(typeof(T));
                    callback(lo);
                }, state);
        }

        private ServiceSubmitChangesResult CreateResult(SubmitOperation op)
        {
            if (op.HasError)
            {
                op.MarkErrorAsHandled();
            }
            return new ServiceSubmitChangesResult(
                op.ChangeSet,
                op.EntitiesInError,
                op.Error,
                op.IsCanceled,
                op.UserState);
        }

        private ServiceLoadResult<T> CreateResult<T>(LoadOperation<T> op, bool returnEditableCollection = false) where T : Entity
        {
            if (op.HasError)
            {
                op.MarkErrorAsHandled();
            }
            return new ServiceLoadResult<T>(
                returnEditableCollection ? new EntityList<T>(this.EntityContainer.GetEntitySet<T>(), op.Entities) : op.Entities,
                op.TotalEntityCount,
                op.ValidationErrors,
                op.Error,
                op.IsCanceled,
                op.UserState);
        }
    }
}