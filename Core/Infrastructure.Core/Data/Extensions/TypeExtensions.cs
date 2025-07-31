namespace Infrastructure.Core.Data.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsAssignableFromGeneric(this Type genericType, Type type)
        {
            return type.GetInterfaces().Any(i =>
                i.IsGenericType && i.GetGenericTypeDefinition() == genericType);
        }
    }
}
