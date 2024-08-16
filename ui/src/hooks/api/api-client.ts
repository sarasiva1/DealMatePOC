import axios from "axios";
import { environmentalVariable } from "../../common/env-variables";
import { getData } from "../../common/app-data";

const apiClient = axios.create({
  baseURL: environmentalVariable.BASE_URL,
  headers: {
    Authorization: `Bearer ${getData("token")}`,
  },
});

apiClient.interceptors.response.use(
  (response) => response,
  (error) => {
    if (error.code === "ERR_NETWORK") {
      console.log("error", error);
      return;
    } else {
      return Promise.reject(error);
    }
  }
);

export default apiClient;
