FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["src/InventorySystem.Api/InventorySystem.Api.csproj", "InventorySystem.Api/"]
RUN dotnet restore "InventorySystem.Api/InventorySystem.Api.csproj"

COPY . .

WORKDIR "/src/src/InventorySystem.Api"
RUN dotnet build "InventorySystem.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InventorySystem.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "InventorySystem.Api.dll"]