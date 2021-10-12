FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Skeleton/Skeleton.csproj", "Skeleton/"]
RUN dotnet restore "Skeleton/Skeleton.csproj"
COPY . .
WORKDIR "/src/Skeleton"
RUN dotnet build "Skeleton.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Skeleton.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Skeleton.dll"]
