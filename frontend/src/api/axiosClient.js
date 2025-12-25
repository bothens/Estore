import axios from "axios";

// Kommentar: En central axios-klient som använder baseURL från .env.
export const axiosClient = axios.create({
  baseURL: import.meta.env.VITE_API_BASE_URL,
  headers: {
    "Content-Type": "application/json",
  },
});

// Kommentar: Helper för att få en “mänsklig” feltext från backend.
export function getApiErrorMessage(err) {
  const data = err?.response?.data;

  // .NET ProblemDetails brukar ha title/detail
  if (data?.detail) return data.detail;
  if (data?.title) return data.title;

  // FluentValidation kan komma som errors-dict
  if (data?.errors) {
    const firstKey = Object.keys(data.errors)[0];
    if (firstKey && data.errors[firstKey]?.length) return data.errors[firstKey][0];
  }

  return err?.message ?? "Unknown error";
}
