import { Route, RouteProps } from "react-router-dom";
import { NotFound } from "../NotFound/NotFound";
import { useUserData } from "../UserContext/UserContext";

interface PrivateRouteProps extends RouteProps  {
  fallbackComponent?: React.FC
}

export const PrivateRoute = ({ fallbackComponent, ...props }: PrivateRouteProps) => {
  const { data } = useUserData();
  const isLoggedIn = data !== null;

  if (!isLoggedIn) {
    return fallbackComponent
      ? <Route {...props} component={fallbackComponent} />
      : <Route component={NotFound} />;
  }

  return (
    <Route {...props} />
  );
}
