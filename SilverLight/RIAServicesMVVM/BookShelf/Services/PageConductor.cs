using System;
using System.Windows.Controls;
using BookShelf.Web.Models;
using GalaSoft.MvvmLight.Messaging;
using Papa.Common;

namespace BookShelf
{
    public class PageConductor : IPageConductor
    {
        protected readonly StateQueue StateQueue = new StateQueue();
        protected Frame RootFrame { get; set; }

        public PageConductor()
        {
            Messenger.Default.Register<FrameMessage>(this, OnReceiveFrameMessage);
        }

        private void OnReceiveFrameMessage(FrameMessage msg)
        {
            RootFrame = msg.RootFrame;
        }

        public void DisplayError(string origin, Exception e, string details)
        {
            string description = string.Format("Error occured in {0}. {1} {2}", origin, details, e.Message);
            var error = new Error() {Description = description, Title = "Error Occurred"};
            PushState(ViewTokens.ErrorOverlay, error);
            Messenger.Default.Send(new ErrorMessage() { Error = error });
        }
        
        public void DisplayError(string origin, Exception e)
        {
            DisplayError(origin, e, string.Empty);
        }

        public void PushState(string key, object value)
        {
            StateQueue.PushState(key, value);
        }

        public T PopState<T>(string key) where T : class
        {
            return StateQueue.PopState<T>(key);
        }

        public T PeekState<T>(string key) where T : class
        {
            return StateQueue.PeekState<T>(key);
        }

        public void GoToCheckoutView(string viewToken, string stateKey, Book book)
        {
            PushState(stateKey, book);
            Go(FormatViewPath(viewToken, stateKey));
        }

        //public void GoToNewTweetView(string viewToken, string stateKey, TweetType tweetType, string text, long replyToId)
        //{
        //    var tweet = new NewTweet { TweetType = tweetType, Message = text, ReplyToId = replyToId };
        //    PushState(stateKey, tweet);
        //    Go(FormatViewPath(viewToken, stateKey));
        //}

        public void GoToView(string viewToken)
        {
            Go(FormatViewPath(viewToken));
        }

        //public void GoToTweetDetailView(string viewToken, string stateKey, Tweet tweet)
        //{
        //    PushState(stateKey, tweet);
        //    Go(FormatViewPath(viewToken, stateKey));
        //}

        public void GoBack()
        {
            RootFrame.GoBack();
        }

        private void Go(string path)
        {
            RootFrame.Navigate(new Uri(path, UriKind.Relative));
        }

        private string FormatViewPath(string viewToken)
        {
            return string.Format("/{0}/{1}.xaml", ViewTokens.Root, viewToken);
        }

        private string FormatViewPath(string viewToken, string stateKey)
        {
            return string.Format("/{0}/{1}.xaml?{2}={3}", ViewTokens.Root, viewToken, Core.StateKeyParameter, stateKey);
        }
    }
}