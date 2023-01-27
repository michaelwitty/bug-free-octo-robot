# Phone Book App

## About

Simple CRUD application that allows you to view add edit and delete entries in a phone book.

Backend is build using EFCore and Web API as a single service.
Web front end is a simple React app.

### Prerequisites

1. .NET 6 SDK
2. SQL Server Instance or LocalDb
3. Ensure the connection string in appsettings.json is pointing to your SQL Server instance.

### Running in Visual Studio

Open the PhoneBookApp.sln in Visual Studio
Start Debugging

### Running via command line

Build and run the backend api in PhoneBookApp.Services.Contacts 
**dotnet run PhoneBookApp.Services.Contacts.csproj**

Build and run the React app in PhoneBookApp.Web
**npm run build**
**npm start**

Regardless of the startup method the app should run on 
[http://localhost:3000](http://localhost:3000)
And the backend should be running on 
[http://localhost:](http://localhost:5270)

Database migrations on each app start for convenience.