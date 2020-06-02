echo Updating dbseeder dependencies...
@echo off

cd .\dbseeder
call dotnet add package Microsoft.EntityFrameworkCore.Relational
call dotnet add package Microsoft.EntityFrameworkCore.SqlServer

echo Updating NinjaMission.Data dependencies...
cd ..\NinjaMissions.Data
call dotnet add package Microsoft.EntityFrameworkCore.SqlServer
call dotnet add package Microsoft.EntityFrameworkCore.Tools

echo Updating NinjaMission.Web dependencies...
cd ..\NinjaMissions.Web
call dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson
call dotnet add package Microsoft.EntityFrameworkCore.Design

cd ..
echo Dependencies successfully updated!