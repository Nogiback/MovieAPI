# MovieAPI
## Assignment 4 - RESTful Web API with Pagination

### Student Information
- **Name:** Peter Do
- **Student ID:** 9086580
- **Course:** PROG8555 - Microsoft Web Technologies
- **Assignment:** Assignment 4 - Convert Movie System to Web API

---

## Project Description

A RESTful Web API for managing a movie database, built with ASP.NET Core. This project demonstrates:
- Full CRUD operations (Create, Read, Update, Delete)
- Repository Pattern for data access
- DTOs (Data Transfer Objects) for request/response handling
- Model validation with Data Annotations
- Pagination support (5 items per page)
- Proper HTTP status codes
- Swagger/OpenAPI documentation

---

## Technologies Used

- **ASP.NET Core Web API** (.NET 8.0)
- **Entity Framework Core** 8.0.11
- **SQLite Database**
- **Swagger/OpenAPI** for API documentation
- **Repository Pattern** for separation of concerns
- **DTOs** for clean API contracts

---

## Project Structure
```
MovieAPI/
├── Controllers/
│   └── MoviesController.cs       # API endpoints
├── Data/
│   └── MovieDbContext.cs         # EF Core DbContext
├── DTOs/
│   ├── MovieReadDto.cs           # Response DTO
│   ├── MovieCreateDto.cs         # POST request DTO
│   ├── MovieUpdateDto.cs         # PUT request DTO
│   └── PaginatedResponse.cs      # Pagination wrapper
├── Models/
│   └── Movie.cs                  # Database entity
├── Repository/
│   ├── IMovieRepository.cs       # Repository interface
│   └── MovieRepository.cs        # Repository implementation
├── Migrations/                   # EF Core migrations
└── MoviesApp.db                  # SQLite database
```

---

## API Endpoints

### Base URL: `/api/movies`

| Method | Endpoint | Description | Status Codes |
|--------|----------|-------------|--------------|
| GET | `/api/movies?pageNumber=1&pageSize=5` | Get paginated list of movies | 200 OK |
| GET | `/api/movies/{id}` | Get movie by ID | 200 OK, 404 Not Found |
| POST | `/api/movies` | Create new movie | 201 Created, 400 Bad Request |
| PUT | `/api/movies/{id}` | Update existing movie | 204 No Content, 400 Bad Request, 404 Not Found |
| DELETE | `/api/movies/{id}` | Delete movie | 204 No Content, 404 Not Found |

---

## Request/Response Examples

### GET /api/movies?pageNumber=1&pageSize=5
**Response (200 OK):**
```json
{
  "pageNumber": 1,
  "pageSize": 5,
  "totalRecords": 23,
  "totalPages": 5,
  "data": [
    {
      "id": 1,
      "title": "Inception",
      "releaseYear": 2010,
      "genre": "SciFi",
      "imgUrl": "https://example.com/inception.jpg"
    }
  ]
}
```

### POST /api/movies
**Request Body:**
```json
{
  "title": "Inception",
  "releaseYear": 2010,
  "genre": "SciFi",
  "imgUrl": "https://example.com/inception.jpg"
}
```

**Response (201 Created):**
```json
{
  "id": 1,
  "title": "Inception",
  "releaseYear": 2010,
  "genre": "SciFi",
  "imgUrl": "https://example.com/inception.jpg"
}
```

---

## Validation Rules

### Title
- ✅ Required
- ✅ Must start with a capital letter

### Release Year
- ✅ Required
- ✅ Must be between 1900 and 2025

### Genre
- ✅ Required
- ✅ Must be one of: `Action`, `Comedy`, `Drama`, `Horror`, `SciFi`

### Image URL
- ✅ Must be a valid URL format

**Invalid requests return `400 Bad Request` with validation error messages.**

---

## How to Run

### Prerequisites
- Visual Studio 2022
- .NET 8.0 SDK

### Steps

1. **Clone the repository**
```bash
   git clone https://github.com/yourusername/movie-api.git
   cd movie-api
```

2. **Restore packages**
```bash
   dotnet restore
```

3. **Apply migrations (if needed)**
```bash
   dotnet ef database update
```

4. **Run the application**
```bash
   dotnet run
```

5. **Open Swagger UI**
   - Navigate to: `https://localhost:5xxx/swagger`
   - Or check the console output for the exact URL

---

## Testing with Swagger

The API includes Swagger UI for easy testing and documentation.

1. Run the application
2. Open browser to `https://localhost:xxxx/swagger`
3. Click on any endpoint to expand it
4. Click **"Try it out"**
5. Enter parameters/request body
6. Click **"Execute"**
7. View the response

### Example Test Scenarios

**✅ Valid Movie Creation:**
```json
{
  "title": "The Matrix",
  "releaseYear": 1999,
  "genre": "SciFi",
  "imgUrl": "https://example.com/matrix.jpg"
}
```

**❌ Invalid Movie (lowercase title):**
```json
{
  "title": "the matrix",
  "releaseYear": 1999,
  "genre": "SciFi",
  "imgUrl": "https://example.com/matrix.jpg"
}
```
Returns: `400 Bad Request` with error: "Title must start with a capital letter"

---

## HTTP Status Codes

| Code | Description | When Used |
|------|-------------|-----------|
| 200 OK | Success | GET requests |
| 201 Created | Resource created | POST requests |
| 204 No Content | Success with no body | PUT, DELETE requests |
| 400 Bad Request | Validation failed | Invalid POST/PUT data |
| 404 Not Found | Resource not found | GET/PUT/DELETE non-existent ID |

---

## License

This project is for educational purposes as part of PROG8555 coursework.

---
