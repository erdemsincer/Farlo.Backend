const HomePage = () => {
    return (
      <div className="min-h-[calc(100vh-64px)] w-full flex items-center justify-center bg-gradient-to-b from-gray-900 to-gray-800 px-4 sm:px-8">
        <div className="text-center w-full">
          {/* Başlık */}
          <h1 className="text-5xl md:text-6xl font-extrabold text-white mb-6 leading-tight drop-shadow">
            Hoş Geldin <span className="inline-block animate-waving-hand">👋</span>
          </h1>
  
          {/* Açıklama */}
          <p className="text-lg md:text-xl text-gray-300 mb-6 leading-relaxed">
            <span className="text-blue-400 font-semibold">Farlo Insight</span> ile harita üzerinden bir konum seç, <br className="hidden sm:block" />
            yapay zeka destekli <span className="text-blue-300">coğrafi</span> ve <span className="text-pink-300">kültürel analizleri</span> anında al!
          </p>
  
          {/* CTA */}
          <div className="mt-10">
            <a
              href="/map"
              className="inline-flex items-center gap-2 bg-blue-600 hover:bg-blue-700 text-white font-semibold py-3 px-6 rounded-lg shadow-lg transition-all duration-300"
            >
              🌍 Haritaya Git ve Analiz Başlat
            </a>
            <p className="text-sm text-gray-400 mt-4">
              Başlamak için yukarıdaki bağlantıya tıkla.
            </p>
          </div>
        </div>
      </div>
    );
  };
  
  export default HomePage;
  