#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DbMigrations/DbMigrations.csproj", "DbMigrations/"]
COPY ["DataAccessLayer/DataAccessLayer.csproj", "DataAccessLayer/"]
COPY ["SAPexGoogleSupportService/SAPexGoogleSupportService.csproj", "SAPexGoogleSupportService/"]
COPY ["BusinessLogicLayer/BusinessLogicLayer.csproj", "BusinessLogicLayer/"]
COPY ["SAPexAuthService/SAPexAuthService.csproj", "SAPexAuthService/"]
COPY ["SAPexSMTPMailService/SAPexSMTPMailService.csproj", "SAPexSMTPMailService/"]
COPY ["SAPex/SAPex.csproj", "SAPex/"]

RUN dotnet restore "SAPex/SAPex.csproj"
COPY . .
WORKDIR "/src/SAPex"
RUN dotnet build "SAPex.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SAPex.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SAPex.dll"]
