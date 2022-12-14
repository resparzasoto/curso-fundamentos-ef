# Curso de Fundamentos de Entity Framework Core

[![wakatime](https://wakatime.com/badge/user/98bbbf97-d733-47e8-81af-799da282107b/project/0c091bb2-5aae-40fb-990f-666c1a6521ae.svg)](https://wakatime.com/badge/user/98bbbf97-d733-47e8-81af-799da282107b/project/0c091bb2-5aae-40fb-990f-666c1a6521ae)

## Dependencies

1. Install [.NET 6 last version](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

2. Install dotnet ef tools

```bash
$ dotnet tool install --global dotnet-ef
```
3. Install [docker](https://docs.docker.com/get-docker/)

## Run

1. Rename the `.env.example` to `.env`

2. Run the `docker-compose.yml`

```bash
$ docker-compose up --wait --force-recreate
```

3. Build the solution.


```bash
$ dotnet build
```

4. Run the migrations.

```bash
$ dotnet ef database update
```

5. Run the project.

```bash
$ dotnet run
```
6. Import the api requests collection in postman with the file [api.postman_collection.json](./api.postman_collection.json)

## Reference

- [Curso de Fundamentos de Entity Framework](https://platzi.com/cursos/entity-framework/)