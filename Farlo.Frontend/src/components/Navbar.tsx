// src/components/Navbar.tsx
import { Link, useLocation } from 'react-router-dom';

const Navbar = () => {
  const location = useLocation();
  const navItems = [
    { path: '/', label: 'Ana Sayfa' },
    { path: '/map', label: 'Harita' },
    { path: '/insights', label: 'Analizler' },
  ];

  return (
    <header className="bg-gray-800 shadow-md w-full">
    <div className="w-full px-6 py-4 flex justify-between items-center">
      {/* Sola yaslı logo */}
      <Link to="/" className="flex items-center gap-2 text-blue-400 hover:text-blue-300 transition-colors">
        <span className="text-2xl">🌍</span>
        <span className="text-xl font-bold">Farlo Insight</span>
      </Link>
  
      {/* Sağdaki menü */}
      <nav className="flex gap-2 sm:gap-4">
        {navItems.map(({ path, label }) => {
          const isActive = location.pathname === path;
          return (
            <Link
              key={path}
              to={path}
              className={`px-4 py-2 rounded-md text-sm font-medium transition-all duration-200 ${
                isActive
                  ? 'bg-blue-600 text-white shadow'
                  : 'text-gray-300 hover:text-white hover:bg-blue-700'
              }`}
            >
              {label}
            </Link>
          );
        })}
      </nav>
    </div>
  </header>
  
  );
};

export default Navbar;
