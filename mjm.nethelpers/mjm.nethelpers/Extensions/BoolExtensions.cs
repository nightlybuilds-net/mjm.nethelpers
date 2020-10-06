namespace mjm.nethelpers.Extensions
{
    public static class BoolExtensions
    {
        /// <summary>
        /// Return true if value is true
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsTrue(this bool value)
        {
            return value;
        }
        
        /// <summary>
        /// Return true if value is false
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsFalse(this bool value)
        {
            return !value;
        }
    }
}