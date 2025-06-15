import axios from 'axios';

const GEO_API_BASE = 'http://localhost:5001/api/geo';

export async function postGeoQuery(latitude: number, longitude: number) {
  try {
    const response = await axios.post(`${GEO_API_BASE}/query`, {
      latitude,
      longitude,
    });
    return response.data;
  } catch (error) {
    console.error('Geo sorgusu başarısız:', error);
    throw error;
  }
}
