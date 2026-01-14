FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["WebApplication14.csproj", "./"]
RUN dotnet restore "WebApplication14.csproj"

COPY . .
RUN dotnet build "WebApplication14.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApplication14.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApplication14.dll"]
