
# 📦 Product Inventory Management Application  
### Built using **.NET Core | C# | MVC | Collections | OOP**

---

## 📘 Overview  
The **Product Inventory Management Application** is designed for small-scale businesses to manage their products and categories efficiently.  
It supports complete **CRUD operations**, validation, discount handling, searching, sorting, and file-based exception logging.  

The system follows **clean OOP principles**, uses **Generic Collections**, and is built in **.NET Core (MVC or Console)**.

---

## 🚀 Technology Stack  
| Component | Technology |
|----------|------------|
| Framework | .NET Core 7 (or higher) |
| Language | C# 10 (or higher) |
| Architecture | MVC (or Console-based) |
| IDE | Visual Studio |
| Data Storage | In-Memory Collections |
| Logging | File I/O (.txt) |

---

## 🎯 Problem Statement  
Build a product inventory application that helps track products, categories, and discount-based products with full CRUD operations and proper validations.

---

## 🧩 Functional Requirements  

### ✔ Admin Features  
#### **1. Add Product**
- Auto-generate product code (Ex: `P001`, `P002`)
- Accept product name, category code, quantity, price  
- **Validations**:
  - Product name ≥ 6 characters  
  - Category exists  
  - Quantity > 0  
  - Price > 0  

#### **2. Add Product on Discount**
- All validations of Add Product  
- Additional:
  - DiscountPercent > 0  
  - MinimumPickQuantity > 0  

#### **3. Modify Product**
- Search by product code  
- Update product details  

#### **4. Delete Product**
- Search and confirm before deleting  
- Show message if product does not exist  

#### **5. Search Product**
- Get product by product code  

#### **6. Get All Products**
- Show all products (including discounted)  
- Sort products based on **price** using `IComparable<T>`  

#### **7. Get Products by Name**
- Search products using partial name (min 3 characters)

#### **8. Get Products by Category Code**

---

## 🏗 Class & Interface Design  

### **Category**
```
CategoryCode : string  
CategoryName : string
```

### **Product**
```
ProductCode : string  
ProductName : string  
CategoryCode : int  
AvailableQuantity : int  
ProductPrice : double
```

### **ProductOnDiscount : Product**
```
DiscountPercent : double  
MinimumPickQuantity : int
```

### **IProduct Interface**
Defines CRUD operations:
```
AddProduct(Product p)
DeleteProduct(string productCode)
ModifyProduct(string productCode)
GetProductByCode(string productCode)
GetAllProducts()
GetProductsByName(string productName)
GetProductsByCategoryCode(int categoryCode)
```

---

## 🔧 Application Behavior & Design  
- Implements **HAS-A** relationship: `Product` HAS-A `ProductOnDiscount`
- Uses **Generics**, **Collections**, **LINQ**  
- Validations through **properties and setters**  
- Uses **StringBuilder** for string formatting  
- Overrides **ToString()** in Product  
- Implements **IComparable<Product>** to sort by price  
- Custom Exception class (inherits `ApplicationException`)  
- All exceptions logged into a **single file** with:  
  - Date & Time  
  - Error Message  
  - Stack Trace  

---

## ⚠ Exception Handling & Logging  
- Custom exception: `InventoryException`  
- All exceptions are logged via File I/O in a `.txt` log file:
```
[DateTime]  
ErrorMessage  
StackTrace  
```

---

## 🧪 Unit Testing  
- Unit tests included for Product class  
- At least 2 methods tested (e.g., validations, price sorting)

---

## 📈 Non-Functional Requirements  
- Low Latency  
- Scalable & Maintainable  
- Secure (Basic Authentication for Admin)  
- Modular for future expansion (Customers, Orders, Billing, etc.)

---

## 🏁 Milestones  

| Milestone | Description |
|----------|-------------|
| **1** | Class, Interface, Method Design |
| **2** | CRUD Implementation using Generic Collections + Validations |
| **3** | Custom Exception + Logging |
| **4** | LINQ usage |
| **5** | Unit Testing for 1 class (Product) |
| **6** | Push source code to GitHub |
| **7** | Technical Evaluation |

---

## 📂 How to Run (MVC Version)
```
1. Open solution in Visual Studio  
2. Restore NuGet packages  
3. Build the project  
4. Run using IIS Express or `dotnet run`
```

---

## 📂 How to Run (Console Version)
```
1. Open solution in Visual Studio  
2. Set Console project as startup  
3. Press F5 to run  
```

---

## ✨ Future Enhancements  
- Order Management  
- Customer Management  
- Database Integration (SQL Server)  
- REST API version  
- JWT Authentication  

---

## 📜 License  
This project is for learning and academic use.

