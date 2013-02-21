using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace BookShelf
{
    internal class FrameMessage : MessageBase
    {
        public Frame RootFrame { get; set; }
    }
}