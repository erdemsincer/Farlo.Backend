import { useEffect, useState } from "react";
import { getAIInsights, getCultureInsights } from "../services/insightService";

const InsightListPage = () => {
  const [aiInsights, setAiInsights] = useState([]);
  const [cultureInsights, setCultureInsights] = useState([]);

  useEffect(() => {
    const fetchInsights = async () => {
      try {
        const ai = await getAIInsights();
        const culture = await getCultureInsights();
        setAiInsights(ai);
        setCultureInsights(culture);
      } catch (error) {
        console.error("Veriler alınamadı:", error);
      }
    };

    fetchInsights();
  }, []);

  return (
    <div className="bg-gray-100 min-h-screen py-12 px-4 sm:px-8 md:px-16">
      {/* AI Insight Section */}
      <section className="mb-16">
        <h2 className="text-3xl font-extrabold text-blue-700 mb-6 flex items-center gap-2">
          🧠 AI Insight Sonuçları
        </h2>

        {aiInsights.length === 0 ? (
          <p className="text-gray-600 text-base">🚫 Henüz hiç analiz yapılmamış.</p>
        ) : (
          <div className="grid gap-6 md:grid-cols-2 lg:grid-cols-3">
            {aiInsights.map((insight: any) => (
              <div
                key={insight.id}
                className="bg-white rounded-xl p-6 shadow-sm hover:shadow-md transition-all duration-300"
              >
                <p className="text-gray-800 text-base mb-4 line-clamp-4">{insight.summary}</p>
                <div className="text-xs text-gray-500 border-t pt-3">
                  📅 Oluşturulma: {new Date(insight.createdAt).toLocaleString()}
                </div>
              </div>
            ))}
          </div>
        )}
      </section>

      {/* Culture Insight Section */}
      <section>
        <h2 className="text-3xl font-extrabold text-green-700 mb-6 flex items-center gap-2">
          🎭 Kültürel İçerikler
        </h2>

        {cultureInsights.length === 0 ? (
          <p className="text-gray-600 text-base">📭 Hiç kültürel içerik oluşturulmamış.</p>
        ) : (
          <div className="grid gap-6 md:grid-cols-2 lg:grid-cols-3">
            {cultureInsights.map((insight: any) => (
              <div
                key={insight.id}
                className="bg-white rounded-xl p-6 shadow-sm hover:shadow-md transition-all duration-300"
              >
                <p className="text-gray-800 text-base mb-4 line-clamp-5">{insight.summary}</p>
                <div className="text-xs text-gray-500 border-t pt-3 space-y-1">
                  <p>📍 Koordinat: {insight.latitude.toFixed(3)}, {insight.longitude.toFixed(3)}</p>
                  <p>📅 Oluşturulma: {new Date(insight.createdAt).toLocaleString()}</p>
                </div>
              </div>
            ))}
          </div>
        )}
      </section>
    </div>
  );
};

export default InsightListPage;
