import { CssBaseline } from "@mui/material";
import { GoogleOAuthProvider } from "@react-oauth/google";
import {
  CustomerProvider,
  ErrorProvider,
  LocalStorageProvider,
  RouteProvider,
  ThemeProvider,
} from "./components/GlobalProviders";
const App = () => (
  <LocalStorageProvider>
    <ThemeProvider>
      <CssBaseline />
      <ErrorProvider>
        <RouteProvider />
      </ErrorProvider>
    </ThemeProvider>
  </LocalStorageProvider>
);
export default App;
