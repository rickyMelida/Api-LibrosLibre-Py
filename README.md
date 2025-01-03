# Api-LibrosLibre-Py

## Descripción General
Api-LibrosLibre-Py es un proyecto .NET diseñado para proporcionar una API para gestionar una biblioteca de libros. Este proyecto permite a los usuarios realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) en los registros de libros y ofrece características adicionales para mejorar la experiencia del usuario.

## Características
- Añadir nuevos libros a la biblioteca
- Obtener detalles de libros existentes
- Actualizar información de libros existentes
- Eliminar libros de la biblioteca
- Obtener libros relevantes basados en las preferencias del usuario
- Recuperar los últimos libros subidos a la biblioteca
- Buscar libros usando varios criterios
- Subir nuevos libros (se requiere autenticación)

## Requisitos
- .NET 8.0 o posterior
- Postgres SQL o cualquier base de datos compatible

## Instalación
1. Clona el repositorio:
  ```sh
  git clone https://github.com/rickyMelida/Api-LibrosLibre-Py.git
  ```
2. Navega al directorio del proyecto:
  ```sh
  cd Api-LibrosLibre-Py
  ```
3. Restaura las dependencias:
  ```sh
  dotnet restore
  ```
4. Actualiza la cadena de conexión de la base de datos en `appsettings.json`.

## Uso
1. Ejecuta la aplicación:
  ```sh
  dotnet run
  ```
2. La API estará disponible en `https://localhost:5001`.

## Endpoints
- `GET /api/books` - Recuperar todos los libros
- `GET /api/books/{id}` - Recuperar un libro por ID
- `POST /api/books` - Añadir un nuevo libro
- `PUT /api/books/{id}` - Actualizar un libro por ID
- `DELETE /api/books/{id}` - Eliminar un libro por ID
- `GET /api/books/relevant` - Obtener libros relevantes basados en las preferencias del usuario
- `GET /api/books/latest` - Recuperar los últimos libros subidos
- `GET /api/books/search` - Buscar libros usando varios criterios
- `POST /api/books/upload` - Subir un nuevo libro (se requiere autenticación)

## Contribuciones
¡Las contribuciones son bienvenidas! Por favor, haz un fork del repositorio y crea un pull request con tus cambios.

## Licencia
Este proyecto está licenciado bajo la Licencia MIT. Consulta el archivo [LICENSE](LICENSE) para más detalles.

## Contacto
Para cualquier pregunta o comentario, por favor contacta a [ricardomelida92@gmail.com](mailto:ricardomelida92@gmail.com).

## Propósito
Este proyecto fue creado para proporcionar a la "Libros Libres App" datos y sus principales funcionalidades, como obtener libros relevantes, recuperar los últimos libros subidos, encontrar libros específicos, subir libros (si el usuario está autenticado) y otras características.