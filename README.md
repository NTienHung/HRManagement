# HR Manager App (WPF)

A simple desktop application for managing employees using **WPF (MVVM)** and **Entity Framework Core**.

---

## 🚀 Features

* Load employee list from database
* Add new employee
* Delete employee
* Filter employees by department

---

## 🧱 Technologies

* C#
* WPF (.NET)
* MVVM Pattern
* Entity Framework Core
* SQL Server

---

## 📂 Structure

```
/Models
/Repositories
/ViewModels
/Views
/Commands
```

---

## ⚙️ Setup

1. Update connection string in `appsettings.json`

```
"ConnectionStrings": {
  "DefaultConnectionString": "Server=YOUR_SERVER;Database=HRPrinterDB;Trusted_Connection=True;TrustServerCertificate=True"
}
```

2. Create database (using DB.sql)

3. Run project in Visual Studio

---

* This project is built for demo purposes
