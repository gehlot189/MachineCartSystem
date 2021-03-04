#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["MachineCartSystem.Microservices/Catalog/MachineCartSystem.Catalog.Api/MachineCartSystem.Catalog.Api.csproj", "MachineCartSystem.Microservices/Catalog/MachineCartSystem.Catalog.Api/"]
COPY ["MachineCartSystem.Microservices/Catalog/MachineCartSystem.Catalog.Service/MachineCartSystem.Catalog.Service.csproj", "MachineCartSystem.Microservices/Catalog/MachineCartSystem.Catalog.Service/"]
COPY ["MachineCartSystem.Core/MachineCartSystem.Configuration/MachineCartSystem.Configuration.csproj", "MachineCartSystem.Core/MachineCartSystem.Configuration/"]
COPY ["MachineCartSystem.Core/MachineCartSystem.Common/MachineCartSystem.Common.csproj", "MachineCartSystem.Core/MachineCartSystem.Common/"]
RUN dotnet restore "MachineCartSystem.Microservices/Catalog/MachineCartSystem.Catalog.Api/MachineCartSystem.Catalog.Api.csproj"
COPY . .
WORKDIR "/src/MachineCartSystem.Microservices/Catalog/MachineCartSystem.Catalog.Api"
RUN dotnet build "MachineCartSystem.Catalog.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MachineCartSystem.Catalog.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MachineCartSystem.Catalog.Api.dll"]