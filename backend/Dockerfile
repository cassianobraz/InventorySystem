FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY InventorySystem/src ./InventorySystem/src

WORKDIR /src/InventorySystem/src/InventorySystem.Api

RUN dotnet restore "InventorySystem.Api.csproj"
RUN dotnet build "InventorySystem.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InventorySystem.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "InventorySystem.Api.dll"]
