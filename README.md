## WHAT IS THIS?

Demo Asp.Net Core CRUD + Postgres in docker.

## HOW TO USE

Type this to run (app will be available on http://localhost:8888)
```
docker-compose up --build
```
and this to shut down (but keep data volume)
```
docker-compose down
```
and this to destroy data volume
```
docker-compose down -v
```
for development purposes you can run Postgres only
```
docker-compose -f docker-compose.dev.yml up
```

## API

```
### list all

GET http://localhost:8888/people

### add new record

POST http://localhost:8888/people
Content-Type: application/json

{"firstName":"John","lastName":"Doe","birthDate":"2020-02-01T00:00:00"}

### get record

GET http://localhost:8888/people/1

### update record

PUT http://localhost:8888/people/1
Content-Type: application/json

{"firstName":"Jane","lastName":"Doe","birthDate":"2020-02-03T00:00:00"}

### delete record

DELETE http://localhost:8888/people/1

```