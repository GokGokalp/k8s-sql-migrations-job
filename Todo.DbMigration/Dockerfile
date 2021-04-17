FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Todo.DbMigration/Todo.DbMigration.csproj", "Todo.DbMigration/"]
RUN dotnet restore "Todo.DbMigration/Todo.DbMigration.csproj"
COPY . .
WORKDIR "/src/Todo.DbMigration"
RUN dotnet build "Todo.DbMigration.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Todo.DbMigration.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Todo.DbMigration.dll"]