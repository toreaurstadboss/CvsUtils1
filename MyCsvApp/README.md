# MyCsvApp

This project is a C# application that provides utility methods for handling CSV data. It includes a main application project and a separate project for unit tests.

## Project Structure

```
MyCsvApp
├── MyCsvApp.sln
├── MyCsvApp
│   ├── MyCsvApp.csproj
│   └── CsvUtils.cs
├── MyCsvApp.Tests
│   ├── MyCsvApp.Tests.csproj
│   └── CsvUtilsTest.cs
└── README.md
```

## Setup Instructions

1. **Clone the repository**:
   ```
   git clone <repository-url>
   cd MyCsvApp
   ```

2. **Open the solution**:
   Open `MyCsvApp.sln` in your preferred C# development environment.

3. **Restore dependencies**:
   Run the following command to restore the necessary packages:
   ```
   dotnet restore
   ```

4. **Build the application**:
   To build the application, use:
   ```
   dotnet build
   ```

5. **Run the tests**:
   To execute the unit tests, navigate to the test project directory and run:
   ```
   dotnet test
   ```

## Usage

The `CsvUtils` class provides methods for sanitizing and processing CSV data. You can use these methods in your application to handle CSV inputs effectively.

## Contributing

Contributions are welcome! Please submit a pull request or open an issue for any enhancements or bug fixes.