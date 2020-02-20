Feature: Retrieve Users
	In order to list the system registered users
	the system must provide an 'Users' list endpoint

Scenario Outline: Retrieve list of registered users
	Given that I'm logged in the system, with following user:
		| UserName | Password |
		| Admin	   | Wrong    |
		| Admin	   | Admin    |
	When I request users from the users endpoint
	Then the result should be success
	And I receive an user list

Scenario: Retrieve list of registered users not being logged on the system
	Given that I'm not logged in the system
	When I request users from the users endpoint
	Then the result should be unauthorized