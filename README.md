# Bluebox
Backend: .Net Core 3.1 (Web API)
Frontend: Angular 14

## Backend - Web API
Our Application has mainly 3 layers.
1. Web API 
    -   This is the entry point which contains all the API controllers. 
    -   It calls Services in Business Layer to get the Data.
2. Business Layer 
    -   Contains all the Business Logic
3. Data Layer 
    -   Contains all the POCO classes, Migrations, Base Repositroy, etc.

In order to run the API, clone the repository and follow below steps.

1. Application Configuration related changes (appsettings.json)
- **ConnectionStrings**: Set below field in order to update your Connection String for the database.
```javascript
    "ConnectionStrings": {
        "ApplicationConnection": "YOUR CONNECTION STRING"
    }
```
2. Run below command in package manager console. (Please make sure to select "Data" as project in the console.)
```bash
    Update-Database
``` 
Once command is completed running, you will see tables like Movie, MovieImages, etc are created in the DB.

## FrontEnd - Site
Front end is created in Angular 14 and Bootstrap is being used as UI framework. In order to get the Movie List, we have created Movie Service and Movie List compoent to fetch data from API and display data respectively. 

Base API URL is in environment.ts file.
```javascript
export const environment = {
  production: false,
  baseUrl: 'https://localhost:44399/'
}
``` 

In order to run the project follow the below steps:
1. Intall Packages. Run below command to intall the packages.
```bash
    npm install
``` 
2. Once all the packages are installed, run the site using below command. 
```bash
    ng serve
``` 
