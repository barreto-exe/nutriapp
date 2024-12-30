# Welcome to the NutriApp API! 🥗💧

This API is designed to support the NutriApp, a platform for managing nutritional information and tracking water consumption. With NutriApp, users can easily manage their dietary habits and water intake, making healthy living more convenient and accessible.

## Technologies Used 💻

- **.NET 8** - The NutriApp API is built using .NET 8, a cross-platform framework for building modern applications.
- **Entity Framework Core** - Entity Framework Core is used as the Object-Relational Mapping (ORM) framework for the NutriApp API. It provides a simple way to interact with the database and map database entities to C# objects.
- **SQL Server** - SQL Server is used as the database for the NutriApp API. It is a popular relational database management system known for its performance, scalability, and reliability.
- **JWT** - JSON Web Tokens (JWT) are used for authentication and authorization in the NutriApp API. JWT is a standard for securely transmitting information between parties as a JSON object.
- **Swagger** - Swagger is used for API documentation and testing. It provides a user-friendly interface for exploring and testing the API endpoints.
- **Visual Studio** - Visual Studio is used as the Integrated Development Environment (IDE) for the NutriApp API. It provides a powerful set of tools for building, testing, and debugging .NET applications.

These technologies were chosen for their reliability, performance, and ease of use. They provide a solid foundation for building a robust and scalable API that can meet the needs of the NutriApp community.

## Quick start 🚀

### 1. **Install .NET 8 and Visual Studio**

Make sure you have .NET 8 and Visual Studio installed on your machine. You can download .NET 8 from the [official .NET website](https://dotnet.microsoft.com/download/dotnet/8.0), and Visual Studio from the [Visual Studio website](https://visualstudio.microsoft.com/).

### 2. **Clone the repository**

Clone the NutriApp API repository to your local machine using Git.

```sh
git clone https://github.com/yourusername/nutriapp.git
```

### 3. **Create a SQL Server database**

Create an empty SQL Server database and save the connection string to use in the next steps.

### 4. **Add the required keys to appsettings.Development.json**

These keys are required for the API to function properly.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "SqlConnectionString": "Your SQL Server connection string here"
  }
}
```

### 5. **Open the project in Visual Studio**

Open the NutriApp API project in Visual Studio by navigating to the project folder and double-clicking on the nutriapp.sln file.

### 6. **Run Database Migrations**

Before running database migrations, it's important to understand why they are necessary. Database migrations are used to keep the database schema in sync with the application's codebase. To sync your database with the tables that the project needs, follow these steps:

- Open the NutriAppContext.cs file located in Data.
- Ensure the connection string in the OnConfiguring method is set to your SQL Server connection string.
- Open the NuGet Package Manager Console.
- Run the following command to run the migrations. This will create all the tables in your database:

```sh
Update-Database
```

### 7. **Run the project**

Run the project by clicking on the "Run" button in Visual Studio. This will launch the API and allow you to start making requests.

### 8. **Start making requests**

You can go to `/swagger` to start making requests to the NutriApp API. Refer to our documentation for more information on how to use the API.

### It's done!

That's it! You are now ready to start using the NutriApp API. If you have any questions or issues, please refer to our documentation or contact our support team. 📚📞
