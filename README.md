create model from already existed db
Scaffold-DbContext "Server=tcp:sqlserver.database.windows.net,1433;Initial Catalog=xxx;Persist Security Info=False;User ID=xxx;Password=xxx;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models


dotnet tool install -g dotnet-aspnet-codegenerator
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet restore
dotnet aspnet-codegenerator controller -name PoheaderController -m Poheader -dc UTLogDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries


dotnet add package GraphQL

dotnet add package graphiql