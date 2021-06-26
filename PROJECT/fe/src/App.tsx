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
import { CreateOfferPage } from "./views/CreateOfferPage/CreateOfferPage";
import { IndexPage } from "./views/IndexPage/IndexPage";

import { NotFound } from "./components/NotFound/NotFound";
import { PageLayout } from "./components/PageLayout/PageLayout";

import "./App.css";

function App() {
  return (
    <SWRConfig value={{ fetcher }}>
      <Router>
        <UserContextProvider>
          <PageLayout>
            <Switch>
              <PrivateRoute path="/" exact component={IndexPage} fallbackComponent={Login} />
              <PrivateRoute path="/ogloszenia/:id" exact component={AdvertPage} />
              <PrivateRoute path="/ogloszenia/:id/nowe" exact component={CreateOfferPage} />
              <Route component={NotFound} />
            </Switch>
          </PageLayout>
        </UserContextProvider>
      </Router>
    </SWRConfig>
  );
}

export default App;
