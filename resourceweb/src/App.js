import React, { Component } from "react";
import { Route, Redirect, Switch } from "react-router-dom";
import { ToastContainer } from "react-toastify";
import CustomerForm from "./components/customerForm.jsx";
import RosterForm from "./components/rosterForm";
import NotFound from "./components/notFound";
import NavMenu from "./components/navMenu";
import FooterSection from "./components/sections/footerSection";
import "react-toastify/dist/ReactToastify.css";
import "./App.css";

class App extends Component {
  render() {
    return (
      <React.Fragment>
        <div className="main-container">
        <ToastContainer />
        <NavMenu />
        <main className="container">
          <Switch>
            <Route path="/customer" component={CustomerForm} />
            <Route path="/roster" component={RosterForm} />
            <Route path="/not-found" component={NotFound} />
            <Redirect from="/" exact to="/customer" />
            <Redirect to="/not-found" />
          </Switch>
        </main>
        </div>
        <FooterSection />
      </React.Fragment>
    );
  }
}

export default App;
