import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import Loading from "../components/Loading";
import ErrorMessage from "../components/ErrorMessage";
import { productsApi } from "../api/productsApi";
import { getApiErrorMessage } from "../api/axiosClient";

export default function ProductsList() {
  const [items, setItems] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");

  async function load() {
    setLoading(true);
    setError("");
    try {
      const data = await productsApi.getAll();
      setItems(data);
    } catch (err) {
      setError(getApiErrorMessage(err));
    } finally {
      setLoading(false);
    }
  }

  useEffect(() => { load(); }, []);

  async function onDelete(id) {
    if (!confirm("Delete product?")) return;

    try {
      await productsApi.remove(id);
      await load();
    } catch (err) {
      alert(getApiErrorMessage(err));
    }
  }

  if (loading) return <Loading />;
  if (error) return <ErrorMessage message={error} />;

  return (
    <div>
      <h3>Products</h3>

      {items.length === 0 ? (
        <p>No products found.</p>
      ) : (
        <ul style={{ paddingLeft: 18 }}>
          {items.map((p) => (
            <li key={p.id} style={{ marginBottom: 10 }}>
              <Link to={`/products/${p.id}`} style={{ fontWeight: 600 }}>
                {p.name ?? `Product #${p.id}`}
              </Link>

              <span style={{ marginLeft: 8, opacity: 0.75 }}>
                {p.price != null ? `— ${p.price} SEK` : ""}
              </span>

              <span style={{ marginLeft: 8 }}>
                <Link to={`/products/${p.id}/edit`}>Edit</Link>
                {" · "}
                <button onClick={() => onDelete(p.id)}>Delete</button>
              </span>
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}
