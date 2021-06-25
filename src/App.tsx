import { SWRConfig } from "swr";
import {
  BrowserRouter as Router,
  Switch,
  Route,
} from "react-router-dom";

import { fetcher } from "./utils/fetcher";

import { PrivateRoute } from "./components/PrivateRoute/PrivateRoute";
import { UserContextProvider } from "./components/UserContext/UserContext";

import { AdvertPage } from "./views/AdvertPage/AdvertPage";
import { Login } from "./views/Login/Login";
import { Index } from "./views/Index/Index";
import { NotFound } from "./components/NotFound/NotFound";

function App() {
  return (
    <UserContextProvider>
      <SWRConfig value={{ fetcher }}>
        <Router>
          <Switch>
            <PrivateRoute path="/" exact component={Index} fallbackComponent={Login} />
            <PrivateRoute path="/adverts/:id" exact component={AdvertPage} />
            <Route component={NotFound} />
          </Switch>
        </Router>
      </SWRConfig>
    </UserContextProvider>
  );
}

export default App;
