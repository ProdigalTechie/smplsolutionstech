# smplsolutionstech
A community-driven Solutions as a Service to make the future of development Smpl! Users will have access to generate projects and files that are templated to the best practices of both previous and current programming languages. SmplSolutionsTech is here to be a solution to enter information once an get the templated resources you need to accelerate your project. We are a launching pad for your developer journey and any and all are welcome to help contribute!

## How can you contribute?
### Current HTML/CSS pages that needs some love:
#### Privacy.cshtml page
##### Details
The privacy page is in desperate need of someone to format the wall of text into a clean HTML page with maybe a splash of CSS. You should be able to work and load this page in your browser without having to build the project.

##### Paths
Privacy.cshtml is located in SmplSolutionsTech/Pages/Home/Privacy.html
privacy.css is located in SmplSolutionsTech/wwwroot/css/privacy.css

##### Questions
If there are any questions please reach out to me on github: https://github.com/ProdigalTechie or create an issue in the repo: https://github.com/ProdigalTechie/smplsolutionstech/issues.

## How to run the project locally?
To contribute fork or clone the ***checkout*** repository: https://github.com/ProdigalTechie/smplsolutionstech

Some prerequisites you’ll want to have (not required to contribute but would be usefull):

1) Install Visual Studio 2022 (Community is free) https://visualstudio.microsoft.com/downloads/
2) Install .NET 6.0.4 SDK and Runtime 6.0.9 https://dotnet.microsoft.com/en-us/download/dotnet/6.0 
3) Some experience with Razor Pages
4) Some experience with the dotnet cli (again total noob here!)
5) dotnet tools install --global dotnet-ef (from command line while inside the SmplSolutionsTech folder)
6) dotnet ef migrations add InitialCreate then dotnet ef database update (this creates a new migration and the database with the Identity tables)
7) Verify the database created an auth.AppUser table (if there is an auth.AppNetUsers table rename it to auth.AppUser)
8) insert into auth.AppRole ('RoleName') values ('Jr. Dev') using SQL script from VS 2022 or SSMS
9) Register a new user then update the user EmailConfirmed column in the auth.AppUser table via SQL.

For Windows Users:
1) Click on the Start Menu and type Environment Variables
2) Click on Edit the System Environment Variables
3) Click Environment Variables in the System Variables find the Variable named Path and select it
4) Click Edit Look to see if C:\Program Files\nodejs\ is listed if not
    a. Click New
    b. And add C:\Program Files\nodejs\

For Mac and Linus Users:
1) Please consult online resources for how to perform this

## Notice
This project is open-source for development and contributing purposes only. Any replication or reproduction of this project is prohibited.
