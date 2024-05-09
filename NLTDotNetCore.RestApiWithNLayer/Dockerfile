FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["NLTDotNetCore.RestApiWithNLayer/NLTDotNetCore.RestApiWithNLayer.csproj", "NLTDotNetCore.RestApiWithNLayer/"]
RUN dotnet restore "NLTDotNetCore.RestApiWithNLayer/NLTDotNetCore.RestApiWithNLayer.csproj"
COPY . .
WORKDIR "/src/NLTDotNetCore.RestApiWithNLayer"
RUN dotnet build "NLTDotNetCore.RestApiWithNLayer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NLTDotNetCore.RestApiWithNLayer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NLTDotNetCore.RestApiWithNLayer.dll"]
