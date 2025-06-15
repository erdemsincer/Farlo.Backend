import { useState } from 'react';
import { MapContainer, TileLayer, Marker, useMapEvents } from 'react-leaflet';
import 'leaflet/dist/leaflet.css';
import L from 'leaflet';
import { postGeoQuery } from '../services/geoService';


import markerIcon from 'leaflet/dist/images/marker-icon.png';
import markerShadow from 'leaflet/dist/images/marker-shadow.png';

L.Icon.Default.mergeOptions({
  iconUrl: markerIcon,
  shadowUrl: markerShadow,
});

const MapPage = () => {
  const [position, setPosition] = useState<[number, number] | null>(null);

  function LocationMarker() {
    useMapEvents({
      click(e) {
        setPosition([e.latlng.lat, e.latlng.lng]);
      }
    });

    return position === null ? null : <Marker position={position} />;
  }

  const handleAnalyze = async () => {
    if (!position) return;
  
    try {
      const [lat, lng] = position;
      console.log("Analiz başlatılıyor:", lat, lng);
      
      const result = await postGeoQuery(lat, lng);
      console.log("Analiz tetiklendi:", result);
  
      // Opsiyonel: kullanıcıya bildirim gösterilebilir
      alert("Analiz başlatıldı! Sonuçlar birkaç saniye içinde hazır olacak.");
    } catch (error) {
      alert("Bir hata oluştu. Lütfen tekrar deneyin.");
    }
  };
  

  return (
    <div className="flex flex-col h-[calc(100vh-64px)] bg-gray-50">
      {/* Bilgilendirici üst bar */}
      <div className="bg-blue-50 border-b border-blue-200 text-gray-800 px-6 py-3 text-sm">
        🌍 Haritaya tıklayarak konum seçin. Ardından <strong>"Analiz Et"</strong> butonuna basın.
      </div>

      {/* Harita alanı */}
      <div className="relative flex-grow">
        <MapContainer
          center={[39, 35]}
          zoom={6}
          className="h-full w-full z-0 rounded-md overflow-hidden"
        >
          <TileLayer
            attribution='&copy; OpenStreetMap katkıda bulunanlar'
            url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
          />
          <LocationMarker />
        </MapContainer>

        {/* Konum bilgisi kutusu */}
        {position && (
          <div className="absolute top-6 left-6 bg-white text-sm text-gray-800 px-4 py-2 rounded shadow-lg border z-10">
            📍 Seçilen Konum: <br />
            <span className="font-medium">
              {position[0].toFixed(5)}, {position[1].toFixed(5)}
            </span>
          </div>
        )}

        {/* Analiz butonu */}
        {position && (
          <div className="absolute bottom-6 right-6 z-10">
            <button
              onClick={handleAnalyze}
              className="bg-blue-600 hover:bg-blue-700 transition-colors duration-200 text-white px-6 py-3 rounded-lg shadow-lg text-sm font-semibold"
            >
              🔍 Analiz Et
            </button>
          </div>
        )}
      </div>
    </div>
  );
};

export default MapPage;
