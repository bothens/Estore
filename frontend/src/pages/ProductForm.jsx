import React, { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import Loading from "../components/Loading";
import ErrorMessage from "../components/ErrorMessage";
import { productsApi } from "../api/productsApi";
import { getApiErrorMessage } from "../api/axiosClient";

// Kommentar: Form-vy för create/edit med enkel klientvalidering.
export default function ProductForm({ mode }) {
  const nav = useNavigate();
  const { id } = useParams();

  const isEdit = mode === "edit";

  const [name, setName] = useState("");
  const [price, setPrice] = useState("0");
  const [categoryId, setCategoryId] = useState("1"); // om du har categoryId i backend

  const [loading, setLoading] = useState(isEdit);
  const [saving, setSaving] = useState(false);
  const [error, setError] = useState("");

  function validate() {
    if (!name.trim()) return "Name is required.";
    if (name.trim().length < 2) return "Name must be at least 2 characters.";

    const p = Number(price);
    if (Number.isNaN(p) || p <= 0) return "Price must be a number greater than 0.";

    const c = Number(categoryId);
    if (Number.isNaN(c) || c <= 0) return "CategoryId must be > 0.";

    return "";
  }

  useEffect(() => {
    if (!isEdit) return;

    (async () => {
      setLoading(true);
      setError("");
      try {
        const data = await productsApi.getById(id);
        setName(data.name ?? "");
        setPrice(String(data.price ?? 0));
        if ("categoryId" in data) setCategoryId(String(data.categoryId ?? 1));
      } catch (err) {
        setError(getApiErrorMessage(err));
      } finally {
        setLoading(false);
      }
    })();
  }, [isEdit, id]);

  async function onSubmit(e) {
    e.preventDefault();
    setError("");

    const msg = validate();
    if (msg) {
      setError(msg);
      return;
    }

    setSaving(true);
    try {
      // Kommentar: Anpassa payload till din backend-DTO om fältnamn skiljer sig.
      const payload = {
        name: name.trim(),
        price: Number(price),
        categoryId: Number(categoryId),
      };

      if (isEdit) {
        await productsApi.update(id, payload);
        nav(`/products/${id}`);
      } else {
        await productsApi.create(payload);
        nav("/products");
      }
    } catch (err) {
      setError(getApiErrorMessage(err));
    } finally {
      setSaving(false);
    }
  }

  if (loading) return <Loading />;

  return (
    <div>
      <h3>{isEdit ? "Edit product" : "Create product"}</h3>

      <ErrorMessage message={error} />

      <form onSubmit={onSubmit} style={{ display: "grid", gap: 10, maxWidth: 360 }}>
        <label>
          Name
          <input value={name} onChange={(e) => setName(e.target.value)} />
        </label>

        <label>
          Price (SEK)
          <input value={price} onChange={(e) => setPrice(e.target.value)} />
        </label>

        <label>
          CategoryId
          <input value={categoryId} onChange={(e) => setCategoryId(e.target.value)} />
        </label>

        <button disabled={saving}>{saving ? "Saving..." : "Save"}</button>
      </form>
    </div>
  );
}
