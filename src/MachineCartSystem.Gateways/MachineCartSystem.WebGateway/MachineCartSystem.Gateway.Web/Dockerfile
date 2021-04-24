#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["MachineCartSystem.Gateways/MachineCartSystem.WebGateway/MachineCartSystem.Gateway.Web/MachineCartSystem.Gateway.Web.csproj", "MachineCartSystem.Gateways/MachineCartSystem.WebGateway/MachineCartSystem.Gateway.Web/"]
COPY ["MachineCartSystem.Gateways/MachineCartSystem.WebGateway/MachineCartSystem.Gateway.WebService/MachineCartSystem.Gateway.WebService.csproj", "MachineCartSystem.Gateways/MachineCartSystem.WebGateway/MachineCartSystem.Gateway.WebService/"]
COPY ["MachineCartSystem.Core/MachineCartSystem.Configuration/MachineCartSystem.Configuration.csproj", "MachineCartSystem.Core/MachineCartSystem.Configuration/"]
COPY ["MachineCartSystem.Core/MachineCartSystem.Common/MachineCartSystem.Common.csproj", "MachineCartSystem.Core/MachineCartSystem.Common/"]
RUN dotnet restore "MachineCartSystem.Gateways/MachineCartSystem.WebGateway/MachineCartSystem.Gateway.Web/MachineCartSystem.Gateway.Web.csproj"
COPY ./wait-for-it.sh /wait-for-it.sh
RUN chmod +x wait-for-it.sh

COPY . .
WORKDIR "/src/MachineCartSystem.Gateways/MachineCartSystem.WebGateway/MachineCartSystem.Gateway.Web"
RUN dotnet build "MachineCartSystem.Gateway.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MachineCartSystem.Gateway.Web.csproj" -c Release -o /app/publish

COPY ./wait-for-it.sh /wait-for-it.sh
RUN chmod +x wait-for-it.sh

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MachineCartSystem.Gateway.Web.dll"]