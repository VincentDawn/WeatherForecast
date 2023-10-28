# WeatherForecast

WeatherForecast is a web application that allows users to get weather forecasts. The application is built using ASP.NET Core 5.0, Entity Framework Core 5.0, and Razor Pages.

## Prerequisites

To run this project, you need to have the following software installed:

- .NET Core 5.0
- SQL Server

Also, for local debugging, set the ASPNETCORE_ENVIRONMENT environment variable to 'Development'.

## Setup

1. Clone this repository.
2. Install .NET Core 5.0 and SQL Server.
3. Set up the database by running Entity Framework migrations. This can be done by running the 'dotnet ef database update' command in the terminal.
4. Run the application using the 'dotnet run' command.

## Usage

To use the application:

1. Create an account by navigating to the registration page.
2. Log in using your account credentials.
3. Use the weather forecast feature to get weather forecasts.

## Code Convention and Styling Rules

This project uses StyleCop for enforcing style and consistency rules for C# code. StyleCop.Analyzers has been added as a NuGet package in the project and it will automatically check the code for style violations during build.

To install and use StyleCop:

1. StyleCop is already included in the project as a NuGet package. It does not require separate installation.
2. StyleCop will automatically check your code for style violations when you build the project.

The rules enforced by StyleCop can be configured by modifying the stylecop.json file in the project root.

## Contributing

Contributions are welcome. Please make contributions via pull requests. Ensure all tests pass and adhere to the existing coding style.

## License

This project is proprietary. All rights are reserved.
