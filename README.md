# 🎓 SchoolERP V2 | Enterprise Academic Intelligence

[![.NET 10](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![PostgreSQL](https://img.shields.io/badge/PostgreSQL-4169E1?logo=postgresql&logoColor=white)](https://www.postgresql.org/)
[![AI-Powered](https://img.shields.io/badge/AI-Google%20Gemini-orange?logo=googlegemini&logoColor=white)](https://ai.google.dev/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

**SchoolERP V2** is a high-performance, enterprise-grade management system designed to streamline institutional workflows. Engineered with a focus on **Data Integrity** and **Artificial Intelligence**, this platform transforms traditional administrative tasks into data-driven insights using the **Anuj Dhiman V2 UI Framework**.

---

## 🚀 Key Modules

| Feature | Description |
| :--- | :--- |
| **🤖 AI Smart Assistant** | Context-aware academic insights powered by **Semantic Kernel** & **Google Gemini**. |
| **📊 Executive Dashboard** | Real-time analytics for Student/Teacher ratios and financial health KPIs. |
| **💰 Financial Engine** | Automated Payroll management with dynamic tax/allowance calculations. |
| **📅 Attendance 360** | Deep-linked attendance tracking with automated reporting for LKG to 12th. |
| **🏫 Relational Mapping** | Seamless connectivity between Teachers, Classrooms, and the Science/Commerce/Arts streams. |

---

## 🛠️ Modern Tech Stack

### Backend Excellence
* **Framework:** ASP.NET Core 10 (MVC Architecture)
* **ORM:** Entity Framework Core (Code-First Approach)
* **Database:** PostgreSQL with Npgsql Provider
* **Intelligence:** Microsoft Semantic Kernel Integration

### Frontend & UX
* **Design System:** Anuj Dhiman V2 UI (Custom CSS3 & HTML5)
* **Components:** Bootstrap 5 & FontAwesome 6 Pro Icons
* **Interactivity:** Dynamic Razor Views & AJAX-powered data fetching

---

## 📐 System Architecture



The system utilizes a **Service-Pattern Architecture** to decouple business logic (AI Processing, Payroll Calculations) from the Controllers, ensuring high maintainability and scalability.

---

## ⚙️ Quick Start

### 1. Environment Setup
* Install [.NET 10 SDK](https://dotnet.microsoft.com/download)
* Ensure [PostgreSQL](https://www.postgresql.org/) service is running.

### 2. Configuration
Update `appsettings.json` with your credentials:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=SchoolERP_DB;Username=postgres;Password=your_pass"
  },
  "GoogleAI": { "ApiKey": "YOUR_GEMINI_KEY" }
}
