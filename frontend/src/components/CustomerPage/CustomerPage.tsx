import React, { useEffect, useState } from "react";
import { Box, CircularProgress, Grid, Typography, Paper, Pagination } from "@mui/material";
import { useCustomer, useRoute } from "../GlobalProviders";
import { Customer, PaginatedResponse, SalesOpportunity } from "../GlobalProviders/CustomerProvider/types";

export const CustomerPage = () => {
  const { setPageTitle } = useRoute();
  const { getCustomers, getSalesOpportunities } = useCustomer();

  const [customers, setCustomers] = useState<PaginatedResponse<Customer>>({ data: [], totalCount: 0 });
  const [salesOpportunities, setSalesOpportunities] = useState<PaginatedResponse<SalesOpportunity> | null>(null);
  const [loadingCustomers, setLoadingCustomers] = useState(true);
  const [loadingSalesOpportunities, setLoadingSalesOpportunities] = useState(false);
  const [page, setPage] = useState(1);
  const [pageSize] = useState(10); // Fixed page size

  useEffect(() => {
    setPageTitle("Customer & Sales Opportunities");
    fetchCustomers();
  }, [setPageTitle, page]);

  const fetchCustomers = async () => {
    setLoadingCustomers(true);
    try {
      const response = await getCustomers(page, pageSize);
      setCustomers(response);
    } catch (error) {
      console.error("Failed to fetch customers:", error);
    } finally {
      setLoadingCustomers(false);
    }
  };

  const handleCustomerClick = async (customerId: string) => {
    setLoadingSalesOpportunities(true);
    try {
      const response = await getSalesOpportunities(customerId);
      setSalesOpportunities(response);
    } catch (error) {
      console.error("Failed to fetch sales opportunities:", error);
    } finally {
      setLoadingSalesOpportunities(false);
    }
  };

  const handlePageChange = (event: React.ChangeEvent<unknown>, value: number) => {
    setPage(value);
  };

  return (
    <Box mt={10}>
      <Typography variant="h4" gutterBottom>
        Customers
      </Typography>

      {loadingCustomers ? (
        <CircularProgress />
      ) : (
        <>
          <Grid container spacing={2}>
            {customers.data.map((customer: Customer) => (
              <Grid item xs={12} sm={6} md={4} key={customer.id}>
                <Paper elevation={3} style={{ padding: "16px", cursor: "pointer" }} onClick={() => handleCustomerClick(customer.id)}>
                  <Typography variant="h6">{customer.name}</Typography>
                  <Typography variant="body2">Email: {customer.email}</Typography>
                  <Typography variant="body2">Phone: {customer.phoneNumber}</Typography>
                  <Typography variant="body2">Status: {customer.status}</Typography>
                </Paper>
              </Grid>
            ))}
          </Grid>

          <Pagination
            count={Math.ceil(customers.totalCount / pageSize)}
            page={page}
            onChange={handlePageChange}
            variant="outlined"
            shape="rounded"
            color="primary"
            style={{ marginTop: "20px" }}
          />
        </>
      )}

      {loadingSalesOpportunities && <CircularProgress style={{ marginTop: "20px" }} />}

      {salesOpportunities && (
        <Box mt={5}>
          <Typography variant="h5">Sales Opportunities</Typography>
          <Grid container spacing={2}>
            {salesOpportunities.data.map((opportunity: SalesOpportunity) => (
              <Grid item xs={12} sm={6} md={4} key={opportunity.id}>
                <Paper elevation={3} style={{ padding: "16px" }}>
                  <Typography variant="h6">{opportunity.name}</Typography>
                  <Typography variant="body2">Status: {opportunity.status}</Typography>
                  <Typography variant="body2">Created At: {new Date(opportunity.createdAt).toLocaleDateString()}</Typography>
                </Paper>
              </Grid>
            ))}
          </Grid>

          <Pagination
            count={Math.ceil(salesOpportunities.totalCount / pageSize)}
            page={page}
            onChange={handlePageChange}
            variant="outlined"
            shape="rounded"
            color="primary"
            style={{ marginTop: "20px" }}
          />
        </Box>
      )}
    </Box>
  );
};