# Brain.API 

## Properties
* This API is created using the following technologies: ServiceStack, ASP.Net, MOQ, Funq and Swagger
* The solution is divided into the following projects

|	Project|Description
-------|----------------
| Brain.API | Web application 		
| Brain.API.Console | Allows hosting of the API without IIS
| Brain.API.Managers | Contains business logic										
| Brain.API.ServiceDefinition | Contains methods for the routes
| Brain.API.ServiceModel | Contains entities, request and response objects
| Brain.API.UnitTest | Contains sample unit tests

## Configuration values In App.Config and Web.Config
* GroupFileName: Name of the group file.
* PasswordfileName: Name of the password file.
* GroupFilePath: Location of the groupfile path. If this is not available it will default to the application root directory.
* PasswordfilePath:  Location of the password path. If this is not available it will default to the application root directory.
* LocalHost: Set the local host for the api. This is available only in the Brain.API.Console application App.COnfig

## Instructions on how to run the API

### Without Visual Studio
* Copy the Installation.zip file from [Installation](https://github.com/adibkhan/Brain.API/tree/master/Installation) to a local folder and unzip.
* Run the Brain.API.Console exe.
* Open a browser and go to http://localhost:1234.
* Under PluginLinks click Swagger UI to test the API (or use any other preferred HTTP client).
### With Visual Studio
* Open the Brain.API.sln file in a Visual Studio 2017.
* Set Brain.API.Console project as the startup project.
* Start the console app.
* Open a browser and go to http://localhost:1234.
* Under PluginLinks click Swagger UI to test the API (or use any other preferred HTTP client).

** Instructions on how to use swagger is provided in the SwaggerUI tutorial.docx file in [Installation](https://github.com/adibkhan/Brain.API/tree/master/Installation) folder.

## Test data
|	Route|Test data 
-------|----------------
| GET /User/GetUser/{uid}| 1 		
| GET /User/GetUsers|{Name:adib}, {Name:adib,Uid:12345,Gid:1002}	
| GET /Group/GetGroup/{gid}	| 1001 											
| GET /Group/GetGroups|{Name:devops,Gid:1234,Members:[adib,eugene]}
| GET /Group/GetGroups/{uid}| 1											

** Make sure to remove trailing spaces from the data while testing the routes.

## Other notes
* To keep things simple, all entity properties are declared as strings and route validation and logging was intentionally left out of this project.
* Dependency injection has been used in the manager classes to help with unit testing.

