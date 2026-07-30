using MongoDB.Driver;
using StackExchange.Redis;

void RedisCheck()
{
    var redis = ConnectionMultiplexer.Connect(
        "localhost:6379"
    );

    var db = redis.GetDatabase();

    db.StringSet(
        "customer",
        "Surabhi"
    );

    var value = db.StringGet("customer");

    Console.WriteLine(value);
}

void dbconCheck()
{
    try
    {
        var connectionString = "mongodb://root:password@localhost:27017?authMechanism=SCRAM-SHA-1&authSource=admin";
        if (string.IsNullOrEmpty(connectionString))
        {
            Console.WriteLine("You must set your 'MONGODB_URI' environment variable. To learn how to set it, see https://www.mongodb.com/docs/drivers/csharp/current/get-started/create-connection-string");
            Environment.Exit(0);
        }
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase("admin");

        var result = database.RunCommand<dynamic>(
            "{ ping: 1 }"
        );

        Console.WriteLine("MongoDB connection successful");
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
}

void DbCheck()
{
    var settings = MongoClientSettings.FromConnectionString(
        "mongodb://root:password@localhost:27017/mydatabase?authSource=admin"
    );

    settings.ServerSelectionTimeout = TimeSpan.FromSeconds(5);

    var client = new MongoClient(settings);

    var database = client.GetDatabase("mydatabase");

    var collection = database.GetCollection<dynamic>("customers");

    var result = collection.Find(Builders<dynamic>.Filter.Empty)
        .FirstOrDefault();

    Console.WriteLine(result);
}

RedisCheck();
//dbconCheck();
//DbCheck();
Console.WriteLine("Hello, World!");


