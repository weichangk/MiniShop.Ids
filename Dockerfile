#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM registry.cn-hangzhou.aliyuncs.com/newbe36524/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM registry.cn-hangzhou.aliyuncs.com/newbe36524/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MiniShop.Ids/MiniShop.Ids.csproj", "MiniShop.Ids/"]
RUN dotnet restore "MiniShop.Ids/MiniShop.Ids.csproj"
COPY . .
WORKDIR "/src/MiniShop.Ids"
RUN dotnet build "MiniShop.Ids.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MiniShop.Ids.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MiniShop.Ids.dll"]