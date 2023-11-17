import React from "react";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import Home from "./components/Home";
import Weather from "./components/Weather";
import NotFound from "./components/NotFound";

function App() {
  return (
    <Router>
      <Switch>
        <Route exact path="/" component={Home} />
        <Route path="/weather" component={Weather} />
        <Route component={NotFound} />
      </Switch>
    </Router>
  );
}

export default App;
