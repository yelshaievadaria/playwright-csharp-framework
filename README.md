# 🧪 Playwright QA Automation Framework

Professional UI automation framework built with Playwright, C#, and NUnit.

This project demonstrates real-world QA automation engineering practices with a focus on clean architecture, scalability, and maintainability.

---

## 🎯 Project Overview

This framework was created to demonstrate:

- End-to-End UI test automation
- Page Object Model (POM) design pattern
- Scalable and maintainable test architecture
- Separation of test logic, page logic, and test data
- Real-world QA automation workflow

The system under test is:  
https://www.saucedemo.com

---

## ⚙️ Tech Stack

- C#
- .NET 8
- Playwright
- NUnit
- Git / GitHub

---

## 🏗 Framework Architecture

The project follows a layered structure:

- **Base**
  - Browser setup and test initialization

- **Pages**
  - Page Object Model classes
  - Encapsulation of UI locators and actions

- **Tests**
  - Test scenarios (positive and negative flows)

- **TestData**
  - Centralized test data (users, passwords, constants)

- **Utilities**
  - Helper methods and reusable logic

---

## 📄 Page Object Model (POM)

Implemented pages:

- LoginPage
- InventoryPage
- CartPage
- CheckoutPage
- CheckoutOverviewPage
- CheckoutCompletePage

Each page contains:
- Locators
- UI actions
- Reusable methods for test interaction

---

## 🧪 Test Coverage

### ✔ Positive Scenarios
- Successful login
- Adding items to cart
- Full checkout process
- Order confirmation validation

### ❌ Negative Scenarios
- Invalid login credentials
- Locked user access
- Empty input validation

---

## 🚀 How to Run

### 1. Restore dependencies
dotnet restore

### 2. Build project
dotnet build

### 3. Run all tests
dotnet test

---

## 🎯 Run Single Test

dotnet test --filter "Name=CompleteCheckoutFlow"

---

## 🔮 Future Improvements

- CI/CD integration with GitHub Actions
- Parallel test execution
- HTML / Allure reporting
- Screenshot capture on failure
- Environment configuration (dev/test/prod)
- API + UI hybrid test coverage
---

## 📸 Screenshots

### Test Execution
![Test Run](Screenshots/test-run.png)

### Framework Structure
![Structure](Screenshots/solution-structure.png)

### Browser Execution
![Browser](Screenshots/browser-run.png)
---

## 👩‍💻 Author

QA Automation Engineer focused on:
- Scalable test automation frameworks
- Clean and maintainable architecture
- Real-world UI testing solutions