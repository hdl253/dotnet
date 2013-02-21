using BookShelf.Web.Models;
using GalaSoft.MvvmLight.Messaging;

namespace BookShelf
{
    internal class LaunchEditBookMessage : MessageBase
    {
        public Book Book { get; set; }
    }
}