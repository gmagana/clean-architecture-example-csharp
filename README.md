# Clean Architecture C# Example
## Introduction
One of the best ways to write software is to organize your project in a way that future development minimizes risk, does not break the code, and makes future changes inexpensive (in terms of time and effort/team size). This is an obvious point, one does not needs to be a software architect to arrive at the conclusion.  The problem is devising a way to get to that point.

To the rescue comes Clean Architecture, a [book](https://www.amazon.com/Clean-Architecture-Craftsmans-Software-Structure/dp/0134494164) written by [Robert C Martin](http://blog.cleancoder.com/), an experienced programmer and architect. From beginning to end, the book had me nodding in agreement with the key points in every chapter. I highly recommend reading the book to any software engineer, you will come out a better professional for it, guaranteed.

Clean Architecture defines a framework for implementing loosely coupled, scalable, extensible, and maintainable systems, but since the book and discussion is language and platform agnostic, going from theory to application on your favorite language/platform might be a bit daunting.

I looked around the web for a concrete example of Clean Architecture, something from which I could grow a new C# project, and I could find nothing suitable: Either the examples were trivially dumb (ie, implement the whole architecture in a single project and source code file, negating all the benefits of the architecture blueprint), or they were incomplete, talking about one single aspect of the entire system, ignoring the rest, and leaving you with far more questions than answers.

I decided to write my own proof of concept and starter project, and it's this project you're looking at right now.

The goal of this project is to give you the smallest, simplest possible, still-valid example of Clean Architecture in C#.
## How to use this code
You can use this project to see a fully implemented scaffold of a Clean Architecture in C# as you study the principles. You can also use this as a blank slate from which to build your systems.
### Compiling and running the code

There are two versions of this code, one for .NET 6.0 (Formerly .NET Core) and another for .NET Framework 4.8. They are both under the **src/** directory.

I've stopped adding features to the .NET Framework version of the system simply because .NET is now "the" framework to use for new development.  I will continue to update the referenced libraries, but no new features will be added.  

The code compiles and runs as-is, and runs with a bare-bones of interaction between components in "the Clean Architecture way" so you can see it in action and start experimenting right away.

There is only one external dependency built into the project, and that is the [Lamar IoC library](https://jasperfx.github.io/lamar/), which is included into the applicable projects as NuGet packages.
## Understanding the code
Certainly you would do well to understand the Clean Architecture principles by reading the book, linked above.

### Clean Architecture Principles
The central point of the book is this diagram:

![The Clean Architecture Diagram](https://github.com/gmagana/clean-architecture-example-csharp/raw/master/architecture-diagram/TheCleanArchitecture.jpg)

The outer ring contains code that deals with the "details", and each embedded ring goes up in abstraction, until you arrive at the Entities.

The idea is that abstract code should never directly reference or call code that is less abstract (that deals with details). Any interaction of that type should be done through well-defined. platform-agnostic interfaces only. The platform-agnostic part is extremely important. For example, the Use Cases should not contain data elements that reflect the database structure. It might make sense, for example, to hold a sales record object in memory in a data structure that does not mirror the database table structure used to store that information. Concerns about normalization, data duplication and de-duplication for performance are not the Use Cases' problem.  One of the main goals of Clean Architecture is to keep those structures independent: On the one hand, you are liberated to change your database structure (and platform!) liberally, without affecting Use Cases. On the other hand, you are creating data structures that are potentially largely duplicates of one another.

As elegant as the principles and the above diagram are, it's difficult to imagine what the actual project structure will be from the diagram alone. It's almost impossible to envision all the details that will cone up when turning such an abstract design into actual code that compiles cleanly and still maintains all the benefits of the abstract idea.
### Clean Architecture implementation of this solution
This is the diagram of the project in this repository (Get the [PNG](https://github.com/gmagana/clean-architecture-example-csharp/raw/master/architecture-diagram/Clean%20Architecture%20Example%20CSharp.png) or get the [Visio source file](https://github.com/gmagana/clean-architecture-example-csharp/raw/master/architecture-diagram/Clean%20Architecture%20Example%20CSharp.vsdx)):

![C# Clean Architecure bare bones implementation](https://github.com/gmagana/clean-architecture-example-csharp/raw/master/architecture-diagram/Clean%20Architecture%20Example%20CSharp.png)

Ok, so some explanation is in order :-).

I implement each group of code as class libraries. Each class library has code that:
- Does something related and needs to be grouped together to make sense.
- Shares isolation requirements. For example, the Interactor Data Models library could very well be part of the Interactor class library, but since the interactor data models need to be referrable by other class libraries that should not have access to all the Interactor symbols, I made it its own stand-alone class library.

The code is organized per the Clean Architecture mandate:

 - Level 0 is the most abstract of the system and contains only the Enterprise-wide entities.
 - Level 1 is the Interactor. This level contains the use cases of the system and business rules.  It could be said this is "the meat" of the system.
 - Level 1.5 is the Boundary between the Interactor and the system clients. Basically the Boundary tells the clients how to access the system, providing them with an API defined in an interface, and the data models used by that API.
 - Level 2 are the details of the system. This level includes the client code and also the data store. In traditional (but very buggy and fragile) development efforts, this level is the one that dominates the system's architecture. Clean Architecture flips the model upside down and reduces the clout of both of these types of components.
### Individual class descriptions and notes
- Abstraction Level 0 - Entities
  - **Entities** - These are the enterprise-wide data entities the project will use. These data entities are the data entities the system will use, and should contain business rules of the entities, but should _not_ contain business rules about interaction between these entities.
- Abstraction Level 1 - Interactor and Use Cases
  - **Interactor** - This is where the business rules and use cases are implemented. This class is also the main point of contact for the clients.
  - **Interactor Data Models** - These are the data models used internally by the Interactor. For example, one of these data models might be hold information about a user, his privileges, and his activity history in the system.  These data models might be referenced by several other components in the system that should not also be referencing the Interactor directly, and so we put these into their own class library.  It's important to note that the data models contained here should only hold the data, and should not have code implemented in them. This code to manipulate the models is the job of the Interactor.
  - **Interactor Plugin** - As an example, I implemented a plugin subsystem in the Interactor. The plugin class library implements an interface that is defined in the Interactor, and the calls to the plugin are done indirectly, through that interface.  One think you might want to do in your own system architecture is to define that plugin interface in it's own class library so that plugin implementers do not reference the entire Interactor.
- Abstraction Level 1.5 - Client/Interactor Boundary
  - **Client Boundary** - This class library exposes to the clients three types of entities in the system: 1) The interface to the Interactor; 2) The request models (Which serve to prevent having the clients access the Interactor's data models directly); 3) The response models, which also work to decouple the client from the Interactor.  This is the only class library that the clients will have direct reference to.
- Abstraction Level 2 - Clients, Data Stores, and Other Details
  - Clients
    - **Client Application** - This is a standard Windows Forms application that accesses the Interactor.
    - **App Container for the Client Application** - This is the component that truly puts the system together. This class library sets up the Lamar IoC scaffolding so that the calls to the various interfaces in the system will resolve to the corresponding implementations without making direct calls (and requiring direct references). This is a class library separate from the application itself because it has references to each class that holds an interface or implements an interface, and therefore breaks the Clean Architecture rules. You should know that it's possible to reduce or eliminate this coupling by having Lamar scan the Physical DLLs at runtime and obtain Type information that way. This task is beyond the scope of this sample project, but you should know the possibility exists, though the issues around using these methods are entirely separate and non-trivial issues. For the purposes of this demo project, we make direct references and store that scaffolding code in its own project to avoid exposing data types to the clients that they do not need to have direct access to.
    - **Data Import Script** - This is a second sample client project to rove the concepts explained here.
    - **App Container for the Data Import Script** - This is essentially the same container as the one for the Client Application. You can optionally use the Client Application container. I include this project in the same to show that it's possible (and in a lot of cases cleaner) to have one app container in the same system to satisfy different usage scenarios.
    - **Client Shared objects** - For the sake of completeness, I add this class library that holds types shared by the different system clients.
  - Data Stores
    - **Data Store** - This class contains all of the code to store and retrieve system data. Since _all_ the types and code used to store and access data live in this class library, data storage is completely abstracted away from the rest of the system. This means that if you  would later like to change the structure or platform of the data storage subsystem, you can do all the changes you need in this component of the system without affecting any of the other system code.  I'm still amazed by how clean this design is for this reason alone.
# Next Steps
## Building on top of this scaffold
You should be able to take this code, make sure it compiles and runs as-is, and then implement your system on top of this by making incremental changes only.

You can add entire complex projects to this template solution and not have the essence of the system change. For example, you can add one or more web site user interfaces so this architecture, and the new sites will simply be new clients. The entire web site implementation will simply be one more client to this system.  You can add an API server as well, and it will also be one more client to the system you build on top of this infrastructure.
## Errors? Suggestions?
If you see anything missing from this example, or if you can think of a way to make it simpler, please drop me an email at gmagana@gmail.com.
