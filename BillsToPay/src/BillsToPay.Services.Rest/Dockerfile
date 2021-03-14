#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["BillsToPay.Services.Rest/BillsToPay.Services.Rest.csproj", "BillsToPay.Services.Rest/"]
RUN dotnet restore "BillsToPay.Services.Rest/BillsToPay.Services.Rest.csproj"
COPY . .
WORKDIR "/src/BillsToPay.Services.Rest"
RUN dotnet build "BillsToPay.Services.Rest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BillsToPay.Services.Rest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BillsToPay.Services.Rest.dll"]