# Run

`docker-compose build`
`docker-compose up`

# API

## Create new game

POST http://localhost:5000/game
Response is gameId

## Get game

GET http://localhost:5000/game/{{gameId}}

## Play move

POST http://localhost:5000/game/{{gameId}}
```
{
    "Player": "X",
    "Position": {
        "Row": 0,
        "Column": 0
    }
}
```

# Postman collection

Postman collection is available to ease API usage
