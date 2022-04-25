# Config server
Write-Host "--- Setup Config server ---"
docker compose exec configsvr01 mongosh --quiet --file /scripts/configserver.js

# Setup shards
Write-Host "--- Setup Shards ---"
docker compose exec shard01-a mongosh --quiet --file /scripts/replicaset_1.js
docker compose exec shard02-a mongosh --quiet --file /scripts/replicaset_2.js