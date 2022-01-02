namespace Shared.Reflection;

public static class ReflectionExtensions
{
    public static bool HasParameterlessConstructor(this Type type)
        => type.IsValueType || !type.IsAbstract && type.GetConstructor(Type.EmptyTypes) is not null;

}

