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
    <div className="bg-gray-50 min-h-screen py-10 px-4 sm:px-8 md:px-12">
      {/* AI Insight Section */}
      <section className="mb-12">
        <h2 className="text-3xl font-bold text-blue-700 mb-6">🧠 AI Insight Sonuçları</h2>

        {aiInsights.length === 0 ? (
          <p className="text-gray-500 text-sm">🚫 Henüz hiç analiz yapılmadı.</p>
        ) : (
          <div className="grid gap-6 md:grid-cols-2 lg:grid-cols-3">
            {aiInsights.map((insight: any) => (
              <div key={insight.id} className="bg-white p-5 rounded-lg shadow hover:shadow-md transition">
                <p className="text-gray-800 mb-3">{insight.summary}</p>
                <div className="text-xs text-gray-500 border-t pt-2">
                  Oluşturulma: {new Date(insight.createdAt).toLocaleString()}
                </div>
              </div>
            ))}
          </div>
        )}
      </section>

      {/* Culture Insight Section */}
      <section>
        <h2 className="text-3xl font-bold text-green-700 mb-6">🎭 Kültürel İçerikler</h2>

        {cultureInsights.length === 0 ? (
          <p className="text-gray-500 text-sm">📭 Hiç kültürel içerik oluşturulmamış.</p>
        ) : (
          <div className="grid gap-6 md:grid-cols-2 lg:grid-cols-3">
            {cultureInsights.map((insight: any) => (
              <div key={insight.id} className="bg-white p-5 rounded-lg shadow hover:shadow-md transition">
                <p className="text-gray-800 mb-3">{insight.summary}</p>
                <div className="text-xs text-gray-500 border-t pt-2">
                  📍 {insight.latitude.toFixed(3)}, {insight.longitude.toFixed(3)} <br />
                  Oluşturulma: {new Date(insight.createdAt).toLocaleString()}
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
