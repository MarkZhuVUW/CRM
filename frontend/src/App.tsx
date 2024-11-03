import { CssBaseline } from "@mui/material";
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
        <CustomerProvider>
          <RouteProvider />
        </CustomerProvider>
      </ErrorProvider>
    </ThemeProvider>
  </LocalStorageProvider>
);
export default App;
