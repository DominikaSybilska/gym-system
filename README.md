# Fitnesso - gym-system
ASP.NET project that is not finished yet (part of University classes)

<h3>ASP.NET project which is ASP.NET project that was written as a website for a gym</h3>
This project is a simple website about fictional gym, built with ASP.NET, C# and database was created with MSSQL Serveer. 
It has a user version, admin version and guest vesrsion.

The main goal of the project was to work in <b>SCRUM team</b>, not exactly to build a great project.
We had have daily meetings, sprint planning and retrospective meeting. We had been obligated to create the user stories and epics for our project.
We have been devide to the main SCRUM roles as a:
<ul>
<li>Product Owner</li>
<li>Scrum Master</li>
<li>Database Specialist</li>
<li>Programmers</li>
<li>Analysts</li>
</ul>

We have used Azure DevOps to manage the whole project.


<h3>Table of Contents</h3>
<ul>
<li>Features</li>
<li>Documentation</li>
<li>Status of the project</li>
<li>Technologies</li>
</ul>

<h3>Features</h3>
We have 3 main roles in the system and functionalities are describe as per the list below:
<ul>
<li>As a guest you are only able to see the landing page and login.</li>
<li>As a user you can make a register, login to the website, make a reservation, cancel the reservation, see your past reservation and logout.</li>
<li>As admin you can add a new classes or a new employee.</li>
</ul>

<h3>Documentation - unfortunately, available only in polish language</h3>
Our user stories, epics and acceptance criteria are available here: shorturl.at/DGKRX
Our example sprint review is available here: shorturl.at/fLOST

<h3>Status of the project</h3>
Likely, the project will not be completed, due to the lack of time of those responsible for programming. We continue to be students and instead of this project, we have a dozen more to complete.
Nevertheless, I want to show that we worked in a SCRUM team trying to keep all the principles of agile methodologies.

<h3>How to run the project</h3>
<ul>
<li> Import the database (projekt-obiektDB.bak) file to Microsoft SQL Server at first.</li>
<li> In visual studio, add the solution or project </li>
<li> Modify the Connection String as you needed to connect to database. Go to (inside project) : PMApp/Web.config. At the last portion, you'll find the connection string like below: </li>

```
<connectionStrings>
		<add name="con" connectionString="Data Source=LAPTOP-NEUL726L;Initial Catalog=projekt-obiektDB;Integrated Security=True" />
		<add name="projekt-obiektDBConnectionString" connectionString="Data Source=LAPTOP-NEUL726L;Initial Catalog=projekt-obiektDB;Integrated Security=True"
			providerName="System.Data.SqlClient" />
 </connectionStrings>
```
 </ul>


<h3>Technologies</h3>
<p align="center">
  <a href="https://skillicons.dev">
    <img src="https://skillicons.dev/icons?i=cs,visualstudio," />
  </a>
</p>
