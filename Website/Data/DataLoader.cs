using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Website.Data;

public class DataLoader
{
    private readonly IMongoCollection<Tweet> _tweetsCollection;

    public DataLoader(IOptions<MongoDbConfiguration> options)
    {
        MongoClient client = new(options.Value.ConnectionString);
        IMongoDatabase db = client.GetDatabase(options.Value.DatabaseName);
        _tweetsCollection = db.GetCollection<Tweet>(options.Value.CollectionName);
    }
    public async Task<List<Tweet>> GetLatest10TweetsAsync()
        => await _tweetsCollection
                        .Find(_ => true)
                        .Limit(10)
                        .ToListAsync();

    public async Task AddTweetAsync(Tweet tweet)
        => await _tweetsCollection.InsertOneAsync(tweet);
}

public class Tweet
{
    public string text { get; set; }
}

public class MongoDbConfiguration
{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
    public string CollectionName { get; set; }
}