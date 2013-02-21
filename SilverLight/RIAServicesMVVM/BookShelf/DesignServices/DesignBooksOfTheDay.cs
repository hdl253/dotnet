using System;
using System.Collections.ObjectModel;
using BookShelf.Web.Models;

namespace BookShelf
{
    public class DesignBooksOfTheDay : ObservableCollection<BookOfDay>
    {
        public DesignBooksOfTheDay()
        {
            this.Add(CreateDesignBookOfTheDay());
        }

        private BookOfDay CreateDesignBookOfTheDay()
        {
            return new BookOfDay()
                       {
                           BookID = 123,
                           Day = DateTime.Today,
                           Book = new DesignBooks()[0],
                       };
        }
    }
}