#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["QuizAPI/QuizAPI.csproj", "QuizAPI/"]
RUN dotnet restore "QuizAPI/QuizAPI.csproj"
COPY . .
WORKDIR "/src/QuizAPI"
RUN dotnet build "QuizAPI.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "QuizAPI.csproj" -c Debug -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QuizAPI.dll"]