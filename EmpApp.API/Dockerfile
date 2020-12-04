FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["CyberAge.API/CyberAge.API.csproj", "CyberAge.API/"]
RUN dotnet restore "CyberAge.API/CyberAge.API.csproj"
COPY . .
WORKDIR "/src/CyberAge.API"
RUN dotnet build "CyberAge.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CyberAge.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CyberAge.API.dll"]