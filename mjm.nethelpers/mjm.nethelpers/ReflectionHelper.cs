using System;
using System.Reflection;
using mjm.nethelpers.Extensions;

namespace mjm.nethelpers
{
    public class ReflectionHelper : IReflectionActions
    {
        private readonly object _obj;

        internal ReflectionHelper(object obj)
        {
            this._obj = obj;
        }

        public void InvokeMethod(string methodName, BindingFlags flags, params object[] parameters)
        {
            var methodInfo = this._obj.GetType().GetMethod(methodName, flags);
            methodInfo?.Invoke(this._obj, parameters);
        }

        public T InvokeMethod<T>(string methodName, BindingFlags flags, params object[] parameters)
        {
            var methodInfo = this._obj.GetType().GetMethod(methodName, flags);
            var result = methodInfo?.Invoke(this._obj, parameters);
            return result.IsNull() ? default : result.To<T>();
        }

        public T GetProperty<T>(string propertyName, BindingFlags flags = BindingFlags.Public | BindingFlags.Instance)
        {
            var value = this._obj.GetType().GetProperty(propertyName, flags)?.GetValue(this._obj, null);
            return value.IsNull() ? default : value.To<T>();
        }

        public void SetProperty<T>(string propertyName, T value,
            BindingFlags flags = BindingFlags.Public | BindingFlags.Instance)
        {
            this._obj.GetType().GetProperty(propertyName, flags)?.SetValue(this._obj, value);
        }

        public T GetField<T>(string fieldName)
        {
            var value = this._obj.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance)
                ?.GetValue(this._obj);
            return value.IsNull() ? default : value.To<T>();
        }

        public void SetField<T>(string fieldName, T value)
        {
            this._obj.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance)
                ?.SetValue(this._obj, value);
        }

        public T GetAttribute<T>() where T : Attribute
        {
            return (T) Attribute.GetCustomAttribute(this._obj.GetType(), typeof (T));
        }
    }

    public interface IReflectionActions
    {
        /// <summary>
        /// Invoke void method if method exist
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="flags">Default is BindingFlags.Public | BindingFlags.Instance</param>
        /// <param name="parameters"></param>
        void InvokeMethod(string methodName, BindingFlags flags = BindingFlags.Public | BindingFlags.Instance,
            params object[] parameters);

        /// <summary>
        /// Invoke method if exist and return T
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="flags"></param>
        /// <param name="parameters">Default is BindingFlags.Public | BindingFlags.Instance</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T InvokeMethod<T>(string methodName, BindingFlags flags = BindingFlags.Public | BindingFlags.Instance,
            params object[] parameters);

        /// <summary>
        /// Get property value if found
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="flags"></param>
        /// <typeparam name="T">Default is BindingFlags.Public | BindingFlags.Instance</typeparam>
        /// <returns></returns>
        T GetProperty<T>(string propertyName, BindingFlags flags = BindingFlags.Public | BindingFlags.Instance);

        /// <summary>
        /// Set property value if found
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="value">Value to set</param>
        /// <param name="flags"></param>
        /// <typeparam name="T">Default is BindingFlags.Public | BindingFlags.Instance</typeparam>
        /// <returns></returns>
        void SetProperty<T>(string propertyName, T value,
            BindingFlags flags = BindingFlags.Public | BindingFlags.Instance);

        /// <summary>
        /// Get field value if found
        /// </summary>
        /// <param name="fieldName"></param>
        /// <typeparam name="T">Default is BindingFlags.Public | BindingFlags.Instance</typeparam>
        /// <returns></returns>
        T GetField<T>(string fieldName);

        /// <summary>
        /// Set field value if found
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="value">Value to set</param>
        /// <typeparam name="T">Default is BindingFlags.Public | BindingFlags.Instance</typeparam>
        /// <returns></returns>
        void SetField<T>(string fieldName, T value);


       
        /// <summary>
        /// GetAttribute returns an attribute of type T from the current method.
        /// </summary>
        T GetAttribute<T>() where T : Attribute;

    }
}