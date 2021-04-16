namespace JWETestApplication.Utils
{
    public interface IJsonMapper
    {
        string Serialize(object obj);
        T Parse<T>(string json);
    }
}