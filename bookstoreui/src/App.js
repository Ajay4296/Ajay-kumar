import React from 'react';
import './App.css';
import Dashboard from './components/Dashboard';
<<<<<<< HEAD
import {BrowserRouter as Router,Route} from 'react-router-dom';

function App() {
  return (
   
  <Router>
   <Route path='/' component={Dashboard}/>
=======
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
>>>>>>> 94232d33ace64fdab9adbcf9c6338da4cd36410a
   </Router>
  );
}

export default App;
