using System.Reflection;

namespace mjm.nethelpers;

public static class AssemblyHelper
{
    /// <summary>
    /// Retrieve assembly from type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static Assembly FromType<T>()
    {
        return typeof(T).Assembly;
    }
}