<h1 align="center">AltenHotel API</h1>

## Description
<p align="left">This API can help an Hotel to manage their room reservation, the implementation is in the first version and can be improved further.</p>

## Summary
 * [Technologies](#technologies)
 * [How to Use](#how-to-use)
    * [Setup](#setup)
    * [In Memory](#in-memory)
    * [SQL Server](#sql-server)
    * [Swagger](#swagger)
 * [Details](#details)

## Technologies

[.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0)
[Entity Framework](https://docs.microsoft.com/en-us/ef/)
[InMemoryDatabase](https://docs.microsoft.com/en-us/ef/core/providers/in-memory/)
[SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
[NSubstitute](https://nsubstitute.github.io/)
[Moq](https://github.com/Moq/moq4/wiki/Quickstart)
[Swagger](https://swagger.io/)

## How To Use

### Setup

Before you start, you neeed to install [.NET 5.0 SDK](https://dotnet.microsoft.com/download/dotnet/5.0), you need also a source code editor like [Visual Studio](https://visualstudio.microsoft.com/pt-br/downloads/) or [VSCode](https://code.visualstudio.com/).

### In Memory

For tests purposes and to make easy to run, this API is using "InMemoryDatabase", that means when you run the code, a database in memory will be created and you can use the API with swagger and run all tests you want on API, but without persistent data, when you close the API  all data will be lost.

### SQL Server

In case you want to test with persistent data, or you want to deploy the application, you can easily run a Migration and It'll create a database, in this case, make sure you have [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) installed. Check the steps above to run

<details>
To run the Migration, 2 steps needs to be made

#### Step 1 - Change InMemoryDatabase to SqlServer
  
  * Change the code to run with SQL Server.
  
  In file: `source\AltenHotel.Api\Extensions\DependencyResolver.cs` change the line above:
  
  ```c#
  services.AddDbContext<HotelContext>(opt => opt.UseInMemoryDatabase("AltenHotel"));
  ```
  
  To the following code:
  
  ```c#
  services.AddDbContext<HotelContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
  ```
  
  Make sure you added the connection string in the file `appsettings.json`
  
  Example of a local connection string
  
  ```json
  "Server=(localdb)\\mssqllocaldb;Database=AltenHotel;Trusted_Connection=True;MultipleActiveResultSets=true"
  ```
  
#### Step 2 - Run Migration

  With Visual Studio opened, open the Package Manager Console
  Make sure the Default Project in that window was checked as "Infrastructure" like the Image
  
  ![package](https://user-images.githubusercontent.com/26381060/132993693-a8a1996f-094e-4a88-9dd0-b361a2149517.png)
  
  Run the command  `Update-Database`
</details>
  
### Swagger
   
   By default, the swagger URL will be opened when you run the API and can be used to test the endpoints, you can also use a third programm to send the payloads, like [Insomnia](https://insomnia.rest/download) or [Postman](https://www.postman.com/downloads/). Swagger also provides all payloads examples for the API.
   
## Details
   
   * Format data for API: `yyyy-mm-dd`
   * For deploy and quality API, deploy is recommended in cloud like Azure, GCP or AWS
   * Recommended to use a pipeline with unit tests and make more than an instance, when deploy 
