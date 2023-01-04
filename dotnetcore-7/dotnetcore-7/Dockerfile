#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["dotnetcore-7/dotnetcore-7.csproj", "dotnetcore-7/"]
RUN dotnet restore "dotnetcore-7/dotnetcore-7.csproj"
COPY . .
WORKDIR "/src/dotnetcore-7"
RUN dotnet build "dotnetcore-7.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dotnetcore-7.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dotnetcore-7.dll"]