#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1903 AS build
WORKDIR /src
COPY ["MachineCartSystem.Microservices/Basket/MachineCartSystem.Basket.Api/MachineCartSystem.Basket.Api.csproj", "MachineCartSystem.Microservices/Basket/MachineCartSystem.Basket.Api/"]
COPY ["MachineCartSystem.Microservices/Basket/MachineCartSystem.Basket.Entity/MachineCartSystem.Basket.Entity.csproj", "MachineCartSystem.Microservices/Basket/MachineCartSystem.Basket.Entity/"]
COPY ["MachineCartSystem.Microservices/Basket/MachineCartSystem.Basket.Service/MachineCartSystem.Basket.Service.csproj", "MachineCartSystem.Microservices/Basket/MachineCartSystem.Basket.Service/"]
COPY ["MachineCartSystem.Infrastructure/MachineCartSystem.Configuration/MachineCartSystem.Configuration.csproj", "MachineCartSystem.Infrastructure/MachineCartSystem.Configuration/"]
COPY ["MachineCartSystem.Infrastructure/MachineCartSystem.Common/MachineCartSystem.Common.csproj", "MachineCartSystem.Infrastructure/MachineCartSystem.Common/"]
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