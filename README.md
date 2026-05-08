```markdown
# 🧪 Playwright QA Automation Framework

Professional UI automation framework built with Playwright, C#, and NUnit.

This project demonstrates modern QA automation practices with a focus on maintainable architecture, reusable components, and scalable UI test design. The framework follows the Page Object Model (POM) pattern and includes both positive and negative end-to-end test scenarios.

---

## 📌 Project Overview

The project was created as part of a QA Automation portfolio to demonstrate:
- UI automation using Playwright
- clean framework architecture
- reusable page objects
- scalable test structure
- centralized test data management
- real-world automation workflow

Application under test:

https://www.saucedemo.com

---

## ⚙️ Tech Stack

- C#
- .NET 8
- Playwright
- NUnit
- Git
- GitHub

---

## 🏗 Framework Architecture

PlaywrightTests/
│
├── Base/
│   └── BaseTest.cs
│
├── Pages/
│   ├── LoginPage.cs
│   ├── InventoryPage.cs
│   ├── CartPage.cs
│   ├── CheckoutPage.cs
│   ├── CheckoutOverviewPage.cs
│   └── CheckoutCompletePage.cs
│
├── Tests/
│   └── LoginTests.cs
│
├── TestData/
│   └── Users.cs
│
├── Utilities/
│   └── WaitHelpers.cs
│
└── README.md

---

## 🧩 Framework Design

### Base Layer
Contains browser setup, Playwright initialization, and shared test configuration.

### Pages Layer
Implements the Page Object Model (POM).

Each page class contains:
- locators
- page actions
- reusable methods

Implemented pages:
- LoginPage
- InventoryPage
- CartPage
- CheckoutPage
- CheckoutOverviewPage
- CheckoutCompletePage

### Tests Layer
Contains:
- end-to-end scenarios
- UI validations
- assertions
- positive and negative tests

### TestData Layer
Stores reusable test data:
- usernames
- passwords
- constants

### Utilities Layer
Contains reusable helper methods and wait utilities.

---

## ✅ Automated Test Coverage

### Positive Scenarios
- Successful login
- Add product to cart
- Complete checkout flow
- Order confirmation validation

### Negative Scenarios
- Invalid password validation
- Locked user validation
- Empty credentials validation

---

## 🚀 Running Tests

### Restore dependencies

dotnet restore

### Build project

dotnet build

### Run all tests

dotnet test

### Run a single test

dotnet test --filter "Name=CompleteCheckoutFlow"

---

## 🔮 Future Improvements

Planned enhancements:
- CI/CD integration
- Parallel test execution
- HTML / Allure reporting
- Screenshot capture on failure
- Environment configuration
- API + UI hybrid testing

---

## 👩‍💻 Author

QA Engineer focused on:
- automation testing
- scalable frameworks
- clean architecture
- maintainable UI testing
```
