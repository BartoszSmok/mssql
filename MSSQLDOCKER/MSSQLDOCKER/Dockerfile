#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MSSQLDOCKER/MSSQLDOCKER.csproj", "MSSQLDOCKER/"]
RUN dotnet restore "MSSQLDOCKER/MSSQLDOCKER.csproj"
COPY . .
WORKDIR "/src/MSSQLDOCKER"
RUN dotnet build "MSSQLDOCKER.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MSSQLDOCKER.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MSSQLDOCKER.dll"]
