# 🎓 AlgoxInstitute (EduBridge) - LMS

> **Bridging the Digital Divide with Accessible Education**
> *A Hackathon Project for SDG 4 (Quality Education) & SDG 10 (Reduced Inequalities)*

<img width="1843" height="368" alt="Screenshot 2026-01-03 073814" src="https://github.com/user-attachments/assets/f0339a0a-5e63-424e-ba79-e630ea835045" />

## 🚀 Project Overview
**AlgoxInstitute** is a lightweight, offline-first Learning Management System (LMS) designed for educational institutions with limited internet infrastructure. It allows students to track their progress and download course materials (PDFs) for offline study, ensuring that education is accessible to everyone, everywhere.

## 🎨 UI/UX Design
We designed a modern, accessible interface before writing code. You can explore our original high-fidelity prototype here:
👉 **[View Figma Prototype]([PASTE_YOUR_FIGMA_LINK_HERE](https://drive.google.com/drive/folders/1R2GjBCy2DyKOjs7e89_sT_faRzIwj1aX?usp=sharing))**

## 🌟 Key Features
* **👩‍🎓 Student Dashboard:** View enrolled courses, track progress with visual bars, and access offline content.
* **👨‍🏫 Teacher Portal:** Create courses, manage descriptions, and upload resource materials (PDFs).
* **🔐 Role-Based Access:** Secure authentication for Admins, Teachers, and Students using ASP.NET Identity.
* **📂 Offline Mode:** Dedicated "Download PDF" feature for low-bandwidth environments.
* **📱 Responsive Design:** Fully functional on mobile devices using Bootstrap 5.

## 🛠️ Tech Stack
### **Frontend (User Interface)**
* **HTML5 & Razor Syntax (`.cshtml`):** Embedded C# logic for dynamic content.
* **CSS3 & Bootstrap 5:** Responsive design and styling.
* **JavaScript & jQuery:** Client-side interactivity and validation.

### **Backend (Logic & Data)**
* **C# (ASP.NET Core MVC 8.0):** Core logic, controllers, and security.
* **Entity Framework Core:** ORM for database management.
* **SQL Server:** Database for storing users and courses.

## 📸 Screenshots
<img width="1920" height="1080" alt="Screenshot (2)" src="https://github.com/user-attachments/assets/ca0b822e-700d-4abe-9441-9e235e4bff98" />

<img width="1920" height="1080" alt="Screenshot (4)" src="https://github.com/user-attachments/assets/77c6ae96-5a62-44a7-959b-9b8896ddd0c7" />

<img width="1920" height="1080" alt="Screenshot (6)" src="https://github.com/user-attachments/assets/a5600f55-b784-4393-8650-4ee2ff45cad4" />

<img width="1920" height="1080" alt="Screenshot (5)" src="https://github.com/user-attachments/assets/c87c9fcc-8bca-489c-9acb-40c7ee7bf40a" />


## ⚙️ Installation & Setup
Follow these steps to run the project locally:

1.  **Clone the Repository**
    ```bash
    git clone [https://github.com/your-username/AlgoxInstitute.git](https://github.com/your-username/AlgoxInstitute.git)
    ```
2.  **Navigate to Project Directory**
    ```bash
    cd AlgoxInstitute
    ```
3.  **Configure Database**
    * Update `appsettings.json` with your local SQL Server connection string.
    * Run Migrations:
    ```bash
    dotnet ef database update
    ```
4.  **Run the Application**
    ```bash
    dotnet run
    ```
5.  **Access the App**
    * Open your browser and go to `https://localhost:7193` (or the port shown in your terminal).

## 🧠 Challenges & Learnings
This project was a significant learning journey for our team.
* **New Tech Stack:** We are new to the **.NET Framework**. Moving from concept to a working MVC application required us to learn C#, Entity Framework, and Razor syntax on the fly.
* **Integration Hurdles:** Connecting our custom frontend designs with the backend logic was our biggest challenge. We spent a lot of time debugging how Controllers talk to Views and resolving merge conflicts between the UI and database logic.
* **Deployment:** Our original goal was to deploy to Microsoft Azure. However, due to the intense focus required to get the core features working and the learning curve involved, we ran out of time for cloud deployment. The project currently runs locally.

## 👥 The Team
* **Member 1** - Full Stack Developer
* **Member 2** - Frontend Designer
* **Member 3** - Database Architect

---
*Built with ❤️ for the 2026 Hackathon.*
