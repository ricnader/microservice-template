#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Web/Vertem.Agrega.Distribuitor.Api/Vertem.Agrega.Distribuitor.Api.csproj", "src/Web/Vertem.Agrega.Distribuitor.Api/"]
COPY ["src/Core/Vertem.Agrega.Application/Vertem.Agrega.Application.csproj", "src/Core/Vertem.Agrega.Application/"]
COPY ["src/Core/Vertem.Agrega.Infra/Vertem.Agrega.Infra.csproj", "src/Core/Vertem.Agrega.Infra/"]
COPY ["src/Core/Vertem.Agrega.Domain/Vertem.Agrega.Domain.csproj", "src/Core/Vertem.Agrega.Domain/"]
COPY ["src/Ioc/Vertem.Agrega.Ioc/Vertem.Agrega.Ioc.csproj", "src/Ioc/Vertem.Agrega.Ioc/"]
RUN dotnet restore "src/Web/Vertem.Agrega.Distribuitor.Api/Vertem.Agrega.Distribuitor.Api.csproj"
COPY . .
WORKDIR "/src/src/Web/Vertem.Agrega.Distribuitor.Api"
RUN dotnet build "Vertem.Agrega.Distribuitor.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Vertem.Agrega.Distribuitor.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 5000/tcp
ENV ASPNETCORE_URLS=http://*:5000
ENV ASPNETCORE_ENVIRONMENT=Development
ENTRYPOINT ["dotnet", "Vertem.Agrega.Distribuitor.Api.dll"]
EXPOSE 443