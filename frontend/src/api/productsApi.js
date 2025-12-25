import { axiosClient } from "./axiosClient";

// Kommentar: API-funktioner för Products.
export const productsApi = {
  getAll: async () => {
    const res = await axiosClient.get("/api/products");
    return res.data;
  },

  getById: async (id) => {
    const res = await axiosClient.get(`/api/products/${id}`);
    return res.data;
  },

  create: async (payload) => {
    const res = await axiosClient.post("/api/products", payload);
    return res.data;
  },

  update: async (id, payload) => {
    const res = await axiosClient.put(`/api/products/${id}`, payload);
    return res.data;
  },

  remove: async (id) => {
    const res = await axiosClient.delete(`/api/products/${id}`);
    return res.data;
  },
};
