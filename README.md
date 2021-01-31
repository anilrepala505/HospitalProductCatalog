# HospitalProductCatalogs #
Hospital Product Catalogs is an API which is used to Create, View, Edit & Delete Categories and Products. \
This API uses in-memory database with Category and Product details.

## Getting Started ##
These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. 

## Built With ##
* [.Net core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)

## Prerequisites ##
Required NuGet packages
```
AutoMapper
AutoMapper.Extensions.Microsoft.DependencyInjection
Microsoft.EntityFrameworkCore.InMemory
Microsoft.EntityFrameworkCore.Relational
Swashbuckle.AspNetCore
Moq
Autofac.Extras.Moq
```

## Setting Up & Execution ##
1. Clone the repo
   ```sh
   git clone https://github.com/anilrepala505/HospitalProductCatalog.git
   ```
2. Open command prompt as admin.
3. Navigate to project folder.
4. Run below command:
   ```sh
   dotnet run
   ```
5. Once command executed, open webbrowser and navigate to below URL:
   ```sh
   https://localhost:5001/swagger/index.html
   ```
6. List of Endpoints for category and product will be displayed with schemas.

## Unit testing ##
Unit testcases are available in HospitalProductCatalog.Tests folder.
