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
                        .SortByDescending(t => t.created_at)
                        .Limit(10)
                        .ToListAsync();

    public async Task<List<Tweet>> GetLatest10TweetsAsync(string author)
        => await _tweetsCollection
            .Find(t => t.user.screen_name == author)
            .SortByDescending(t => t.created_at)
            .Limit(10)
            .ToListAsync();

    public async Task LikeTweet(long tweetId)
    {
        UpdateDefinition<Tweet> updateDefinition = Builders<Tweet>
            .Update
            .Set(t => t.favorited, true)
            .Inc(t => t.favorite_count, 1);

        UpdateResult result = await _tweetsCollection.UpdateOneAsync(t => t.id == tweetId, updateDefinition);
    }

    public async Task UnlikeTweet(long tweetId)
    {
        UpdateDefinition<Tweet> updateDefinition = Builders<Tweet>
            .Update
            .Set(t => t.favorited, false)
            .Inc(t => t.favorite_count, -1);

        UpdateResult result = await _tweetsCollection.UpdateOneAsync(t => t.id == tweetId, updateDefinition);
    }

}

public class MongoDbConfiguration
{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
    public string CollectionName { get; set; }
}