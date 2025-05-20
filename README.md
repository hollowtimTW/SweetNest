# 🎂 SweetNest – 微服務甜點商城系統

SweetNest 是一個以 **微服務架構** 打造的甜點商城練習專案，使用 ASP.NET Core 9 開發，並部署於 Google Cloud Platform（GCP）。本專案聚焦於服務拆分與雲端部署實作，包含身分驗證、商品管理、購物車、訂單與優惠卷等功能模組。

---

## 🌐 線上 Demo

👉 [立即體驗 SweetNest 商城](https://sweetnest-web-646048525464.asia-east1.run.app)

> 注意：GCP Cloud Run 首次載入時，**各個服務可能會有冷啟動延遲**，請稍候幾秒。

---

## 🏗️ 專案架構與服務說明

本專案採用 **微服務架構**，各個功能模組皆為獨立專案與容器，透過 REST API（尚未完全遵循 RESTful 標準）進行通訊。主要包含以下服務：

| 服務名稱            | 功能描述                 |
|---------------------|--------------------------|
| `Frontend MVC`       | 使用 ASP.NET Core MVC 撰寫的前端畫面 |
| `Auth Service`       | 使用者註冊、登入、JWT 驗證 |
| `Product Service`    | 商品資料存取與管理       |
| `ShoppingCart Service` | 購物車管理功能          |
| `Order Service`      | 建立與查詢訂單           |
| `Coupon Service`     | 優惠卷查詢與驗證功能      |

---

## 🧰 使用技術

- **語言／框架**：.NET 9、ASP.NET Core MVC / Web API
- **技術**：
  - JWT 身分驗證
  - ASP.NET Identity 驗證與授權
  - Entity Framework Core + Code First
  - AutoMapper、LINQ
- **前端相關**：
  - Bootstrap 5、jQuery、AJAX
- **資料庫**：
  - MSSQL（使用 GCP Cloud SQL）
- **部署與雲端技術**：
  - Docker 容器化
  - GCP Cloud Run（服務部署）
  - GCP Cloud SQL（資料庫）
  - GCP Cloud Storage（商品圖片儲存）

---

## 🎯 專案目的與特色

- ✅ 練習微服務架構拆分與獨立部署
- ✅ 實作 JWT + Identity 身分驗證流程
- ✅ 將多個服務容器化並部署至 GCP
- ✅ 熟悉 Cloud SQL、Cloud Storage 整合與設定
- ✅ 前後端基礎整合與資料串接

> ⚠️ 本專案僅為後端實作與雲端架構練習，畫面與使用者體驗為簡化版本。部分 API 命名與結構尚未完全遵守 RESTful 規範。

---

## 📱💻 系統畫面預覽（支援 RWD 響應式設計）

本專案使用 Bootstrap 5，具備基本的 RWD 響應式排版能力，支援手機與桌機版畫面自動調整。


### 🏠 首頁畫面

<div align="center">
  <img src="https://github.com/user-attachments/assets/8d62ef05-b5bc-4552-abcd-2698de3f9c47" width="60%" alt="首頁桌機版"/>
  <div>（桌機版）</div>
</div>
</br>
</br>
<div align="center">
  <img src="https://github.com/user-attachments/assets/13d6fc5f-0253-49f5-9e8d-8b428f54c4c7" width="15%" alt="首頁手機版"/>
  <div>（手機版）</div>
</div>


### 🛒 購物車畫面

<div align="center">
   <img src="https://github.com/user-attachments/assets/055723d8-36bd-496b-a5d6-7044f0c1cfea" width="60%" alt="首頁手機版"/>
  <div>（桌機版）</div>
</div>
</br>
</br>
<div align="center">
  <img src="https://github.com/user-attachments/assets/8b6e80a4-6a42-43f4-ad6a-94de0ab4ff93" width="15%" alt="首頁桌機版"/>
  <div>（手機版）</div>
</div>
