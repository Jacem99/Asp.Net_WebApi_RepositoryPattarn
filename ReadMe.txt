- This My Simple Repository Pattern by ( Unit Of Work )

- inside it , two classes ( Teacher , Subject ) and Realationship Between Them => One To Many 

- It classfiy to 3 structure 
	1- RepositoryPattarnUOW.Api
	2- RepositoryPattarnUOW.Core
	3- RepositoryPattarnUOW.EF

- The Folder that you need to project :
		1- RepositoryPattarnUOW.Api => Controllers
		2- RepositoryPattarnUOW.Core => Models / Interfaces(IRepository) / Consts
		3- RepositoryPattarnUOW.EF => Migration / Repository


- When you run , the project open in Swagger :-)


## Problems ##
-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_

- When I get data from table Subject that have realtionShip with Teacher , I get this problem:

	"System.Text.Json.JsonException: A possible object cycle was detected. This can either be due to a cycle or if the object depth is larger than the maximum allowed depth of 32.
		 Consider using ReferenceHandler.Preserve on JsonSerializerOptions to support cycles."

-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_


Solution:
       1- go to NuGet Package Manager and install : Microsoft.AspNetCore.Mvc.NewtonsoftJson
       2- go to Starup.cs and Ad service :
        services.AddControllersWithViews().AddNewtonsoftJson(option =>
               option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
           
- To run my project , you have to install package 
	1- RepositoryPattarnUOW.Api =>  Microsoft.EntityFrameworkCore.Tools
	2- RepositoryPattarnUOW.Core => Microsoft.EntityFrameworkCore / - EntityFrameworkCore.SqlServer / Microsoft.EntityFrameworkCore.Tools
	3- go to RepositoryPattarnUOW.Api and appsettings and change ConnectionStrings with you server
	4- go to Package Manager Console and run command "update-database"
	5- # Run program and Enjoy in my simple project #

