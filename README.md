# E-Commerce Cart Service

This application hosted on Azure App Service. Check it out [here](https://ecomcartservice-gqhxgngjdkedghd3.germanywestcentral-01.azurewebsites.net/swagger/index.html).

You can visit the frontend [here](https://ecom-4ds1y9zgg-szgrms-projects.vercel.app/).

This is a simple shopping cart microservice built with .NET 8, Entity Framework Core, and PostgreSQL, with a Next.js frontend.

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
- 🌐 Next.js Frontend
  - Modern, responsive UI
  - Server-side rendering
  - Interactive shopping experience

## Tech Stack

### Backend
- .NET 8
- Entity Framework Core 9.0
- PostgreSQL
- Docker
- Swagger/OpenAPI

### Frontend
- Next.js
- React
- TypeScript

## Prerequisites

- .NET 8 SDK
- Node.js (version 18 or higher)
- npm or yarn
- Docker (optional)
- PostgreSQL instance or Docker container

## Getting Started

### Clone the Repository

1. Clone the repository with submodules:
```bash
git clone --recursive https://github.com/szgrm/EcomCartService.git
```

If you've already cloned the repository without submodules:
```bash
git submodule init
git submodule update
```

### How to run backend locally

1. Change directory to the backend:
```bash
cd backend/
```

2. Start the backend application:
```bash
dotnet run
```

### How to run frontend locally

1. Navigate to the frontend directory:
```bash
cd frontend
```

2. Install dependencies:
```bash
npm install
```

3. Start the development server:
```bash
npm run build && npm start
```

The frontend will be available at `http://localhost:3000`

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

### Backend
The project uses Entity Framework Core for database operations. To create new migrations:

```bash
dotnet ef migrations add MigrationName
dotnet ef database update
```

### Frontend
To build the frontend for production:
```bash
cd frontend
npm run build
npm start
```

## Contributing

1. Fork the repository
2. Create your feature branch:
    ```bash
    git checkout -b feature/AmazingFeature
    ```

3. Commit your changes:
    ```bash
    git commit -m 'Add some AmazingFeature'
    ```

4. Push to the branch:
    ```bash
    git push origin feature/AmazingFeature
    ```

5. Open a Pull Request

### Updating the Frontend Submodule

To update the frontend to the latest version:
```bash
cd frontend
git pull origin main
cd ..
git add frontend
git commit -m "Update frontend submodule"
git push
```
