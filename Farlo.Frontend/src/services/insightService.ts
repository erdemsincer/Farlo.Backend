import axios from "axios";

const BASE_URL = "http://localhost:5003"; // InsightViewerService

export const getAIInsights = async () => {
  const response = await axios.get(`${BASE_URL}/api/insight/ai`);
  return response.data;
};

export const getCultureInsights = async () => {
  const response = await axios.get(`${BASE_URL}/api/insight/culture`);
  return response.data;
};
