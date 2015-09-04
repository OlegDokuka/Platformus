# Platformus

## Introduction

Platformus is free, open source and cross-platform CMS based on ASP.NET 5. It is build using the best and the most modern tools and languages (Visual Studio 2015, C#, TypeScript, SCSS etc). Join our team!

## Basic Concepts

Platformus is the object-oriented CMS and object is the central unit of its data model. Objects can be standalone and embedded. While standalone objects can be accessed via URL, embedded objects can only be part of others.

Each object consists of properties and relations and is described by its class. Classes describe properties and relations of the objects with the members. Each member has code, name, data type (for properties) or class (for relations). In addition, with the data sources, classes describe which objects are to be loaded together with the object.

For example, let’s say we have Developer class and Team class. Also, we can have Contact class too. Each developer should have first name and last name properties and one relation to the object of class Team and one or many relations to the objects of class Contact.

## Quick start

1. Open the solution (Platformus.sln) with Visual Studio 2015.
2. Wait until all dependencies are loaded.
3. Open Task Runner Explorer window.
4. Run “lib” task.
5. Run “rebuild” task (using TypeScript version 1.5).
6. Go to “Platformus\Startup.cs” and uncomment “*.Sqlite” or “*.SqlServer” (depending on the database you want to use).
7. Go to “Platformus\config.json” and specify the connection string to your database (for Sqlite it is only “Data Source=filename”).
8. Use “sqlserver.sql” or “sqlite.sql” script to create the database or to fill it with test data.
9. Run the web app.

## Links

Website: http://platformus.net/ (under construction)
Docs: http://docs.platformus.net/