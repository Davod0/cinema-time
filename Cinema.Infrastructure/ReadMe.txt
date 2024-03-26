dotnet add package Microsoft.EntityFrameworkCore 

dotnet add package Microsoft.EntityFrameworkCore.Sqlite 
Microsoft.EntityFrameworkCore.InMemory

dotnet tool install --global dotnet-ef ***

dotnet add package Microsoft.EntityFrameworkCore.Design 


(dotnet add projectMap/projectMap.csproj reference ClassLibMap/ClassLibMap.csproj)

dotnet add .\bio-tranan-Davod0\Cinema.Infrastructure\Cinema.Infrastructure.csproj reference
.\bio-tranan-Davod0\Cinema.Core\Cinema.Core.csproj