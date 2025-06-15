import { type ReactNode } from 'react';
import { useLocation } from 'react-router-dom';
import Navbar from '../components/Navbar';

const Layout = ({ children }: { children: ReactNode }) => {
  const location = useLocation();
  const isFullWidthPage = location.pathname === '/' || location.pathname === '/map';

  return (
    <div className="min-h-screen flex flex-col bg-gray-900 text-white font-sans">
      <Navbar />

      <main className={`flex-grow ${isFullWidthPage ? '' : 'max-w-7xl mx-auto px-6 py-8'}`}>
        {children}
      </main>

      <footer className="bg-gray-800 text-center py-4 text-xs text-gray-400 border-t border-gray-700">
        © {new Date().getFullYear()} Farlo. Tüm hakları saklıdır.
      </footer>
    </div>
  );
};

export default Layout;
