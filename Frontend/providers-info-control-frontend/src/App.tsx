import React from 'react';
import AuthorizationPage from './api/AuthorizationPage';
import { Routes, Route } from "react-router-dom";
import OwnTypesPage from './components/OwnTypesPage';

function App() {
  return (
    <Routes>
      <Route path="/" element={<AuthorizationPage/>}/>
      <Route path="/own-types" element={<OwnTypesPage/>}/>
    </Routes>
  );
}

export default App;
