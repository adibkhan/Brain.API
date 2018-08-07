# Brain.API

## Properties
* This API is created using the following technologies: ServiceStack, ASP.Net, MOQ, Funq, Swagger
* It


## Instructions on how to run the service.

## Without visual studio
* Copy the Installation.zip file from [Installation](https://github.com/adibkhan/Brain.API/tree/master/Installation) to a local folder and unzip.
* Run the Brain.API.Console exe. 
* Open a browser and go to http://localhost:1234
* Under PluginLinks click Swagger UI

## With visual studio
* Open the Brain.API.sln file in a Visual studio 2017
* Set Brain.API.Console project as the startup project
* Start the console app
* Open a browser and go to http://localhost:1234
* Under PluginLinks click Swagger UI

## Config values
* GroupFileName: Name of the group file 
* PasswordfileName: Name of the password file
* GroupFilePath: Location of the groupfile path. If this is not available it will default to the application root directory.
* PasswordfilePath:  Location of the password path. If this is not available it will default to the application root directory.
* LocalHost: Set the local host for the api. This is available only in the Brain.API.Console application.

## Data to test the routes
|	Route|Test data  <br/>
-------|----------------
| GET /User/GetUser/{uid}	  | 1 <br/>			
| GET /User/GetUsers		      |{Name:adib}, {Name:adib,Uid:12345,Gid:1002}	<br/>
| GET /Group/GetGroup/{gid}	| 1001 <br/>											
| GET /Group/GetGroups		    |{Name:devops,Gid:1234,Members:[adib,eugene]}	<br/> 
| GET /Group/GetGroups/{uid}| 1	<br/>											

* Make sure to remove trailing spaces while testing the routes.

## Other Notes
* Instructions on how to use swagger is provided in the Installtion folder
