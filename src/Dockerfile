# Stage 1

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

ENV ASPNETCORE_ENVIRONMENT=Development

WORKDIR /src

COPY ./*.sln .
COPY ./nuget.config .
COPY ./Nora.Orders.Api/Nora.Orders.Api.csproj/ Nora.Orders.Api/
COPY ./Nora.Orders.Domain/Nora.Orders.Domain.csproj/ Nora.Orders.Domain/
COPY ./Nora.Orders.Domain.Command/Nora.Orders.Domain.Command.csproj/ Nora.Orders.Domain.Command/
COPY ./Nora.Orders.Domain.Query/Nora.Orders.Domain.Query.csproj/ Nora.Orders.Domain.Query/
COPY ./Nora.Orders.Grpc/Nora.Orders.Grpc.csproj/ Nora.Orders.Grpc/
COPY ./Nora.Orders.Infrastructure.Database/Nora.Orders.Infrastructure.Database.csproj/ Nora.Orders.Infrastructure.Database/

RUN dotnet restore
COPY . .

WORKDIR /src
RUN dotnet publish -c Release -o /app

# Stage 2

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine

WORKDIR /app
COPY --from=build /app .

ENV ASPNETCORE_URLS=http://+:8081
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 8081

ENTRYPOINT ["dotnet", "Nora.Orders.Api.dll"]