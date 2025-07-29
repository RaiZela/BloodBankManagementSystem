# 🩸 Blood Bank Management System

A web-based platform for managing blood donations, donor data, blood inventory, and hospital requests. This system is being built as part of a **personal portfolio project** to showcase skills in backend development, architecture, and domain modeling.

> 🚧 **Status:** Work in Progress  
> 🔧 **Tech Stack:** ASP.NET Core · Entity Framework Core · SQL Server/SQLite

---

# 🧬 Core Functionalities
## 1. Donor Management
- Register donor (manual or online)

- View/update donor profile

- Donor eligibility checks (age, weight, health conditions)

- Donation history and frequency tracking

- Notifications/reminders for next eligible donation

- Temporary/permanent deferrals tracking

## 2. Recipient Management
- Register patient/recipient

- Link patient with hospital or doctor

- Blood request form creation

- Urgency level tagging (routine/emergency)

- Transfusion history

## 3. Blood Collection Management
- Schedule donation appointments

- Walk-in donor handling

- Donor consent and questionnaire form

- Pre-donation screening (e.g. hemoglobin check)

- Collection bag tracking (barcoding/QR)

## 4. Blood Testing & Processing
- Blood grouping (ABO, Rh)

- Serological screening (HIV, Hepatitis B/C, Syphilis, Malaria)

- NAT Testing (if applicable)

- Component separation (Plasma, RBC, Platelets)

- Quarantine unit handling for untested blood

## 5. Inventory Management
- Real-time blood stock (by type, component, location)

- Expiry management (FIFO)

- Storage management (temperature logs, refrigeration)

- Blood unit labeling with barcode

- Component linking to original donor

## 6. Blood Request and Issuance
- Hospital/department request interface

- Blood unit reservation

- Compatibility checking

- Crossmatching results

- Transfusion issuance & documentation

- Return/reissue/discard units

## 7. Alerts & Notifications
- Low stock alert by blood type

- Expiring units alert

- Donor eligibility reminder

- Appointment confirmation/reminders

- Critical lab test alerts

# 🏥 Operational Modules
## 8. User & Role Management
- Roles: Admin, Lab Technician, Nurse, Doctor, Donor, Receptionist

- Permission control per module

- Audit logs of critical actions

## 9. Reporting & Analytics
- Daily/weekly blood stock report

- Donation trends

- Expired/discarded unit report

- Test result summaries

- Donor retention & frequency stats

- Transfusion outcome stats

## 10. Hospital Integration (Optional)
- HIS (Hospital Information System) integration

- Transfusion reaction reporting

- Bedside transfusion validation (barcode matching)

## 11. Regulatory & Compliance
- GDPR/HIPAA compliance (for personal data)

- WHO guidelines alignment

- Donor consent forms

- Test result audit trails

- Electronic signature support

## 12. Mobile App / Donor Portal (Optional but impactful)
- Self-registration

- Find nearby blood drives

- Donation appointment booking

- Digital donor card

- Blood request status

# 🛠️ Technical & Infrastructure
## 13. System Administration
- Backup & recovery system

- Role-based access logging

- SLA & uptime monitoring

- Data encryption & secure transmission

## 14. Localization & Multilingual Support
- Albanian / English / regional languages

- Date/time and unit formatting

## 15. Deployment Options
- Cloud-hosted (e.g. Azure, AWS)

- On-premises for hospitals

- Mobile-first/responsive design



---

## 🧱 Architecture

This system follows an **N-Layered Architecture**:
Presentation Layer (Web UI / Razor Pages or MVC Controllers)
│
├── Application Layer (Services, DTOs, Interfaces)
│
├── Domain Layer (Entities, Core Logic, Enums)
│
└── Infrastructure Layer (EF Core, Repositories, Identity)


This separation of concerns allows maintainability, scalability, and clear project structure.

---

## 🚀 How to Run (Local Development)

> **Prerequisites:** [.NET 8 SDK](https://dotnet.microsoft.com/download) · SQL Server or SQLite

```bash
git clone https://github.com/RaiZela/BloodBankManagementSystem.git
cd BloodBankManagementSystem

# Apply migrations
dotnet ef database update

# Run the project
dotnet run
```
Then open your browser at https://localhost:5001.

## 🔮 Planned Improvements

- RESTful API for external use (e.g., mobile app)

- SignalR for real-time inventory updates

- Email/SMS reminders for donation eligibility

- Donor badge system or gamification

- Multi-language support (Albanian, English)

## 📌 Why This Project?
This project reflects real-world healthcare workflows while showing:

- Strong backend logic

- Clean architecture practices

- Secure authentication/authorization

- Scalability for institutional use

# Database Scheme

<img width="4369" height="3298" alt="SqlGenerated BBMS" src="https://github.com/user-attachments/assets/74af39d0-0291-49c7-b099-13914f7fb5de" />

