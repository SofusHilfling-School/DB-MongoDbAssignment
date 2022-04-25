// Shard 1
print("add shard 1")
var shard_1_result = sh.addShard(
    "rs-shard-01/shard01-a:27017",
    "rs-shard-01/shard01-b:27017",
    "rs-shard-01/shard01-c:27017",
)
printjson(shard_1_result)

// Shard 2
print("add shard 2")
var shard_2_result = sh.addShard(
    "rs-shard-02/shard02-a:27017",
    "rs-shard-02/shard02-b:27017",
    "rs-shard-02/shard02-c:27017",
)
printjson(shard_2_result)

print("create admin user")
db = db.getSiblingDB("admin")
db.createUser({
    user: "adminUser",
    pwd: "pass1234",
    roles: [
        { role: "userAdminAnyDatabase", db: "admin" },
        { role: "readWriteAnyDatabase", db: "admin" }
    ]
})
