# WeatherForecast

WeatherForecast is a web application that allows users to get weather forecasts. The application is built using ASP.NET Core, Entity Framework Core, and Razor Pages.

## Prerequisites

To run this project, you need to have the following software installed:

- .NET Core
- SQL Server

Also, for local debugging, set the ASPNETCORE_ENVIRONMENT environment variable to 'Development'.

## System Architecture

![System Architecture](./docs/images/system_architecture.png)

The system architecture diagram above illustrates the main components of the WeatherForecast application and their interactions. The application is built using ASP.NET Core and uses Entity Framework Core for data access. The user interface is built using Razor Pages. The application communicates with a SQL Server database for data storage. The application also interacts with an external weather API to fetch weather forecasts.

## Setup

1. Clone this repository.
2. Install .NET Core and SQL Server.
3. Set up the database by running Entity Framework migrations. This can be done by running the 'dotnet ef database update' command in the terminal.
4. Run the application using the 'dotnet run' command.

## Usage

To use the application:

1. Create an account by navigating to the registration page.
2. Log in using your account credentials.
3. Use the weather forecast feature to get weather forecasts.

## Contributing

Contributions are welcome. Please make contributions via pull requests. Ensure all tests pass and adhere to the existing coding style.

## License

This project is proprietary. All rights are reserved.
