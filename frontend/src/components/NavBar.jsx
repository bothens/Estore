import React from "react";
import { NavLink } from "react-router-dom";

// Kommentar: Enkel nav. NavLink ger aktiv länk-styling.
export default function NavBar() {
  const linkStyle = ({ isActive }) => ({
    textDecoration: "none",
    padding: "6px 10px",
    borderRadius: 8,
    background: isActive ? "#eaeaea" : "transparent",
    color: "#111",
  });

  return (
    <header style={{ display: "flex", alignItems: "center", gap: 12, marginBottom: 16 }}>
      <h2 style={{ margin: 0 }}>Estore</h2>
      <nav style={{ display: "flex", gap: 8 }}>
        <NavLink to="/" style={linkStyle}>Home</NavLink>
        <NavLink to="/products" style={linkStyle}>Products</NavLink>
        <NavLink to="/products/new" style={linkStyle}>Add product</NavLink>
        <NavLink to="/cartitems" style={linkStyle}>CartItems</NavLink>
      </nav>
    </header>
  );
}
