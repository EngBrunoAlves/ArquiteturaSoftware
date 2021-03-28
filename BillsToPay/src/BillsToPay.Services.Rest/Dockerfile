FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/BillsToPay.Services.Rest/BillsToPay.Services.Rest.csproj", "src/BillsToPay.Services.Rest/"]
COPY ["src/BillsToPay.Application/BillsToPay.Application.csproj", "src/BillsToPay.Application/"]
COPY ["src/BillsToPay.Domain/BillsToPay.Domain.csproj", "src/BillsToPay.Domain/"]
COPY ["src/BillsToPay.Repository.MySql/BillsToPay.Repository.MySql.csproj", "src/BillsToPay.Repository.MySql/"]
RUN dotnet restore "src/BillsToPay.Services.Rest/BillsToPay.Services.Rest.csproj"
COPY . .
WORKDIR "/src/src/BillsToPay.Services.Rest"
RUN dotnet build "BillsToPay.Services.Rest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BillsToPay.Services.Rest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BillsToPay.Services.Rest.dll"]