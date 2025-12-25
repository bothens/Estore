import React from "react";
import { Routes, Route } from "react-router-dom";
import NavBar from "./components/NavBar";

import Home from "./pages/Home";
import ProductsList from "./pages/ProductsList";
import ProductDetail from "./pages/ProductDetail";
import ProductForm from "./pages/ProductForm";
import CartItems from "./pages/CartItems";

export default function App() {
  return (
    <div style={{ fontFamily: "system-ui", maxWidth: 900, margin: "0 auto", padding: 16 }}>
      <NavBar />

      <Routes>
        <Route path="/" element={<Home />} />

        <Route path="/products" element={<ProductsList />} />
        <Route path="/products/new" element={<ProductForm mode="create" />} />
        <Route path="/products/:id" element={<ProductDetail />} />
        <Route path="/products/:id/edit" element={<ProductForm mode="edit" />} />

        <Route path="/cartitems" element={<CartItems />} />
      </Routes>
    </div>
  );
}
