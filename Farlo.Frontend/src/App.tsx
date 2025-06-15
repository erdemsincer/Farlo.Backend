import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Layout from './layouts/Layout';
import MapPage from './pages/MapPage';
import HomePage from './pages/HomePage';
import InsightListPage from './pages/InsightListPage';


function App() {
  return (
    <BrowserRouter>
      <Layout>
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/map" element={<MapPage />} />
          <Route path="/insights" element={<InsightListPage />} />
        </Routes>
      </Layout>
    </BrowserRouter>
  );
}

export default App;
