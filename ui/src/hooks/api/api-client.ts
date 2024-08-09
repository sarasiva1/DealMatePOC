import axios from "axios";

const apiClient = axios.create({
  baseURL: "http://localhost:8000", 
});

apiClient.interceptors.response.use(
  (response) => response,
  (error) => {
    if (error.code === "ERR_NETWORK") {
      window?.location?.reload();
    } else {
      return Promise.reject(error);
    }
  }
);

export default apiClient;
