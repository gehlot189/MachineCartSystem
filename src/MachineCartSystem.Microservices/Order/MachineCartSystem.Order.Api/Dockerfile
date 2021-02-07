#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster AS build
WORKDIR /src
COPY ["MachineCartSystem.Microservices/Order/MachineCartSystem.Order.Api/MachineCartSystem.Order.Api.csproj", "MachineCartSystem.Microservices/Order/MachineCartSystem.Order.Api/"]
COPY ["MachineCartSystem.Microservices/Order/MachineCartSystem.Order.Service/MachineCartSystem.Order.Service.csproj", "MachineCartSystem.Microservices/Order/MachineCartSystem.Order.Service/"]
COPY ["MachineCartSystem.Infrastructure/MachineCartSystem.Configuration/MachineCartSystem.Configuration.csproj", "MachineCartSystem.Infrastructure/MachineCartSystem.Configuration/"]
COPY ["MachineCartSystem.Infrastructure/MachineCartSystem.Common/MachineCartSystem.Common.csproj", "MachineCartSystem.Infrastructure/MachineCartSystem.Common/"]
RUN dotnet restore "MachineCartSystem.Microservices/Order/MachineCartSystem.Order.Api/MachineCartSystem.Order.Api.csproj"
COPY . .
WORKDIR "/src/MachineCartSystem.Microservices/Order/MachineCartSystem.Order.Api"
RUN dotnet build "MachineCartSystem.Order.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MachineCartSystem.Order.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MachineCartSystem.Order.Api.dll"]
