import { useEffect } from "react";

import { Box } from "@mui/material";
import { useRoute } from "../GlobalProviders";

export const CustomerPage = () => {
  const { setPageTitle } = useRoute();
  useEffect(() => {
    setPageTitle("Customer & Sales Opportunities");
  });
  return <Box mt={10}></Box>;
};
