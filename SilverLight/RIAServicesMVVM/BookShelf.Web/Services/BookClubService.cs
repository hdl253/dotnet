
namespace BookShelf.Web.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using BookShelf.Web.Models;


    // Implements application logic using the BookClubEntities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class BookClubService : LinqToEntitiesDomainService<BookClubEntities>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Books' query.
        public IQueryable<Book> GetBooks()
        {
            return this.ObjectContext.Books.Include("Categories").OrderBy(b => b.Title);
        }

        public void InsertBook(Book book)
        {
            if ((book.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(book, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Books.AddObject(book);
            }
        }

        public void UpdateBook(Book currentBook)
        {
            this.ObjectContext.Books.AttachAsModified(currentBook, this.ChangeSet.GetOriginal(currentBook));
        }

        public void DeleteBook(Book book)
        {
            if ((book.EntityState == EntityState.Detached))
            {
                this.ObjectContext.Books.Attach(book);
            }
            this.ObjectContext.Books.DeleteObject(book);
        }

        public IQueryable<Book> GetBooksByCategory(int CategoryID)
        {
            return this.ObjectContext.Books.Include("Category").Where(b => b.CategoryID == CategoryID).OrderBy(b => b.Title);
        }
        
        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'BookOfDays' query.
        public IQueryable<BookOfDay> GetBookOfDays()
        {
            return this.ObjectContext.BookOfDays.Include("Book").OrderByDescending(b => b.Day).Take(1);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Categories' query.
        public IQueryable<Category> GetCategories()
        {
            return this.ObjectContext.Categories.OrderBy(c => c.CategoryName);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Checkouts' query.
        public IQueryable<Checkout> GetCheckouts()
        {
            var query = from checkout in ObjectContext.Checkouts.Include("Book").Include("Member")
                        orderby checkout.CheckoutDate descending
                        select checkout;

            return query;
        }

        public void InsertCheckout(Checkout checkout)
        {
            if ((checkout.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(checkout, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Checkouts.AddObject(checkout);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Members' query.
        public IQueryable<Member> GetMembers()
        {
            return this.ObjectContext.Members;
        }
    }
}
