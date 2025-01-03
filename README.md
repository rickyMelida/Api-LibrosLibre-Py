# Api-LibrosLibre-Py

## Overview
Api-LibrosLibre-Py is a .NET project designed to provide an API for managing a library of books. This project allows users to perform CRUD (Create, Read, Update, Delete) operations on book records and offers additional features to enhance the user experience.

## Features
- Add new books to the library
- Retrieve details of existing books
- Update information of existing books
- Delete books from the library
- Get relevant books based on user preferences
- Retrieve the latest books uploaded to the library
- Search for books using various criteria
- Upload new books (authentication required)

## Requirements
- .NET 5.0 or later
- SQL Server or any compatible database

## Installation
1. Clone the repository:
  ```sh
  git clone https://github.com/yourusername/Api-LibrosLibre-Py.git
  ```
2. Navigate to the project directory:
  ```sh
  cd Api-LibrosLibre-Py
  ```
3. Restore the dependencies:
  ```sh
  dotnet restore
  ```
4. Update the database connection string in `appsettings.json`.

## Usage
1. Run the application:
  ```sh
  dotnet run
  ```
2. The API will be available at `https://localhost:5001`.

## Endpoints
- `GET /api/books` - Retrieve all books
- `GET /api/books/{id}` - Retrieve a book by ID
- `POST /api/books` - Add a new book
- `PUT /api/books/{id}` - Update a book by ID
- `DELETE /api/books/{id}` - Delete a book by ID
- `GET /api/books/relevant` - Get relevant books based on user preferences
- `GET /api/books/latest` - Retrieve the latest books uploaded
- `GET /api/books/search` - Search for books using various criteria
- `POST /api/books/upload` - Upload a new book (authentication required)

## Contributing
Contributions are welcome! Please fork the repository and create a pull request with your changes.

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contact
For any questions or feedback, please contact [yourname@example.com](mailto:yourname@example.com).

## Purpose
This project was created to provide the "Libros Libres App" with data and its main functionalities, such as getting relevant books, retrieving the latest books uploaded, finding specific books, uploading books (if the user is authenticated), and other features.