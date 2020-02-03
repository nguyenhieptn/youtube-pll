using Newtonsoft.Json;
using System;
using System.Text;

public static class BASE64
{
    public static string Encode(string plainText)
    {
        var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
        return Convert.ToBase64String(plainTextBytes);
    }

    public static string Decode(string base64EncodedData)
    {
        var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
        return Encoding.UTF8.GetString(base64EncodedBytes);
    }
}
public static class JSON
{
    public static string Encode(dynamic obj)
    {        
        return JsonConvert.SerializeObject(obj);
    }

    public static dynamic Decode<T>(string json)
    {
        return JsonConvert.DeserializeObject<T>(json);
    }
}
