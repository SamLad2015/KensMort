# kensmort
This repository has been created to host a project created as a Technical test for kensmort.

## Getting Started
you should have some knowledge of running .net core projects and running npm commands in order to run this project

### Prerequisites
In order to run this project the following are the Pre-requisites:
1) Visual Studio 2020 or any IDE of your choice that supports .net core projects
2) Visual Studio Code or any IDE of your choice that supports Angular CLI projects
3) .Net core frame work 3.1
4) Node js v12.18.0
5) npm version 6.14.4
6) Sql Serve

## Running the Project
1) Get the latest code from the repository and start in Visual Studio or IDE of your choice
2) Make sure you have a database called kensmort set up with read/write access. Under the Data folder locate the initial set up sql script 0001.sql and run it.
3) Modify the connection string under app settings of the api project and Build the project. If on your local machine a trust certificate (which is mandatory to run .net core APIs) is not added then it will be asked. 
you can get more help about it here. https://docs.microsoft.com/en-us/aspnet/core/security/authentication/certauth?view=aspnetcore-3.1
4) Project should contain a 'ui' directory which holds the front end Angular 9 code. Please open a terminal on the ui directory path.
5) Run 'npm install' which will download all necessary npm packages required to run the front end project. You may be asked to run 'npm audit fix' to resolve all dependencies.
Please do if you have been asked to do so.
6) Run the Test Api project. This should start a swagger portal.
7)You can test the current version of the API here, please use version number as 1 in order to test it.
8) Run 'ng serve' to run the front end project. Once it is completed it will prompt to open the front end portal on http://localhost:4200/
9) Make sure that the api is running on 'https://localhost:5001/' though which would be confirmed when swagger is up and running. Front End portal should look as below:




This Project is covered under open source MIT License.
