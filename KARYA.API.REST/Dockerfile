#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["KARYA.API.REST/KARYA.API.REST.csproj", "KARYA.API.REST/"]
RUN dotnet restore "KARYA.API.REST/KARYA.API.REST.csproj"
COPY . .
WORKDIR "/src/KARYA.API.REST"
RUN dotnet build "KARYA.API.REST.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KARYA.API.REST.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KARYA.API.REST.dll"]