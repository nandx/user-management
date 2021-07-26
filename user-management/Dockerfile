FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["user-management/user-management.csproj", "user-management/"]
RUN dotnet restore "user-management/user-management.csproj"
COPY . .
WORKDIR "/src/user-management"
RUN dotnet build "user-management.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "user-management.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "user-management.dll"]
