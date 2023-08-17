# MemberEnrollment
## Project Overview

This API allows creating member enrollment records in a database via a RESTful endpoint. It uses a simple in-memory database for demo purposes. In a real production app, this would be replaced with a persistent database like SQL Server.

The main technologies used include:

- ASP.NET Core for building the web API
- Entity Framework Core for data access using the repository pattern
- xUnit, Moq and in-memory database for testing

## API Reference

The API has a single endpoint:

**POST /api/members**

Request body should contain a JSON object representing the member details to enroll:

```json
{
  "firstName": "Tiara",
  "lastName": "Ken",
  "email": "tiara@ken.com",
  "birthDate": "1993-01-01"
}
```

The response will return a 201 Created status on success, along with the created member object:

```json
{
  "id": 1,
  "firstName": "Tiara",
  "lastName": "Ken",
  "email": "Tiara@ken.com",
  "birthDate": "1993-01-01"
}
```

## Testing

Tests cases are written using xUnit to validate the API endpoint. Some examples:

- POST request with valid member object returns 201
- POST with invalid object returns 400
- POST adds member to database correctly 

Mocking is done with Moq to simulate repository layer and in-memory database for testing.

## Next Steps

Some possible enhancements for the future:

- Add PUT endpoint to update member details
- Add DELETE endpoint to cancel membership
- Use a persistent database like SQL Server
- Add authentication and authorization
- Containerize application with Docker
