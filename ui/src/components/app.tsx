import React from "react";
import { useRoutes } from "react-router-dom";
import routes from "../common/routes";

const App = () => {
  const pages = useRoutes(routes);
  return <div className="App">{pages}</div>;
};

export default App;
