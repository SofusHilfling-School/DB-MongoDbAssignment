# DB-MongoDbAssignment

## How to run
Run the following commands:
```
$ docker compose up -d
```

Then run the setup Powershell script to setup shards, default admin user, and import data.
```
> .\setup-replica-sets.ps1
> .\setup-router.ps1
```

### Access

The website can then be accessed on `localhost:8080`. </br>
Mongo Express can be accessed on `localhost:8090`.

## Assignment questions
### What is sharding in mongoDB?
Sharding a database is basically horizontal scaling of the given database. It is more specifically a method for distributing or partitioning data across multiple machines.

It is useful when no single machine can handle large modern-day workloads, by allowing you to scale horizontally.

Horizontal scaling, also known as scaling-out, refers to adding machines to share the data set and load. Horizontal scaling allows for near-limitless scaling to handle big data and intense workloads.

### What are the different components required to implement sharding?
- **Shards**

- **Mongos**

- **Config servers**

### Explain architecture of sharding in mongoDB
A shard is a replica set that contains a subset of the cluster’s data.

The mongos acts as a query router for client applications, handling both read and write operations. It dispatches client requests to the relevant shards and aggregates the result from shards into a consistent client response. Clients connect to a mongos, not to individual shards.

Config servers are the authoritative source of sharding metadata. The sharding metadata reflects the state and organization of the sharded data. The metadata contains the list of sharded collections, routing information, etc.

For a simple visual illustration, see image below. Very simplified construction with only one shard.

![shardillustration](https://webimages.mongodb.com/_com_assets/cms/kyc08hm61who5ts6t-image4.png?auto=format%252Ccompress)

### Provide implementation of map and reduce function
Map-Reduce is deprecated starting in MongoDB 5.0 which means that this isn’t relevant. Map-Reduce is now [recommended](https://www.mongodb.com/docs/manual/reference/map-reduce-to-aggregation-pipeline/) to be done through the aggregation pipeline with operators such as `$group` and `$merge`.

There is two aggregation pipeline operators with the same name but they are quite different form the concept of Map-Reduce

`$map` can be used as part of the aggregation pipeline to apply expressions to each item in an array and then return the results.

In contrast, `$reduce` also applies the expression to each item but combines the results into a single value.

###  Provide execution command for running MapReduce or the aggregate way of doing the same
Below is an implementation of how to use the aggregate function to get the top 10 hashtags:
```javascript
db.tweets.aggregate([
    {
        $match: { 
            "entities.hashtags": { 
                $exists: true, 
                $not: { $size:0 }
            }
        }
    },
    {
        $group: {
            _id: "$entities.hashtags.text", 
            count: { $sum: 1 }
        }
    },
    { 
        $sort: { count: -1 }
    },
    {
        $limit:10
    }
])
```

### Provide top 10 recorded out of the sorted result. (hint: use sort on the result returned by MapReduce or the aggregate way of doing the same)
See code above.