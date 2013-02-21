using System;
using System.Collections.ObjectModel;
using BookShelf.Web.Models;

namespace BookShelf
{
    public class DesignCheckouts : ObservableCollection<Checkout>
    {
        private Book _designBook;
        private Member _designMember = 
            new Member(){MemberName = "John Papa", MemberID = 7};

        public DesignCheckouts()
        {
            for (int i = 0; i < 20; i++)
            {
                Add(CreateDesignCheckout(i));
            }
        }

        private Checkout CreateDesignCheckout(int i)
        {
            _designBook = new DesignBooks()[0];
            var checkout = new Checkout()
                               {
                                   Book = _designBook,
                                   CheckoutDate = DateTime.Today.AddDays(-i),
                                   Member = _designMember,
                                   Notes = string.Format("Read the book {0} times", i),
                               };
            return checkout;
        }
    }
}