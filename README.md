# Run

`docker-compose build`
`docker-compose up`

# API

## Create new game
POST http://localhost:5000/game/create
Response is gameId

## Get game
GET http://localhost:5000/game/{{gameId}}

# Postman collection
Postman collection is available to ease API usage