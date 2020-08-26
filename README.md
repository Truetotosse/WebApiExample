## Overview

This tutorial demonstrates how to create a distributed application that uses the DevExpress ORM Library (XPO) to remotely access and manage data. In this tutorial, service stores data [in memory](https://docs.devexpress.com/XPO/DevExpress.Xpo.DB.InMemoryDataStore) in the JSON format, client uses [WebAPI](https://docs.devexpress.com/XPO/DevExpress.Xpo.DB.WebAPIDataStore).


## Prerequisites
# Service
* [Visual Studio 2019 16.4.5 or later](https://visualstudio.com/) with the following workloads:
  * **ASP.NET and web development**
  * **.NET Core cross-platform development**
* [.NET Core 2.1 SDK or later](https://www.microsoft.com/net/download/all)
# Client using .NET Framework
* [Visual Studio 2019 16.4.5 or later](https://visualstudio.com/) with the following workloads:
  * **ASP.NET and web development**
  * **.NET Framework cross-platform development**
* [.NET Framework 4.5.2 or later](https://www.microsoft.com/net/download/all)

This app uses the .NET Framework for Client application, but .NET Core application is also possible.

## Step 1: Create a Service app

1. Open Visual Studio and create a new project.
2. Search for the **Blazor App** template.

3. Set the project name to **BlazorServerSideApplication** and click **Create**.


4. Select **Blazor Server App** and click **Create**.


5. In the **Solution Explorer**, remove the unnecessary **Data** folder and the following files from the **Pages** folder:

  

6. Open *Shared\NavMenu.razor* and comment out the following lines:
  

For more information, see the following:

* [Introduction to Blazor](https://docs.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-3.0)
* [DevExpress UI for Blazor Demos](https://github.com/DevExpress/Blazor)

## Step 2: Create a Client app

1. Open Visual Studio and create a new project.
2. Search for the **Blazor App** template.

3. Set the project name to **BlazorServerSideApplication** and click **Create**.


4. Select **Blazor Server App** and click **Create**.


5. In the **Solution Explorer**, remove the unnecessary **Data** folder and the following files from the **Pages** folder:

  

6. Open *Shared\NavMenu.razor* and comment out the following lines:
  

For more information, see the following:

* [Introduction to Blazor](https://docs.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-3.0)
* [DevExpress UI for Blazor Demos](https://github.com/DevExpress/Blazor)

## Step 3: Create ORM Data Model inside client.

1. In the **Solution Explorer**, add the *Customer.cs*  code file. 


2. Replace its contents with the code copied from the [corresponding files under this folder](https://github.com/DevExpress/XPO/tree/master/Tutorials/ASP.NET/Blazor.ServerSide/CS/DataAccess). This file contain the following class:
    * `Customer`: implement the persistent data model that maps to the corresponding tables in the database.
    

For more information, see the following:

  * [Object Relational Mapping](https://docs.devexpress.com/XPO/2017/feature-center/object-relational-mapping)
  * [Persisting Objects](https://docs.devexpress.com/XPO/2025/feature-center/data-exchange-and-manipulation/persisting-objects)


## Step 5: Configure Database Connection and Plug in the ORM Data Model

1. In *Startup.cs*, modify the `Startup.ConfigureServices` method to configure Dependency Injection services for JSON serialization, database connection, and CRUD operations with XPO.

    The modified code is as follows:

    ```csharp
    
            }
    //...
    }
    ```

2. In *Startup.cs*, modify the `Startup.Configure` method and add the ; 

    The modified code is as follows:
    ```csharp
    
    
    ```

3. In *appsettings.json*, add the connection string for an in-memory or other [supported database system](https://docs.devexpress.com/XPO/2114/fundamentals/database-systems-supported-by-xpo).

    The modified code is as follows:

    ``` 
    ```

For more information, see the following topics:
  * [How to create a connection string for XPO providers](https://www.devexpress.com/Support/Center/Question/Details/K18445/how-to-create-a-correct-connection-string-for-xpo-providers)  
  * [Unit of Work](https://docs.devexpress.com/XPO/2138/feature-center/connecting-to-a-data-store/unit-of-work)
  * [Configuration](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/index?view=aspnetcore-3.0)
  * [Dependency injection in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.0)
  * [ASP.NET Core Dependency Injection in XPO](https://www.devexpress.com/Support/Center/Question/Details/T637597/asp-net-core-dependency-injection-in-xpo)




## Step 6: Run and Test the App

1. Press **F5** in XpoWebApi solution to build and run the Service application.
2. Press **F5** in XpoWebApiClient solution to build and run the Service application.

## Known Issues

* readme doesnt lead to success
