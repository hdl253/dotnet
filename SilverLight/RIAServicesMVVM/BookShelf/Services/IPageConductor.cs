using System;
using BookShelf.Web.Models;

namespace BookShelf  
{
    public interface IPageConductor
    {
        void DisplayError(string origin, Exception e, string details);
        void DisplayError(string origin, Exception e);
        void GoToView(string viewToken);
        //void GoToTweetDetailView(string viewToken, string stateKey, Tweet tweet);
        //void GoToNewTweetView(string viewToken, string stateKey, TweetType tweetType, string text, long replyToId);
        void GoToCheckoutView(string viewToken, string stateKey, Book book);
        void GoBack();

        void PushState(string key, object value);
        T PopState<T>(string key) where T : class;
        T PeekState<T>(string key) where T : class;
        //void ShowEditBook(Book selectedBook);
    }
}