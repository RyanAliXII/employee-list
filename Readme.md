# Employee List Application

## Task Description:

Create a simple Employee List Application with the following functionalities:

1. **Create new Employee**
2. **Update current Employee**
3. **View current Employee**
4. **Remove current Employee**
5. **View all Employees**

## Technology Stack:

- **Backend**: ASP.NET Core MVC (C#)
- **Frontend**: React 18.3.1 (TypeScript)
- **Database**: MSSQL (Microsoft SQL Server)

## Prerequisites:

Before setting up the project, make sure to install the following:

- [.NET SDK 8.0.200](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or an existing MSSQL instance
- [Visual Studio Code](https://code.visualstudio.com/), [Visual Studio](https://visualstudio.microsoft.com/) or any preferred IDE for .NET development
- [Node.js 20.13.1](https://nodejs.org/en/download/package-manager/current)

## What I Have Used:

- **Backend**: Built on [.NET SDK 8.0.200](https://dotnet.microsoft.com/download) using [ASP.NET Core MVC](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-8.0&tabs=visual-studio)
- **Frontend**: Developed with [React 18.3.1](https://react.dev/)
- **IDE**: [Visual Studio Code](https://code.visualstudio.com/)

## Database Setup:

1. **Update the Connection String**:

   - Modify the `appsettings.Development.json` file to include your database server and credentials:

     ```json
     "ConnectionStrings": {
        "DefaultConnection": "Server={HOST},{PORT}\\{HOSTNAME};Database={DATABASE_NAME};User Id={USERNAME};Password={PASSWORD};MultipleActiveResultSets=true;TrustServerCertificate=True;Integrated Security=False;"
     }
     ```

     Example:

     ```json
     "ConnectionStrings": {
        "DefaultConnection": "Server=127.0.0.1,1433\\mssql_22.04;Database=TechnicalTest;User Id=sa;Password=4Ps02MGHZRXMphc;MultipleActiveResultSets=true;TrustServerCertificate=True;Integrated Security=False;"
     }
     ```

2. **Using Docker**:

   - Alternatively, if you have Docker installed, you can run the **docker-compose.yaml** file to spin up the database container. This file includes the database version and configuration for development.

   - In the root directory of the project, run the following command:

     ```bash
     docker compose up -d
     ```

   - This command will start the necessary services, including MSSQL, using the configurations defined in the `docker-compose.yaml` file. You can now use this containerized database for development purposes.

3. **Verify Database Connection**:

   - Ensure that SQL Server (or the Docker container) is running and accessible at the configured IP/hostname and port.
   - Verify the credentials (username and password) are correct and that the database is available.

4. **Connecting to the Database**:

   - Once the database is running, use a tool like SQL Server Management Studio (SSMS) to connect to the database using the connection string details.

5. **Create Necessary Database Tables**:

   - To create the necessary database tables, navigate to the `EmployeeServer` directory and run the following command:

     ```bash
     dotnet ef database update
     ```

   - This command will apply any pending migrations and create the database schema as defined in your Entity Framework Core migrations.

## Running the Backend

1. **Navigate to the Backend Directory**:

   - Open your terminal or command prompt.
   - Change directory to the `EmployeeServer` folder where your backend project is located.
   - If you are using **Visual Studio**, there is a solution in the root directory that you can run.

2. **Start the Backend Application**:

   - Run the following command to start the application with live reloading enabled:

     ```bash
     dotnet watch
     ```

   - This command will compile and start the application. The `dotnet watch` command monitors changes in your source files and automatically restarts the application when changes are detected.

3. **Access the Application**:

   - Once the backend application is running, it will be accessible at `http://localhost:5010` (or another configured port).

4. **Verify Functionality**:

   - Open your web browser and navigate to the URL provided by the application to ensure it’s working as expected.
   - You should see the initial page of the Employee List Backend.

### API Endpoints

| HTTP Verb | Endpoint            | Description                      |
| --------- | ------------------- | -------------------------------- |
| GET       | /api/employees      | Get all employees                |
| GET       | /api/employees/{id} | Get a specific employee by ID    |
| POST      | /api/employees      | Create a new employee            |
| PUT       | /api/employees/{id} | Update an employee's information |
| DELETE    | /api/employees/{id} | Remove an employee               |

## Running the Frontend

1. **Navigate to the Frontend Directory**:

   - Open your terminal or command prompt.
   - Change directory to the `SPA` folder where your frontend project is located.

2. **Install Required Modules**:

   - Run the following command to install necessary Node.js modules:

     ```bash
     npm install
     ```

3. **Start the Frontend Application**:

   - Run the following command to start the frontend application:

     ```bash
     npm run dev
     ```

4. **Access the Application**:

   - By default, the frontend application will be accessible at `http://localhost:5173` (or another configured port).

5. **Verify Functionality**:

   - Open your web browser and navigate to the URL provided by the application to ensure it’s working as expected.
   - You should see the initial page of the Employee List Application.

## Running the Test

1. **Navigate to the Test Directory**:

   - Open your terminal or command prompt.
   - Change directory to the `EmployeeServerTest` folder where your test project is located.

2. **Run the Tests**:

   - Execute the following command to run all tests:

     ```bash
     dotnet test
     ```

   - For more detailed output, you can use:

     ```bash
     dotnet test -l "console;verbosity=normal"
     ```

   - This command will provide more verbose information during the test execution, which can help in debugging any issues
