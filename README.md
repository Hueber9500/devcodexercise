 # .Net Developer Coding Exercise
-----------

As a team we are in charge of a new development for the company:

Create a reporting tool that will provide information on a table with data about the time employees arrive to the building.

This Web Application MUST subscribe to a WebService (provided in the solution already) to do the following:
- Receive and store information about a bus stop located in front of the company's office.
- Allow a user to see a report with the received information

In order to subscribe to the service, compile the solution, and run the project WebService in the background

Send a request to the endpoint

`http://localhost:51396/api/clients/subscribe?date=2016-03-10&callback={URI}`

with the (*MANDATORY*) header:

`Accept-Client: "Alaric-Monitor"`

with the (*MANDATORY*) parameters:

`date`: date of the required simulated data in the format yyyy-MM-dd

`callback`: url where the webservice will submit the data

Possible responses:

`401 unauthorized`

`200 Ok` // with a body

`{
	"Token":"XXX",
	"expires":"DATE" //ISO 8601 format
}`

If the response status is 200:

The service will start sending requests to provided callback in the url, until it fails after 10 retries or the simulation is finished for the provided date (all the information for that date has been submited)
Every request will contain a header X-Alaric-Token with the provided token, and this has to be validated in order to receive valid submissions of data, header must exist and be the same as the one in the response to the subscription.

The callback has to accept POST messages receiving the following json list

`{
	[  { "EmployeeId" : X , "When" : "2016-04-01T14:35:20Z" }	]
}`

- *EmployeeId*: int
- *When*: DateTime valid ISO 8601 format

*It is required to pass the test that you*

- Download the project.
- Introduce changes implementing the following
    - A database to store the information (Employees and Arrival information)
    - The Web Application to connect to the webservice, and accept information about the employees arriving to the bus stop.
     - Every time the WebService makes a request to your application save the information in the database
     - Create a web page where the information is presented in a table to the user (allow filtering/sorting)
- If required add any comments in a file in the Comments folder.

*BONUS, NOT MANDATORY*

- In the folder Comments create 1 file with

	A review of the code of the JsonEmployeeGenerator, proposing changes inline the code to improve the code quality and performance
		


Finally

- Send us back a zip file of your completed coding exercise. One option could be over email or just upload it to your own cloud space like Google Drive and send us back a link to download it.

Notes:
- A comprehensive list of employees can be found in the Data folder of the solution to populate the database.
- There are sample files of valid request and responses located in the Examples folder


