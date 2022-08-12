#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Illegible_Cms_V2/Server/Illegible_Cms_V2.Server.csproj", "Illegible_Cms_V2/Server/"]
COPY ["Illegible_Cms_V2/Shared/Illegible_Cms_V2.Shared.csproj", "Illegible_Cms_V2/Shared/"]
COPY ["Illegible_Cms_V2/Client/Illegible_Cms_V2.Client.csproj", "Illegible_Cms_V2/Client/"]
RUN dotnet restore "Illegible_Cms_V2/Server/Illegible_Cms_V2.Server.csproj"
COPY . .
WORKDIR "/src/Illegible_Cms_V2/Server"
RUN dotnet build "Illegible_Cms_V2.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Illegible_Cms_V2.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Illegible_Cms_V2.Server.dll"]