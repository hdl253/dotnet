using System;

namespace BookShelf.Old
{
    public class HasChangesEventArgs : EventArgs
    {
        public bool HasChanges { get; set; }
    }
}