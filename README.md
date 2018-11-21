Server=tcp:utsqlserver.database.windows.net,1433;Initial Catalog=UTLogDb;Persist Security Info=False;User ID=unitedtractorapp;Password=P@ssw0rd12345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;


Scaffold-DbContext "Server=tcp:utsqlserver.database.windows.net,1433;Initial Catalog=UTLogDb;Persist Security Info=False;User ID=unitedtractorapp;Password=P@ssw0rd12345;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models


dotnet tool install -g dotnet-aspnet-codegenerator
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet restore
dotnet aspnet-codegenerator controller -name PoheaderController -m Poheader -dc UTLogDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries


dotnet add package GraphQL

dotnet add package graphiql