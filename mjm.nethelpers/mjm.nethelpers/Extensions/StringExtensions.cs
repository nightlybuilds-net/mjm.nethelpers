using System.Text.Json;

namespace mjm.nethelpers.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Deserialize JSON to T using System.Text.Json
        /// </summary>
        /// <param name="json"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromJson<T>(this string json)
        {
            return json == null ? default(T) : JsonSerializer.Deserialize<T>(json);
        }

        /// <summary>
        /// Extension for string.IsNullOrEmpty
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string text)
        {
            return string.IsNullOrEmpty(text);
        }
        
        /// <summary>
        /// Extension for string.IsNullOrWhiteSpace
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string text)
        {
            return string.IsNullOrWhiteSpace(text);
        }
    }
}