# Equipment Inventory Management System

## Project Overview

This is an **ASP.NET MVC** web application designed for managing equipment inventory, customer assignments, and online ordering. The system incorporates essential features such as authentication, authorization, and a shopping cart, providing a foundation for efficient inventory and customer management.

---

## Key Features

### 1. Authentication System
- **Login/Logout:** Secure session-based authentication to control user access.
- **Password Reset:** Allows users to reset forgotten passwords safely.
- **User Registration:** New users can register with their personal details.

### 2. Equipment Management
- **CRUD Operations:** Create, Read, Update, and Delete equipment records.
- **Inventory Tracking:** Monitor stock levels and detailed equipment information.
- **Assignment System:** Assign equipment to customers seamlessly.

### 3. Shopping Cart Functionality
- **Local Storage Cart:** Persistent shopping cart stored in the browser’s local storage.
- **Checkout Process:** Convert cart items into customer assignments.
- **Stock Validation:** Prevent orders exceeding available inventory stock.

### 4. User Roles & Access Control
- **Session-based Authorization:** Control access based on logged-in status.
- **Automatic Redirects:** Unauthorized users are redirected to the login page.
- **Personalized UI:** Dynamic interface elements based on user login status.

---

## Technical Architecture

### Frontend
- **Bootstrap:** Responsive UI framework ensuring compatibility across devices.
- **jQuery / jQuery UI:** Used for DOM manipulation and datepicker controls.
- **Razor Views:** For dynamic HTML generation.
- **Partial Views:** Modular, reusable UI components for consistency.

### Backend
- **ASP.NET MVC:** Implements Model-View-Controller architectural pattern.
- **SQL Server:** Relational database for persistent data storage.
- **Stored Procedures:** Business logic executed via `spOST_*` procedures.
- **Session State:** Manages user authentication and temporary data storage.

---

## Data Model

- **OSTMember:** Stores user account information.
- **Equipment:** Represents inventory items.
- **Customer:** Represents customers receiving equipment.
- **CustomerEquipmentAssignment:** Manages relationships between customers and assigned equipment.

---

## Security Implementation

- Session-based authentication for secure login sessions.
- Password verification (with implied hashing).
- Parameterized SQL queries to minimize SQL injection risk.
- Server-side form validation on critical operations.

---

## Areas for Improvement

### Security Enhancements
- Implement strong password hashing algorithms.
- Add CSRF (Cross-Site Request Forgery) protection.
- Strengthen SQL injection defenses across all queries.

### Code Organization
- Separate business logic from controller actions.
- Implement the repository pattern for data access.
- Introduce dependency injection for better testability and modularity.

### User Experience
- Add comprehensive client-side validation.
- Enhance error handling and user messaging.
- Improve responsive design and UI polish.

### Additional Features
- Add granular user roles and permission management.
- Implement order history and tracking.
- Add reporting and analytics capabilities.

---

## Conclusion

This system provides a robust foundation for equipment inventory management, with scalable potential to evolve into a comprehensive e-commerce or enterprise resource planning platform.

---



## Contact

Created by [Your Name](https://github.com/yourusername).  
For issues or contributions, please open an issue or submit a pull request.
