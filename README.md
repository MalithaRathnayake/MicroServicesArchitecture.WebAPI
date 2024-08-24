Instructions :

1. Please download zip file or clone the project of below git hub repository. 
      Url: 
 https://github.com/MalithaRathnayake/MicroServicesArchitecture.WebAPI

2. Target framework : .NET 6

3. Microservice Architecture is implemented in this project, There will be two    	separate .Net Core Web Api projects created as , 
     		KooBits.MicroServices.UserServices,
    		KooBits.MicroServices.OrderService.
     Both will be contain separate Entityframework core Inmemory DBs.  

4.Set  KooBits.MicroServices.UserServices,    		KooBits.MicroServices.OrderService as startup projects and run the solution

5.Swagger Api documentation provided for Api Testing.

6.Default .net Dependency Injection is used in this project.

7.Added TODO comments to explain assumptions made and suggest project Rewamp ideas.

8.Testing : Once the project started successfully please use Swagger documentaion for testing below Apis,
   
      Users Microservice
 
      GET
      /api/Users

      POST
      /api/Users

      GET
      /api/Users/{id}
      
      Order Microservice : 
       Note: User have to be save first before trying to save Order, Saved use Id should be provided when saving an Order.: 
        
         GET
         /api/Order
         
         POST
         /api/Order
         
         GET
        /api/Order/{id}
