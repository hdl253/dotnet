using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceModel.DomainServices.Client;

namespace Ria.Common
{
    public class ServiceSubmitChangesResult : AsyncCompletedEventArgs
    {
        private readonly EntityChangeSet _changeSet;
        private readonly IEnumerable<Entity> _entitiesInError;

        public ServiceSubmitChangesResult(
            EntityChangeSet changeSet,
            IEnumerable<Entity> entitiesInError,
            Exception error,
            bool cancelled,
            object userState)
            : base(error, cancelled, userState)
        {
            if (changeSet == null)
            {
                throw new ArgumentNullException("changeSet");
            }
            if (entitiesInError == null)
            {
                throw new ArgumentNullException("entitiesInError");
            }

            this._changeSet = changeSet;
            this._entitiesInError = entitiesInError;
        }

        public EntityChangeSet ChangeSet
        {
            get { return this._changeSet; }
        }

        public IEnumerable<Entity> EntitiesInError
        {
            get { return this._entitiesInError; }
        }
    }
}
