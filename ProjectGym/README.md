# 🏋️ Gym Management System (Power Fitness)

A comprehensive Web-based Gym Management System built with **ASP.NET Core MVC** and **Entity Framework Core**. 
This platform enables gym administrators to efficiently manage memberships, trainer schedules, class capacity, 
and member subscriptions while applying strict business logic constraints.

---

## 🛠️ Tech Stack & Architecture

* **Framework:** ASP.NET Core 10.0 MVC
* **Database & ORM:** SQL Server & Entity Framework Core
* **Architecture:** Clean / Layered Architecture
* **Frontend:** Razor Views, Bootstrap 5, HTML5/CSS3
* **Validation:** Data Annotations & FluentValidation

---

## ✨ Key Features & Business Logic

### 👥 Member Management
* Full CRUD for members including personal info and profile photo upload.
* **1-to-1 Health Record:** Automatically paired with health metrics (height, weight, blood type).
* **Validation Rules:** Enforces unique emails and Egyptian phone format (`010|011|012|015`).
* **Data Integrity:** Prevents deleting members with active bookings.

### 🏋️ Trainer Management
* Assigns trainers to dedicated specialties (`GeneralFitness`, `Yoga`, `Boxing`, `CrossFit`).
* Enforces single-specialty binding to restrict session assignment scope.

### 📅 Session & Booking Scheduling
* Dynamic session status tracking (`Upcoming`, `Ongoing`, `Completed`) calculated in real-time.
* Class capacity enforcement (1 to 25 attendees max).
* Restricts session assignment strictly to qualified trainers matching the category.

### 💳 Plans & Active Subscriptions
* **Soft Delete Strategy:** Deactivates plans without losing historical member records (`IsActive = false`).
* Auto-computes membership expiration dates based on plan duration.
* Booking restrictions linked strictly to valid, non-expired memberships.

---

## 🚀 Getting Started

### Prerequisites
* Visual Studio 2026 / VS Code
* .NET SDK 10.0+
* SQL Server Express / LocalDB

### Installation & Setup

1. **Clone the repository:**
   ```bash
   git clone [https://github.com/YOUR_USERNAME/GymManagementSystem.git](https://github.com/YOUR_USERNAME/GymManagementSystem.git)
   cd GymManagementSystem