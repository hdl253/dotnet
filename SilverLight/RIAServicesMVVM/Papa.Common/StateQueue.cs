using System.Collections.Generic;

namespace Papa.Common
{
    public class StateQueue
    {
        protected readonly Dictionary<string, object> State = new Dictionary<string, object>();

        public void PushState(string key, object value)
        {
            if (value != null)
            {
                State[key] = value;
            }
        }

        public T PopState<T>(string key) where T : class
        {
            if (key != null && State.ContainsKey(key))
            {
                var value = PeekState<T>(key);
                State.Remove(key);
                return value;
            }
            else
            {
                return default(T);
            }
        }

        public T PeekState<T>(string key) where T : class
        {
            object value;
            State.TryGetValue(key, out value);
            return value as T;
        }
    }
}