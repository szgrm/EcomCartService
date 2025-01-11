# E-Commerce Cart Service

This application hosted on Azure App Service. Check it out [here](https://ecomcartservice-gqhxgngjdkedghd3.germanywestcentral-01.azurewebsites.net/swagger/index.html).

This is a simple shopping cart microservice built with .NET 8, Entity Framework Core, and PostgreSQL.

## Features

- 🛒 Cart Management
  - Add/Update items in cart
  - Remove items from cart
  - Empty entire cart
  - Get cart summary with total amount
- 🏷️ Product Management
  - List all products
  - Get product details by ID
- 🔐 User-specific carts
- 🎯 RESTful API design
- 📚 Swagger/OpenAPI documentation

## Tech Stack

- .NET 8
- Entity Framework Core 9.0
- PostgreSQL
- Docker
- Swagger/OpenAPI

## Prerequisites

- .NET 8 SDK
- Docker (optional)
- PostgreSQL instance or Docker container

## Getting Started

### Local Development

1. Clone the repository:

```
git clone https://github.com/szgrm/EcomCartService.git
```

2. Update the connection string in appsettings.json:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=ecomcartdb;Username=postgres;Password=postgres"
  }
}
```
3. Run the migrations:
```
dotnet ef database update
```
4. Start the application:
```
dotnet run
```
### Docker Deployment

1. Build and run using Docker Compose:
```
docker-compose up --build
```
This will start both the application and PostgreSQL database in containers.

## API Endpoints

### Cart Operations

- POST /api/cart/update - Update cart item quantity
- GET /api/cart/summary/{username} - Get cart summary
- DELETE /api/cart/{username}/{productId} - Remove specific item from cart
- DELETE /api/cart/{username} - Empty cart

### Product Operations

- GET /api/product - Get all products
- GET /api/product/{id} - Get product by ID

## Database Schema

### Products Table
```
Id (int, primary key)
Title (string, max 100)
Description (string, max 500)
Category (string, max 100)
Brand (string, max 100)
SKU (string, max 100)
Price (double)
DiscountPercentage (double)
Rating (double)
Stock (int)
Weight (int)
MinimumOrderQuantity (int)
Images (string[])
Thumbnail (string, max 200)
```

### CartItems Table
```
Id (int, primary key)
ProductId (int, foreign key)
Quantity (int)
Username (string)
```

## Development

The project uses Entity Framework Core for database operations. To create new migrations:

```
dotnet ef migrations add MigrationName
dotnet ef database update
```

## Contributing

1. Fork the repository
2. Create your feature branch:
    
    git checkout -b feature/AmazingFeature

3. Commit your changes:
    
    git commit -m 'Add some AmazingFeature'

4. Push to the branch:
    
    git push origin feature/AmazingFeature

5. Open a Pull Request
