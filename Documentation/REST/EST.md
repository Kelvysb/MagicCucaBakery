# REST API

## Terminologies

* **Resource** - Object or representations of something, which has some associated data with it and there can be set of methods to operate on it. E.g. Animals, schools and employees are resources and delete, add, update are the operations to be performed on these resources.
* **Collections** are set of resources, e.g Companies is the collection of Company resource.
* **URL** (Uniform Resource Locator) is a path through which a resource can be located and some actions can be performed on it.

## API endpoints

The URL should only contain resources(nouns) not actions or verbs. The API path/addNewEmployee contains the action addNew along with the resource name Employee.

### HTTP methods: 
* GET
    - Requests data from the resource and should not produce any side effect.
* POST
    - Requests the server to create a resource in the database, mostly when a web form is submitted.
* PUT
    - Requests the server to update resource or create the resource, if it doesn’t exist.
* DELETE
    - Requests that the resources, or its instance, should be removed from the database.

## HTTP response status codes

When the client raises a request to the server through an API, the client should know the feedback, whether it failed, passed or the request was wrong. HTTP status codes are bunch of standardized codes which has various explanations in various scenarios. The server should always return the right status code.

* **Succsess category (2xx)**
    - **200** - The standard HTTP response representing success for GET, PUT or POST.
    - **201** - Created This status code should be returned whenever the new instance is created.
    - **204** - No Content represents the request is successfully processed, but has not returned any content.
* **Redirection Category (3xx)**
    - **304** - Not Modified indicates that the client has the response already in its cache. And hence there is no need to transfer the same data again.
* **Client Error Category (4xx)**
    - **400** - Bad Request indicates that the request by the client was not processed, as the server could not understand what the client is asking for.
    - **401** - Unauthorized indicates that the client is not allowed to access resources, and should re-request with the required credentials.
    - **403** - Forbidden indicates that the request is valid and the client is authenticated, but the client is not allowed access the page or resource for any reason. E.g sometimes the authorized client is not allowed to access the directory on the server.
    - **404** -  Not Found indicates that the requested resource is not available now.
    - **410** - Gone indicates that the requested resource is no longer available which has been intentionally moved.
* **Server Error Category (5xx)**
    - **500** - Internal Server Error indicates that the request is valid, but the server is totally confused and the server is asked to serve some unexpected condition.
    - **503** - Service Unavailable indicates that the server is down or unavailable to receive and process the request. Mostly if the server is undergoing maintenance.



