import React, { lazy, Suspense, useEffect } from "react";
import "./App.css";
import Home from "./pages/Home";
import Product from "./pages/Product";
import Category from "./pages/Category";
import { BrowserRouter as Router, Route, BrowserRouter, Link,Switch } from "react-router-dom";
import Update  from "./components/product/update";
import Create from './components/product/create';
import CreateCate from './components/category/create';
import UpdateCate from './components/category/update';
function App() {
  return (
    <div>
      <BrowserRouter>
        <Switch>
            {/* <Route path="/" element={<Home />} /> */}
            <Route exact path="/" component={Home} />
            <Route path="/product" component={Product} />
            <Route path="/category" component={Category} />
            <Route path="/addpro" component={Create}/>
            <Route path="/editpro/:id?" component={Update}/>
            <Route path="/addcate" component={CreateCate}/>
            <Route path="/editcate/:id?" component={UpdateCate}/>
          </Switch>
      </BrowserRouter>
    </div>
  );
}

export default App;