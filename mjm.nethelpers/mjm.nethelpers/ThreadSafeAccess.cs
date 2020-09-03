using System;

namespace mjm.nethelpers
{
    /// <summary>
    /// All access to the instance are wrapped into lock
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ThreadSafe<T>
    {
        private readonly object _lock = new object();

        private readonly T _instance;
        public ThreadSafe(T instance)
        {
            this._instance = instance;
        }

        public TK Use<TK>(Func<T,TK> func)
        {
            lock (this._lock)
            {
                return func.Invoke(this._instance);
            }
        }
        
        public void Use(Action<T> func)
        {
            lock (this._lock)
            {
                func.Invoke(this._instance);
            }
        }
    }

    public class ThreadSafe
    {
        public static ThreadSafe<T> On<T>(T instance)  => new ThreadSafe<T>(instance);

    }
}