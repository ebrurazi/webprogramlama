# Temel image olarak .NET SDK'sını kullanıyoruz
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MyAspNetApp/MyAspNetApp.csproj", "MyAspNetApp/"]
RUN dotnet restore "MyAspNetApp/MyAspNetApp.csproj"
COPY . .
WORKDIR "/src/MyAspNetApp"
RUN dotnet build "MyAspNetApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyAspNetApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyAspNetApp.dll"]
