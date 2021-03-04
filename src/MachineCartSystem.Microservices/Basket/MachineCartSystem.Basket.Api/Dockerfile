#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster AS build
WORKDIR /src
COPY ["MachineCartSystem.Microservices/Basket/MachineCartSystem.Basket.Api/MachineCartSystem.Basket.Api.csproj", "MachineCartSystem.Microservices/Basket/MachineCartSystem.Basket.Api/"]
COPY ["MachineCartSystem.Microservices/Basket/MachineCartSystem.Basket.Entity/MachineCartSystem.Basket.Entity.csproj", "MachineCartSystem.Microservices/Basket/MachineCartSystem.Basket.Entity/"]
COPY ["MachineCartSystem.Microservices/Basket/MachineCartSystem.Basket.Service/MachineCartSystem.Basket.Service.csproj", "MachineCartSystem.Microservices/Basket/MachineCartSystem.Basket.Service/"]
COPY ["MachineCartSystem.Core/MachineCartSystem.Configuration/MachineCartSystem.Configuration.csproj", "MachineCartSystem.Core/MachineCartSystem.Configuration/"]
COPY ["MachineCartSystem.Core/MachineCartSystem.Common/MachineCartSystem.Common.csproj", "MachineCartSystem.Core/MachineCartSystem.Common/"]
RUN dotnet restore "MachineCartSystem.Microservices/Basket/MachineCartSystem.Basket.Api/MachineCartSystem.Basket.Api.csproj"
COPY . .
WORKDIR "/src/MachineCartSystem.Microservices/Basket/MachineCartSystem.Basket.Api"
RUN dotnet build "MachineCartSystem.Basket.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MachineCartSystem.Basket.Api.csproj" -c Release -o /app/publish


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MachineCartSystem.Basket.Api.dll"]
