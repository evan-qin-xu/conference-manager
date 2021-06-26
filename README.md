
This web application is developed for my school project. (Unit: Advanced object oriented programming.)

Background

User Modeling Inc. is an US based organisation that regularly hosts conferences for researchers in the area of user adaptive systems and personalisation. This conference management system is developed based on their requirements for having a web application to manage relevant information and organise conferences.

Target User Analysis

The main users of this web application will be the administrative team of User Modeling Inc. The conference managers can use this application to easily manage various related records such as conference, participants, and registrations.

Functional Requirements

According to the business background, this application needs to be developed with the following functionalities to meet the requirements:

●	Nicely designed frontend user interfaces that allows users to easily navigate, interact and view the information.

●	Backend database to store tables which are appropriately mapped to the domain classes.

●	Various web pages and forms for users to create, update, view, and delete the records stored in the database.

●	Sorting and searching functionalities that help users to find records easily.

User Cases

Based on the requirements, the system should provide the following use cases:

●	Create, update, view, delete, sort, and search conference records

●	Create, update, view, delete, sort, and search participant records

●	Create, update, view, delete, sort, and search registration records

System Benefits

This conference management system will allow the administrative team of User Modeling Inc. to easily manage the key information of various conference related records. It is also extensible and maintainable, which means further improvements and new features can be developed to satisfy the future business requirements.

Architecture Design of the System

The conference class represents the conference entity, each conference object should have properties that include title, time, location, and Registration. The registration property is referencing the registration class.


Participant contains full name, email, and phone property. It has two sub-classes. The organizer class represents the host from User Modeling Inc. while the attendee class represents guests who attend the conference.

According to the business case study, the relationship between conference class and participant class is many to many. It means that one conference can have many different participants while one participant can also attend many conferences.

Thus, the registration class is introduced to serve as a middle class that will be mapped as a join table in the database. Each registration object contains a conference id, which is referencing the conference class as well as the participant id, which is referencing the participant class.

The system uses the default TPH (Table per Hierarchy) offered by Entity Framework 6 to manage inheritance hierarchy.

System Advantages

This inheritance relationship means the role of the participant can be extended to meet the future business needs. For example, there might be a need to have a class representing the special guest in the future, it can be easily added to extend the participant class without resulting in lots of breaking changes in the system.

The registration class allows admins to easily update the registration record, it makes the database table normalised and easy to maintain. Take cancelling a registration for an example, admin users can easily delete a registration record without affecting both the conferences and participants table.


User Manual

How to run the program on the local server

Step 1: Download the project file which is named “ConferenceManager.zip”.

Step 2: Extract the zip file and navigate to the project folder.

Step 3: Double click “ConferenceManager.sln”, choose Visual Studio 2019 to open the project.

Step 4: Inside the Visual Studio, press Ctrl+F5 to launch the application, then your default browser will be launched to run the application as shown in Fig.7.


Application features:

Managing Conferences Record

1. `	`Create a new conference record.
1. `	`Search conference record by title.
1. `	`Edit, view, and delete a specific conference record.
1. `	`Click to sort conference records by title.
1. `	`Click to sort conference records by time.


Managing Participants Record

1. `	`Create a new participant record.
1. `	`Search participant records by their names.
1. `	`Click to sort participant records by name.
1. `	`Edit, view, and delete a specific participant record.


Managing Registrations Record

1. `	`Create a new registration record.
1. `	`Click to sort registration records by conference title.
1. `	`Click to sort registration records by participant name
1. `	`Edit, view, and delete a specific registration record.
1. `	`Search registration records by conference titles or participant names.


Troubleshooting input error messages


If you cannot submit the record, please check the requirement, and enter the necessary information in the correct format.


Trouble shoot server error messages

If a 404-error page is displayed, please close your browser and navigate back to Visual Studio, then press Ctrl + F5 to restart the application.
