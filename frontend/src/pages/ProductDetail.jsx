import React, { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import Loading from "../components/Loading";
import ErrorMessage from "../components/ErrorMessage";
import { productsApi } from "../api/productsApi";
import { getApiErrorMessage } from "../api/axiosClient";

export default function ProductDetail() {
  const { id } = useParams();

  const [item, setItem] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");

  useEffect(() => {
    (async () => {
      setLoading(true);
      setError("");
      try {
        const data = await productsApi.getById(id);
        setItem(data);
      } catch (err) {
        setError(getApiErrorMessage(err));
      } finally {
        setLoading(false);
      }
    })();
  }, [id]);

  if (loading) return <Loading />;
  if (error) return <ErrorMessage message={error} />;
  if (!item) return <p>Not found.</p>;

  return (
    <div>
      <h3>{item.name ?? `Product #${item.id}`}</h3>

      <div style={{ background: "#f6f6f6", padding: 12, borderRadius: 10 }}>
        <p><strong>Id:</strong> {item.id}</p>
        {"price" in item && <p><strong>Price:</strong> {item.price} SEK</p>}
        {"categoryId" in item && <p><strong>CategoryId:</strong> {item.categoryId}</p>}
      </div>

      <div style={{ marginTop: 12 }}>
        <Link to="/products">Back</Link>{" "}
        <Link to={`/products/${item.id}/edit`}>Edit</Link>
      </div>
    </div>
  );
}
