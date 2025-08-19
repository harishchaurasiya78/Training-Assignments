# 📖 Book Management REST API

This project is a simple Node.js REST API to manage a list of books stored in a JSON file.  
It supports CRUD operations with proper asynchronous handling and event logging.

---

## 🚀 Setup Instructions

1. Install dependencies:
   ```bash
   npm install
   ```

2. Start the server:
   ```bash
   npm start
   ```

3. The server will run at:  
   **http://localhost:3000**

---

## 📚 API Endpoints

### Root
- **GET /** → Returns a welcome message  
  ```json
  { "message": "Welcome to Book Management API" }
  ```

### Books CRUD
- **GET /books** → Get all books  
- **GET /books/:id** → Get a book by ID  
- **POST /books** → Add a new book (requires `title`, `author` in body)  
- **PUT /books/:id** → Update a book by ID  
- **DELETE /books/:id** → Delete a book by ID  

---

## 🛠 Tech Stack
- Node.js  
- Express.js  
- fs module (for file handling)  
- EventEmitter (for logging book actions)  

---

## ✨ Events Logged
- Book Added  
- Book Updated  
- Book Deleted 