# Estore – Fullstack Web Application


Applikationen är uppdelad i backend (.NET API) och frontend (React).

---

## 🧱 Arkitekturöversikt

Projektet är uppdelat i tydliga lager enligt en Clean Architecture

### Backend (.NET API)
- **Domain_Layer** – Domänmodeller
- **Application_Layer** – DTOs, interfaces, MediatR, validering
- **Infrastructure_Layer** – Databas, repositories, EF Core
- **Estore (API)** – Controllers, Program.cs, konfiguration

### Frontend (React)
- Ligger i en separat mapp: `frontend/`
- Byggd med **Vite + React**
- Kommunicerar med backend via HTTP (Axios)



## 🗄️ Databas

- **SQL Server (lokal)**
- **Entity Framework Core**
- Migrationer används för att skapa databasen
- Relationer:
  - One-to-many
  - Many-to-many

---

## 🔌 Backend – Funktionalitet

- CRUD-endpoints för flera modeller (t.ex. Products, Users, CartItems)
- DTOs och AutoMapper
- Validering med FluentValidation
- felhantering
- Grundläggande logging
- Swagger för testning av API

### Exempel på endpoints
- `GET /api/products`
- `GET /api/products/{id}`
- `POST /api/products`
- `PUT /api/products/{id}`
- `DELETE /api/products/{id}`

---

## 🎨 Frontend – Funktionalitet

Frontend är byggd i React och innehåller:

- Minst **fyra vyer**
  - Home
  - Listvy
  - Detaljvy
  - Skapa / uppdatera (formulär)
- Formulär med klient-side-validering
- API-integration med Axios
- Loading-states och error-hantering
- Miljövariabler (`.env`) för API-URL

---

## ⚙️ CI – GitHub Actions

Projektet använder **GitHub Actions** som CI-pipeline.

Workflow:
- Körs automatiskt vid **push** och **pull request**
- Steg:
  - Restore
  - Build
  - Test



---


