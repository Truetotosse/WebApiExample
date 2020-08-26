## Overview

This tutorial demonstrates how to create a distributed application that uses the DevExpress ORM Library (XPO) to remotely access and manage data. In this tutorial, service stores data [in memory](https://docs.devexpress.com/XPO/DevExpress.Xpo.DB.InMemoryDataStore) in the JSON format, client uses [WebAPI](https://docs.devexpress.com/XPO/DevExpress.Xpo.DB.WebAPIDataStore).


## Prerequisites
### Service
* [Visual Studio 2019 16.4.5 or later](https://visualstudio.com/) with the following workloads:
  * **ASP.NET and web development**
  * **.NET Core cross-platform development**
* [.NET Core 2.1 SDK or later](https://www.microsoft.com/net/download/all)
### Client using .NET Framework
* [Visual Studio 2019 16.4.5 or later](https://visualstudio.com/) with the following workloads:
  * **ASP.NET and web development**
  * **.NET Framework cross-platform development**
* [.NET Framework 4.5.2 or later](https://www.microsoft.com/net/download/all)

This app uses the .NET Framework for Client application, but .NET Core application is also possible.

## Step 1: Create a Service app

   
### Create project

1. Open Visual Studio and create a new project.

2. Search for the ASP.NET Core Web Application.

3. Set the project name to **WebApiService** and click **Create**.

4. Select **Empty** and click **Create**.

5. Open *Startup.cs* and replace its contents with the code from [corresponding file under this folder](https://github.com/Truetotosse/WebApiExample/tree/master/XpoWebApiService). It will add services initialization and connection to In Memory Data

6. Open *properties\launchSettings.json* and set `applicationUrl` under `WebApiService` to http://localhost:5000, `launchBrowser` to `false`. 

7. In the **Solution Explorer**, create **Controllers** folder and add *XPOController.cs* into it

8. Replace *XPOController.cs* contents with the code from [corresponding file under this folder](https://github.com/Truetotosse/WebApiExample/tree/master/XpoWebApiService/Controllers). This code initiates WebApiHelper to handle reqests from client application.
  

### Add the XPO Package

Use any of the following approaches to install the XPO package:

**Package Manager Console**

  * From the Visual Studio **Tools** menu, select **NuGet Package Manager > Package Manager Console**.
  * Make sure **Package source** is set to **All**, **nuget.org** or **DevExpress 20.2 Local** and run the following command: 
     ```console
    Install-Package DevExpress.Xpo -Version 20.2
    ```

**NuGet Package Manager**

  * In **Solution Explorer**, right-click the project name and select **Manage NuGet Packages**. 
  * Make sure **Package source** is set to **All**, **nuget.org** or **DevExpress 20.2 Local** on the right.
  * In the top left corner under **Browse**, search for the `DevExpress.Xpo` package and select the latest version, v20.2, on the right.
  * Click **Install** and accept all licenses in the **License Acceptance** dialogs. 
    
For more information, see the following:

  * https://www.nuget.org/
  * https://nuget.devexpress.com/
  * [Configuration](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/index?view=aspnetcore-3.0)
  * [Dependency injection in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.0)
  * [ASP.NET Core Dependency Injection in XPO](https://www.devexpress.com/Support/Center/Question/Details/T637597/asp-net-core-dependency-injection-in-xpo)


## Step 2: Create a Client app

1. Open Visual Studio and create a new project.

2. Search for the **Console app (.NET Framework)** template.

3. Set the project name to **WebApiClient** and click **Create**.

4. In the **Solution Explorer**, add *Customer.cs* class to your solution and replace its contents with the code from [corresponding file under this folder](https://github.com/Truetotosse/WebApiExample/tree/master/XpoWebApiClient/XpoWebApiClient). This code implements basic Customer persistent object.

  

6. Open *Program.cs* and add following lines inside Main method:
```csharp
	    IDataStore dataStore = new WebAPIDataStore("http://localhost:5000/");
            IDataLayer dataLayer = new SimpleDataLayer(new ReflectionDictionary(), dataStore);
            UnitOfWork uow = new UnitOfWork(dataLayer);
            Customer newCustomer  = new Customer(uow) {
                FirstName = "Customer",
                LastName = "FoundFirst"
            };
            
            uow.Save(newCustomer );

            newCustomer  = new Customer(uow) {
                FirstName = "Customer",
                LastName = "FoundSecond"
            };

	    uow.Save(newCustomer);
            uow.CommitChanges();

            Customer search = uow.FindObject<Customer>( CriteriaOperator.Parse("FirstName=?", "Customer"));
            Console.WriteLine(search.ContactName);
            
            uow.Delete(search);
            uow.CommitChanges();

            search = uow.FindObject<Customer>(CriteriaOperator.Parse("FirstName=?", "Customer"));
            Console.WriteLine(search.ContactName);

            Console.ReadKey();
  ```

For more information, see the following topics:
  * [How to create a connection string for XPO providers](https://www.devexpress.com/Support/Center/Question/Details/K18445/how-to-create-a-correct-connection-string-for-xpo-providers)  
  * [Unit of Work](https://docs.devexpress.com/XPO/2138/feature-center/connecting-to-a-data-store/unit-of-work)
  




## Step 3: Run and Test the App

1. Press **F5** in XpoWebApi solution to build and run the Service application.
2. Press **F5** in XpoWebApiClient solution to build and run the Service application.

Client will add two objects to the data provider, search for one, delete it and then search for the second one. 
