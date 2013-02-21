using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Ria.Common
{
    public abstract class ServiceInvokeResult : AsyncCompletedEventArgs
    {
        private readonly object _value;
        private readonly IEnumerable<ValidationResult> _validationErrors;

        protected ServiceInvokeResult(
            object value,
            IEnumerable<ValidationResult> validationErrors,
            Exception error,
            bool cancelled,
            object userState)
            : base(error, cancelled, userState)
        {
            if (validationErrors == null)
            {
                throw new ArgumentNullException("validationErrors");
            }

            this._value = value;
            this._validationErrors = validationErrors;
        }

        public object Value
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return this._value;
            }
        }

        public IEnumerable<ValidationResult> ValidationErrors
        {
            get { return this._validationErrors; }
        }
    }

    public class ServiceInvokeResult<T> : ServiceInvokeResult
    {
        public ServiceInvokeResult(T value, object userState)
            : this(value, Enumerable.Empty<ValidationResult>(), null, false, userState)
        {
        }

        public ServiceInvokeResult(
            T value,
            IEnumerable<ValidationResult> validationErrors,
            Exception error,
            bool cancelled,
            object userState)
            : base(value, validationErrors, error, cancelled, userState)
        {
        }

        public new T Value
        {
            get { return (T)base.Value; }
        }
    }
}
