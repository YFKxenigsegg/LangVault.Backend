using System.Linq.Expressions;
using System.Reflection;

namespace LangVault.Management.Application.Common.Extensions;
public static class OrderExtensions
{
    public static IQueryable<T> ApplyOrder<T>(this IQueryable<T> query, string propertyName, bool ascending = false)
    {
        var type = typeof(T);
        var property = type.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
            ?? throw new ArgumentNullException(nameof(propertyName), "Property not found.");
        var parameter = Expression.Parameter(type, "p");
        var propertyAccess = Expression.MakeMemberAccess(parameter, property);
        var orderByExpression = Expression.Lambda(propertyAccess, parameter);
        var order = ascending ? "OrderBy" : "OrderByDescending";
        var resultExpression = Expression.Call(typeof(Queryable),
            order,
            [type, property.PropertyType],
            query.Expression, Expression.Quote(orderByExpression));
        return query.Provider.CreateQuery<T>(resultExpression);
    }
}
