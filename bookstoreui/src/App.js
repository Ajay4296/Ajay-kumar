import React from 'react';
import './App.css';
import Dashboard from './components/Dashboard';
import MyCart from './components/MyCart';
import Login from './components/Login';
import OrderSummary from './components/OrderSummary';
import {BrowserRouter as Router ,Switch, Route } from 'react-router-dom';
function App() {
  return (
  <Router>
  <Switch>
   <Route path='/' exact component={Dashboard} />
   <Route path='/OrderSummary' exact component={OrderSummary} />
   <Route path='/Login' exact component={Login} />
   </Switch>
   </Router>
  );
}

export default App;
