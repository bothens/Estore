import React from "react";

// Kommentar: Standard error-komponent.
export default function ErrorMessage({ message }) {
  if (!message) return null;
  return <p style={{ color: "crimson" }}>Error: {message}</p>;
}
