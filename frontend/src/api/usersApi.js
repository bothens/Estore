import { axiosClient } from "./axiosClient";

// Kommentar: Exempel – uppdatera endpoints om dina user routes skiljer sig.
export const usersApi = {
  getAll: async () => {
    const res = await axiosClient.get("/api/users");
    return res.data;
  },

  getById: async (id) => {
    const res = await axiosClient.get(`/api/users/${id}`);
    return res.data;
  },
};
