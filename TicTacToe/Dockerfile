# In main folder run: docker build -f TicTacToe/Dockerfile .

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

COPY TicTacToe /src/TicTacToe
RUN dotnet publish /src/TicTacToe/TicTacToe.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
EXPOSE 5000
COPY --from=build /app .
ENTRYPOINT ["dotnet", "TicTacToe.dll"]