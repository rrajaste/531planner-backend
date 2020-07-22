# 531planner backend

### What's this?

This is a server side backend for "531planner" providing RESTful API for client frontends as well as a ASP.NET server side generated user interface for application admin actions.
 
[Prototype frontend client](https://github.com/rrajaste/531planner-frontend)
### What is "531planner"?
 
531planner is a workout routine generator and progress tracker for the famous powerlifting routine "531" developed by Jim Wendler. "531planner" aims to provide users with easy and flexible workout routine cycle generation as well as provide easy to understand nutrient and body composition tracking.

You can see the detailed overview and analyzis of the project [HERE](Documentation/Project%20description.pdf) or under "Documentation" directory.

## Setting things up

### Installing or updating necessary tooling

```
dotnet tool install --global dotnet-ef
dotnet tool update --global dotnet-ef
```

### Database connection

#### SQL server
The application is currently programmed to work on Microsoft SQL Server as the data source. 
To connect to a MS SQL Server database of your choice enter your connection string in the WebApplication/appsettings.json 
```
"ConnectionStrings": {
    "MsSqlConnection": "YOUR CONNECTION STRING HERE"
},
```
#### Other databases

Other data sources need more configuration.
Since the application uses GUIDs as key types, if the database engine of your choice supports them natively you can create a new connection string such as:

```
"ConnectionStrings": {
    "MsSqlConnection": "",
    "PostGresConnection": "YOUR CONNECTION STRING HERE"
},
```

and specify the new connection under WebApplication/Startup.cs

```
services.AddDbContext<AppDbContext>(options =>
    options
    .UseNpgsql((Configuration.GetConnectionString("PostGresConnection"))
);
```
For other databases the keys of domain objects need to be changed to some other supported type first.

### Database migrations

To generate necessary migrations for database run from solution folder:

```
dotnet ef migrations --project DAL.App.EF --startup-project WebApplication add InitialDbCreation 
dotnet ef database update --project DAL.App.EF --startup-project WebApp
``` 

Now the migrations should be created inside the data source and database should be ready. If something went wrong you can delete the migration with: 

```
dotnet ef migrations --project DAL.App.EF --startup-project WebApplication remove
```

### Building the application

From solution folder run

```
dotnet build 531-planner.sln
```

### Running the build

From solution folder run

```
dotnet run WebApplication/bin/Debug/netcoreapp3.1/WebApplication.dll
```

## Deployment

### Docker
Docker file is included in the project, if you wish to build a docker image run 

```
docker build -t webapplication
```

To check the docker image and run it locally run

```
docker run --name webapplication_docker --rm -it -p 8000:80 webapplication
```

If everything is correct your docker image should now be ready for deployment.

### Dependencies

* .NET core >= v3.1

### Authors

* Ranno Rajaste