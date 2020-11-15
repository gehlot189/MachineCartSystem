#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MachineCartSystem.IdentityServer/MachineCartSystem.IdentityServer/MachineCartSystem.IdentityServer.csproj", "MachineCartSystem.IdentityServer/MachineCartSystem.IdentityServer/"]
COPY ["MachineCartSystem.Infrastructure/MachineCartSystem.Common/MachineCartSystem.Common.csproj", "MachineCartSystem.Infrastructure/MachineCartSystem.Common/"]
COPY ["MachineCartSystem.IdentityServer/MachineCartSystem.IdentityServer.Service/MachineCartSystem.IdentityServer.Service.csproj", "MachineCartSystem.IdentityServer/MachineCartSystem.IdentityServer.Service/"]
RUN dotnet restore "MachineCartSystem.IdentityServer/MachineCartSystem.IdentityServer/MachineCartSystem.IdentityServer.csproj"
COPY . .
WORKDIR "/src/MachineCartSystem.IdentityServer/MachineCartSystem.IdentityServer"
RUN dotnet build "MachineCartSystem.IdentityServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MachineCartSystem.IdentityServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MachineCartSystem.IdentityServer.dll"]
