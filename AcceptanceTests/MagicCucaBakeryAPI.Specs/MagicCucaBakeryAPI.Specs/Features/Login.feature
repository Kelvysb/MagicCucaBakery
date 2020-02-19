Feature: Login
	In order to allow the users to login into the system
	the system provides an login interface that receives an 
	user name and a password.

Background: 
	Given that I'm not logged in the system

Scenario Outline: Login into the system
	When I Request the login with the following user name: <UserName> and the following password: <Password>
	Then the result should be success

Examples: 
| UserName | Password |
| Admin	   | Admin    |

Scenario Outline: Login into the system with wrong password
	When I Request the login with the following user name: <UserName> and the following password: <Password>
	Then the result should be unauthorized

Examples: 
| UserName | Password |
| Admin	   | Wrong    |
