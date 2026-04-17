# ProformaInvoiceGenerator
A advance window appliction for generating automatic Proforma Invoice.
# 🪟 Pro-Glass Automation System (WinForms)

**Professional Glass Industry Invoice & Production Management Tool**

---

## 🚀 Project Overview / प्रोजेक्ट का विवरण

**English:**  
A powerful C# Windows Desktop Application designed to automate **Proforma Invoices (PI)**, **Job Orders**, and **Complex Glass Pricing** for the industry. It features specialized calculation engines for SGU, DGU, and Laminated units, along with smart grid automation.

**हिंदी:**  
यह एक शक्तिशाली C# विंडोज़ एप्लिकेशन है जिसे विशेष रूप से ग्लास इंडस्ट्री के लिए **प्रोफार्मा इनवॉइस (PI)**, **जॉब ऑर्डर** और **प्राइस कैलकुलेशन** को ऑटोमेट करने के लिए बनाया गया है। इसमें SGU, DGU और लैमिनेटेड ग्लास के लिए सटीक औद्योगिक फॉर्मूले और स्मार्ट ग्रिड ऑटोमेशन शामिल हैं।

---

## 🛠 Key Features / मुख्य विशेषताएं

### 1. Advanced Pricing Engine (प्राइसिंग इंजन)
The system uses backend formulas to generate precise **Sqm Price** with automatic rounding:
- **SGU (Single Glass):** `((Sheet/0.85) + Cutting + Tempering) + Profit %`
- **DGU (Double Glass):** `((Outer + Inner)/0.85 + ASP Price) + Profit %`
- **Lamination:** `((Outer + Inner)/0.85 + PVB Price) + Cutting + Tempering + Profit %`
- **Rounding Logic:** e.g., `151.86 -> 152 AED`.

### 2. Auto-Specification Generator
Dynamically creates technical strings based on inputs:
- **Example:** `6mm HD Grey FT Glass + 12mm ASP with U-Insert + 6mm Clear FT Glass with Argon Gas`.
- Supports **U-Insert**, **Argon Gas**, and **Overlap** descriptions automatically.

### 3. Smart Grid & Surcharge Logic
- **The 0.5 Rule:** Any area calculation below 0.5 is automatically treated as **0.5 Sqm**.
- **4.0 Sqm Surcharge:** If a glass panel exceeds 4.0 Sqm, a **+20% (Manual Editable)** surcharge is automatically added to the `Sqm Price`.
- **Price Sync:** The price of the first row automatically applies to the entire section.
- **Auto-Expand:** Pressing 'Enter' in the grid automatically creates a new row.

### 4. Dynamic Other Charges (Polish Logic)
- **SGU Polish:** `(W * H) / 1000 * 2`
- **Lami/DGU Polish:** `(W * H) / 1000 * 4`
- **Multi-Linking:** Target multiple specification sections for a single charge (e.g., Wastage).

---

## 📊 Calculation Example (कैलकुलेशन उदाहरण)


| Input Type | Data | Step-by-Step Logic | Final Result |
| :--- | :--- | :--- | :--- |
| **DGU** | Outer: 46, Inner: 28, ASP: 45 | (74/0.85) + 45 = 132.05 + 15% | **152 AED** |
| **Surcharge** | Area > 4.0 Sqm | 152 + 20% | **182 AED** |

---

## 🖥 UI/UX Highlights (इंटरफ़ेस की विशेषताएं)

- **Input Controls:** Large text boxes for W1, H1, W2, H2 (No Up/Down arrows).
- **Visibility:** Width 2 / Height 2 always show `0` even if empty.
- **Logo:** Large, clear Company Logo box in the header.
- **Job Order Converter:** Global toggle to hide all Prices, Rates, and Amounts for factory production copies.

---

## 📂 Tech Stack (तकनीकी जानकारी)

- **Language:** C# (.NET WinForms)
- **Reports:** Excel Interop & CSV Export (Headers use Full Specification Names).
- **Import:** Smart Excel Import (Needs only W1, H1, W2, H2; calculates the rest automatically).
- **Tracking:** Monthly reports for "Confirmed" PI status only.

---

## 📥 Installation & Contribution

1. **Clone the Repo:** `git clone https://github.com`
2. **Setup Database:** Configure your SQL connection string in `App.config`.
3. **Build:** Use Visual Studio 2019/2022 to build the `.sln` file.

**Master Developers:** We are looking for contributors to optimize PDF printing layouts and enhance the CSV export modules.

---

## 📜 License
Distributed under the **MIT License**. See `LICENSE` for more information.

---
*Created for the Glass Industry Automation.*
