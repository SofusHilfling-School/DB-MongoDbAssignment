# DB-MongoDbAssignment

## How to run
### xxx
Run the following commands:
```
$ docker compose up -d
```

## Assignment questions
### What is sharding in mongoDB?
Sharding a database is basically horizontal scaling of the given database. It is more specifically a method for distributing or partitioning data across multiple machines.

It is useful when no single machine can handle large modern-day workloads, by allowing you to scale horizontally.

Horizontal scaling, also known as scaling-out, refers to adding machines to share the data set and load. Horizontal scaling allows for near-limitless scaling to handle big data and intense workloads.

### What are the different components required to implement sharding?
- **Shards**
A shard is a replica set that contains a subset of the cluster’s data.

- **Mongos**
The mongos acts as a query router for client applications, handling both read and write operations. It dispatches client requests to the relevant shards and aggregates the result from shards into a consistent client response. Clients connect to a mongos, not to individual shards.

- **Config servers**
Config servers are the authoritative source of sharding metadata. The sharding metadata reflects the state and organization of the sharded data. The metadata contains the list of sharded collections, routing information, etc.

### Explain architecture of sharding in mongoDB?
Bla bla bla

### Provide implementation of map and reduce function
- [ ] Committed to project

###  Provide execution command for running MapReduce or the aggregate way of doing the same
- [ ] Committed to project

### Provide top 10 recorded out of the sorted result. (hint: use sort on the result returned by MapReduce or the aggregate way of doing the same)
- [ ] Committed to project
