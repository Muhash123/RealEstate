# Real Estate UI Framework (Yardi-Style)

A high-performance, responsive Real Estate User Interface built with **React** and **Vite**. This project demonstrates a modular architecture for property management systems, focusing on reusable components and reactive data flow.

---

## 🏗 Component Architecture

The UI is built using a "Top-Down" approach where data flows from container pages to functional components.

### 🧩 Core Components
* **Navbar**: A sticky navigation bar featuring branding and primary menu links (Properties, Solutions, About).
* **PropertyCard**: The primary UI unit. It handles individual property data and features:
    * **Conditional Rendering**: Expandable "Details" section.
    * **Dynamic Styling**: Price and location formatting.
    * **Stateful UI**: Interactive favorite/like toggles.
* **Footer**: A standardized informational footer for legal and copyright data.

### 📄 Pages
* **HomePage**: The main landing container. It manages the global state for property listings and handles the asynchronous loading lifecycle.

---

## ⚡ UI Logic & Features

### 1. Data Mapping
The UI utilizes the JavaScript `.map()` function to transform raw data arrays into a grid of interactive `PropertyCard` components, ensuring the code remains DRY (Don't Repeat Yourself).

### 2. State Management (`useState`)
Each component maintains its own local state:
* **UI Feedback**: A loading spinner/message appears automatically while data is being "fetched".
* **Local Interactions**: Expanding details in one card does not affect others, demonstrating React's independent component instances.

### 3. Lifecycle Management (`useEffect`)
The application simulates a real-world API environment by using the `useEffect` hook to trigger a simulated 2-second data fetch upon the initial page load.

---

## 🎨 Design System
* **Theme**: Dark-mode optimized for professional real estate dashboards.
* **Layout**: Flexbox-based grid system for responsive property listings.
* **Transitions**: Smooth CSS transitions for hover states and detail expansion.

---

## 🚀 Development Instructions

1.  **Clone the Repository**:
    ```bash
    git clone [https://github.com/Muhash123/React-real-estate.git](https://github.com/Muhash123/React-real-estate.git)
    ```
2.  **Install UI Dependencies**:
    ```bash
    npm install
    ```
3.  **Launch Local Server**:
    ```bash
    npm run dev
    ```

---

## 📂 Project Structure
```text
src/
 ┣ components/       # Reusable UI Bricks (Navbar, Footer, PropertyCard)
 ┣ pages/            # Page-level containers (HomePage)
 ┣ App.jsx           # Main Layout Orchestrator
 ┗ main.jsx          # Entry point
