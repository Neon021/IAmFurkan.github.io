# This is the source code of the [Blog page made in .NET5 w/ ASP.NET CORE MVC](https://github.com/Neon021/MyBlog)


- [Overview](#overview)
- [Service Architecture](#service-architecture)
- [Technologies](#technologies)
- [Architecture](#architecture)
- [VS Extensions](#vscode-extensions)


# Overview

<p>In this project I've created a fully fledged working blog page made in ASP.NET CORE MVC w/ EF Core that supports CRUD operations, Authorization, E-mail service and Pagination!</p>

# Application Architecture
- As I mentioned above, I've used MVC Model -which stands for Model,Controller and View- for this project.
- I've used *Repostiory* pattern in order to ensure uncoupling between services and scalability.
- On top of that we've got <code>Data.FileManager</code> to help manage images in our application.

# Technologies
- ASP.NET CORE 5
- Entity Framework
- SQL Server
- PhotoSauce.MagicScaler

# Architecture
- MVC Model
- Repository Pattern
- Code First 
- Little functional programming <code>Func<TOut, TIn></code>


# VS Extensions
- [DocumetMaker](https://github.com/PaoloCattaneo92/DocumentMaker)

- [Entity Framework](https://github.com/dotnet/ef6) - EF Core is a data access API that allows you to interact with the database using .NET POCOs (Plain Old CLR Objects) and strongly-typed LINQ.

- [PhotoSauce.MagicScaler](https://github.com/saucecontrol/PhotoSauce) - MagicScaler high-performance, high-quality image processing pipeline for .NET.
