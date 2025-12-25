import React, { useEffect, useState } from "react";
import Loading from "../components/Loading";
import ErrorMessage from "../components/ErrorMessage";
import { cartItemsApi } from "../api/cartItemsApi";
import { getApiErrorMessage } from "../api/axiosClient";

export default function CartItems() {
  const [items, setItems] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");

  async function load() {
    setLoading(true);
    setError("");
    try {
      const data = await cartItemsApi.getAll();
      setItems(data);
    } catch (err) {
      setError(getApiErrorMessage(err));
    } finally {
      setLoading(false);
    }
  }

  useEffect(() => { load(); }, []);

  if (loading) return <Loading />;
  if (error) return <ErrorMessage message={error} />;

  return (
    <div>
      <h3>CartItems</h3>
      <pre style={{ background: "#f6f6f6", padding: 12, borderRadius: 10 }}>
        {JSON.stringify(items, null, 2)}
      </pre>
    </div>
  );
}
