using System.Reflection;

namespace mjm.nethelpers.Extensions;

public static class AssemblyExtensions
{
    /// <summary>
    /// Retrieve assembly from type
    /// </summary>
    /// <param name="assembly"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static Assembly FromType<T>(this Assembly assembly)
    {
        return typeof(T).Assembly;
    }
}