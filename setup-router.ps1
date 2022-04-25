# Setup router
Write-Host "--- Setup Router ---"
docker compose exec mongo-router mongosh --quiet --file /scripts/router.js

# Restore tweet data
Write-Host "--- Restore tweet data ---"
docker compose exec mongo-router sh -c "mongorestore -u adminUser -p pass1234 -d application_database --authenticationDatabase admin -h localhost:27017 /datadump/twitter/tweets.bson"