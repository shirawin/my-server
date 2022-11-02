#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["my-server/my-server.csproj", "my-server/"]
RUN dotnet restore "my-server/my-server.csproj"
COPY . .
WORKDIR "/src/my-server"
RUN dotnet build "my-server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "my-server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "my-server.dll"]