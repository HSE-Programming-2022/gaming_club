FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["backendApi.csproj", "./"]
RUN dotnet restore "backendApi.csproj"
COPY . .
RUN dotnet publish "backendApi.csproj" -c Release -o /app/publish


FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "backendApi.dll"]
