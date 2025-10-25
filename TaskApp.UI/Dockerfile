# Step 1: Build the .NET app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src


COPY . .

# Restore dan publish projek UI
RUN dotnet restore "./TaskApp.UI/TaskApp.UI.csproj"
RUN dotnet publish "./TaskApp.UI/TaskApp.UI.csproj" -c Release -o /app/publish

# Step 2: Run stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "TaskApp.UI.dll"]
