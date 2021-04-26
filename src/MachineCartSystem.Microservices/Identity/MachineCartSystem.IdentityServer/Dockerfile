#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MachineCartSystem.Microservices/Identity/MachineCartSystem.IdentityServer/MachineCartSystem.IdentityServer.csproj", "MachineCartSystem.Microservices/Identity/MachineCartSystem.IdentityServer/"]
COPY ["MachineCartSystem.Microservices/Identity/MachineCartSystem.IdentityServer.Service/MachineCartSystem.IdentityServer.Service.csproj", "MachineCartSystem.Microservices/Identity/MachineCartSystem.IdentityServer.Service/"]
COPY ["MachineCartSystem.Core/MachineCartSystem.Configuration/MachineCartSystem.Configuration.csproj", "MachineCartSystem.Core/MachineCartSystem.Configuration/"]
RUN dotnet restore "MachineCartSystem.Microservices/Identity/MachineCartSystem.IdentityServer/MachineCartSystem.IdentityServer.csproj"
COPY . .
WORKDIR "/src/MachineCartSystem.Microservices/Identity/MachineCartSystem.IdentityServer"
RUN dotnet build "MachineCartSystem.IdentityServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MachineCartSystem.IdentityServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MachineCartSystem.IdentityServer.dll"]