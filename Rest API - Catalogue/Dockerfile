FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base 
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["Catalogue/Catalogue.csproj", "Catalogue/"]
RUN dotnet restore "Catalogue/Catalogue.csproj"
COPY . .
WORKDIR "/src/Catalogue"
RUN dotnet publish "Catalogue.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Catalogue.dll"]


