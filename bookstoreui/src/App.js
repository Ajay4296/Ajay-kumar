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
   <Route path='/' exact component={Login} />
   <Route path='/dashboard' component={Dashboard} />
   <Route path='/ordersummary' component={OrderSummary} />
   </Switch>
   </Router>
  );
}

export default App;
