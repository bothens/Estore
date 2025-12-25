import React from "react";

// Kommentar: Standard loading-komponent.
export default function Loading({ text = "Loading..." }) {
  return <p>{text}</p>;
}
