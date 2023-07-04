using StackExchange.Redis;
using System;

public class RedisExample
{
    private readonly ConnectionMultiplexer redis;
    private readonly IDatabase db;

    public RedisExample(string connectionString)
    {
        redis = ConnectionMultiplexer.Connect(connectionString);
        db = redis.GetDatabase();
    }

    public void AddData(string key, string value)
    {
        db.StringSet(key, value);
    }

    public void RemoveData(string key)
    {
        db.KeyDelete(key);
    }

    public string GetData(string key)
    {
        return db.StringGet(key);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var redisExample = new RedisExample("localhost"); // Redis bağlantı bilgisini gerekirse düzenleyin

        // Veri ekleme
        redisExample.AddData("mykey", "İlk veri");

        // Veri getirme
        var value = redisExample.GetData("mykey");
        Console.WriteLine("Veri: " + value);

        // Veri silme
        redisExample.RemoveData("mykey");

        // Veriyi yeniden getirme
        value = redisExample.GetData("mykey");
        Console.WriteLine("Veri: " + value); // Silindikten sonra null veya boş bir değer dönecektir

        Console.ReadLine();
    }
}
