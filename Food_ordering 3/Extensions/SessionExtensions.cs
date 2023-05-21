using Food_ordering_3;
using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Http;


public static class SessionExtensions
{
    public static void SetProduct(this ISession session, string key, Product value)
    {
        session.SetString(key, JsonSerializer.Serialize(value));
    }

    public static Product GetProduct(this ISession session, string key)
    {
        var value = session.GetString(key);
        return value == null ? null : JsonSerializer.Deserialize<Product>(value);
    }
}
