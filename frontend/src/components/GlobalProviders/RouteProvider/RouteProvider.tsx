import { CustomerDetailsPage } from "@frontend-ui/components/CustomerDetailsPage";
import { CustomerPage } from "@frontend-ui/components/CustomerPage";
import { Header } from "@frontend-ui/components/Header";

import { createContext, useContext, useState } from "react";
import { BrowserRouter, Navigate, Route, Routes } from "react-router-dom";

interface RouteContext {
  pageTitle: string;
  setPageTitle: React.Dispatch<React.SetStateAction<string>>;
}

const RouteContext = createContext<RouteContext>({
  pageTitle: "",
  setPageTitle: () => {
    throw new Error("setPageTitle function not in context.");
  },
});

export const useRoute = () => useContext(RouteContext);

const RouteProvider = () => {
  const [pageTitle, setPageTitle] = useState("");

  return (
    <RouteContext.Provider value={{ pageTitle, setPageTitle }}>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Navigate to="/customers" />} />

          <Route
            path="/customers"
            element={
              <>
                <Header />
                <CustomerPage />
              </>
            }
          />

          <Route
            path="/customers/:customerId/salesopportunities"
            element={
              <>
                <Header />
                <CustomerDetailsPage />
              </>
            }
          />
        </Routes>
      </BrowserRouter>
    </RouteContext.Provider>
  );
};
export default RouteProvider;
