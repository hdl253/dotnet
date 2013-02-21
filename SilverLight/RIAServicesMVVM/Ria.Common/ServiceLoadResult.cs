using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ServiceModel.DomainServices.Client;

namespace Ria.Common
{
    public abstract class ServiceLoadResult : AsyncCompletedEventArgs
    {
        private readonly IEnumerable _entities;
        private readonly int _totalEntityCount;
        private readonly IEnumerable<ValidationResult> _validationErrors;

        protected ServiceLoadResult(
            IEnumerable entities,
            int totalEntityCount,
            IEnumerable<ValidationResult> validationErrors,
            Exception error,
            bool cancelled,
            object userState)
            : base(error, cancelled, userState)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entities");
            }
            if (validationErrors == null)
            {
                throw new ArgumentNullException("validationErrors");
            }

            this._entities = entities;
            this._totalEntityCount = totalEntityCount;
            this._validationErrors = validationErrors;
        }

        public IEnumerable Entities
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return this._entities;
            }
        }

        public int TotalEntityCount
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return this._totalEntityCount;
            }
        }

        public IEnumerable<ValidationResult> ValidationErrors
        {
            get { return this._validationErrors; }
        }
    }

    public class ServiceLoadResult<T> : ServiceLoadResult where T : Entity
    {
        public ServiceLoadResult(IEnumerable<T> entities, object userState)
            : this(entities, entities.Count(), Enumerable.Empty<ValidationResult>(), null, false, userState)
        {
        }

        public ServiceLoadResult(
            IEnumerable<T> entities,
            int totalEntityCount,
            IEnumerable<ValidationResult> validationErrors,
            Exception error,
            bool cancelled,
            object userState)
            : base(entities, totalEntityCount, validationErrors, error, cancelled, userState)
        {
        }

        public new IEnumerable<T> Entities
        {
            get { return (IEnumerable<T>)base.Entities; }
        }
    }
}
