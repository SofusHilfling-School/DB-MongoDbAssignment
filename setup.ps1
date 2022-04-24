# Config server
"--- Setup Config server ---"
docker compose exec configsvr01 sh -c "mongosh mongodb://localhost:27017/admin < /scripts/configserver.js"

# Setup shards
"--- Setup Shards ---"
docker compose exec shard01-a sh -c "mongosh mongodb://localhost:27017/admin < /scripts/replicaset_1.js"
docker compose exec shard02-a sh -c "mongosh mongodb://localhost:27017/admin < /scripts/replicaset_2.js"

#Start-Sleep -s 5

# Setup router
"--- Setup Router ---"
docker compose exec mongo-router sh -c "mongosh mongodb://localhost:27017/admin < /scripts/router.js"

# Restore tweet data
"--- Restore tweet data ---"
docker compose exec mongo-router sh -c "mongorestore -u adminUser -p pass1234 -d application_database --authenticationDatabase admin -h localhost:27017 /datadump/twitter/tweets.bson"