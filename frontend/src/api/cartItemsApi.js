import { axiosClient } from "./axiosClient";

// Kommentar: Exempel – uppdatera endpoints om dina cartitems routes skiljer sig.
export const cartItemsApi = {
  getAll: async () => {
    const res = await axiosClient.get("/api/cartitems");
    return res.data;
  },

  create: async (payload) => {
    const res = await axiosClient.post("/api/cartitems", payload);
    return res.data;
  },

  remove: async (id) => {
    const res = await axiosClient.delete(`/api/cartitems/${id}`);
    return res.data;
  },
};
