// import React, { lazy, Suspense, useEffect } from "react";
import "./App.css";
import Product from "./pages/Product";
import { BrowserRouter as Router, Route, Routes, Link } from "react-router-dom";
import Home from "./pages/Home";
import Create from './components/Product/create';
function App() {
  return (
    <div className="App">
      <Router>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/product" element={<Product />} />
          <Route path="/create" element={<Create/>}/>
        </Routes>
      </Router>
    </div>
  );
}

export default App;