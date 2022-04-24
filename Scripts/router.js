// Shard 1
sh.addShard(
    "rs-shard-01/shard01-a:27017",
    "rs-shard-01/shard01-b:27017",
    "rs-shard-01/shard01-c:27017",
)

// Shard 2
sh.addShard(
    "rs-shard-02/shard02-a:27017",
    "rs-shard-02/shard02-b:27017",
    "rs-shard-02/shard02-c:27017",
)

db.createUser({
    user: "adminUser",
    pwd: "pass1234",
    roles: [
        { role: "userAdminAnyDatabase", db: "admin" },
        { role: "readWriteAnyDatabase", db: "admin" }
    ]
})
