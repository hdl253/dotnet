using System;
using System.Collections.Generic;
using BookShelf.Web.Models;

namespace BookShelf
{
    public class DesignPageConductor : IPageConductor
    {
        protected Dictionary<string, object> State = new Dictionary<string, object>();

        public DesignPageConductor()
        {
        }

        public void GoToCheckoutView(string viewToken, string stateKey, Book book)
        {
            return;
        }

        //public void GoToNewTweetView(string viewToken, string stateKey, TweetType tweetType, string text, long replyToId)
        //{
        //    return;
        //}

        public void DisplayError(string origin, Exception e, string details)
        {
            return;
        }

        public void DisplayError(string origin, Exception e)
        {
            return;
        }

        public void GoToView(string viewToken)
        {
            return;
        }

        //public void GoToTweetDetailView(string viewToken, string stateKey, Tweet tweet)
        //{
        //    return;
        //}

        public void GoBack()
        {
            return;
        }

        public void PushState(string key, object value)
        {
            State[key] = value;
        }

        public T PopState<T>(string key) where T : class
        {
            //if (typeof(T) == typeof(Tweet))
            //{
            //    return new DesignTweet() as T;
            //}
            //if (typeof(T) == typeof(NewTweet))
            //{
            //    return new DesignNewTweet() as T;
            //}
            //if (typeof(T) == typeof(Error))
            //{
            //    return new DesignError() as T;
            //}
            //if (typeof(T) == typeof(User))
            //{
            //    return new DesignUser() as T;
            //}            
            //if (typeof(T) == typeof(string))
            //{
            //    return "silverlight" as T;
            //}
            return PeekState<T>(key);
        }

        public T PeekState<T>(string key) where T : class
        {
            object value;
            State.TryGetValue(key, out value);
            return value as T;
        }

        //public void ShowEditBook(Book selectedBook)
        //{
        //    return;
        //}
    }
}