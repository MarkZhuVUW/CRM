import React, { useEffect, useState } from "react";
import {
  Button,
  Card,
  CardActions,
  CardContent,
  CircularProgress,
  Container,
  FormControl,
  Grid,
  InputLabel,
  MenuItem,
  Pagination,
  PaginationItem,
  Select,
  TextField,
  Tooltip,
  Typography,
} from "@mui/material";
import { useCustomer, useRoute } from "../GlobalProviders";
import {
  Customer,
  CustomerStatus,
} from "../GlobalProviders/CustomerProvider/types";
import { useNavigate } from "react-router-dom";
import { Box } from "@mui/system";
import IconButton from "@mui/material/IconButton";
import ArrowDownwardIcon from "@mui/icons-material/ArrowDownward";
import ArrowUpwardIcon from "@mui/icons-material/ArrowUpward";
import CustomerCard from "./CustomerCard";

const CustomerPage = () => {
  const { setPageTitle } = useRoute();
  const { getCustomers, setCurrentCustomer } = useCustomer();
  const [customers, setCustomers] = useState<Customer[]>([]);
  const [loadingCustomers, setLoadingCustomers] = useState(true);
  const [page, setPage] = useState(1);
  const [totalCount, setTotalCount] = useState(0);
  const [pageSize] = useState(5);
  const [filterName, setFilterName] = useState("");
  const [filterStatus, setFilterStatus] = useState("");
  const [sortField, setSortField] = useState("");
  const [sortDirection, setSortDirection] = useState("asc");
  const [isEditing, setIsEditing] = useState<boolean>(false);
  const [status, setStatus] = useState<CustomerStatus>(CustomerStatus.Active);
  const navigate = useNavigate();

  useEffect(() => {
    setPageTitle("Customer");
    fetchCustomers();
  }, [setPageTitle, page, filterName, filterStatus, sortField, sortDirection]);

  const buildFilterString = () => {
    const filters = [];
    if (filterName !== "") {
      filters.push("name=" + filterName);
    }
    if (filterStatus !== "") {
      filters.push("status=" + filterStatus);
    }
    return filters.join(",");
  };

  const fetchCustomers = async () => {
    setLoadingCustomers(true);
    try {
      const filter = buildFilterString();
      const response = await getCustomers(
        page,
        pageSize,
        filter,
        sortField,
        sortDirection,
      ); // Pass sortDirection to the API
      setCustomers(response.data);
      setTotalCount(response.meta.totalCount);
    } finally {
      setLoadingCustomers(false);
    }
  };

  const handleCustomerClick = (customer: Customer) => {
    setCurrentCustomer(customer);
    navigate(`/customers/${customer.id}/salesopportunities`);
  };

  const handlePageChange = (
    event: React.ChangeEvent<unknown>,
    value: number,
  ) => {
    setPage(value);
  };

  const handleSortChange = (field: string) => {
    if (field === sortField) {
      setSortDirection((prev) => (prev === "asc" ? "desc" : "asc"));
    } else {
      setSortField(field);
      setSortDirection("asc");
      setPage(1);
      setTotalCount(0);
    }
  };
  return (
    <Container maxWidth="lg">
      <Box mt={10}>
        <Box mb={2}>
          <Grid container spacing={2}>
            <Grid item xs={12} sm={4}>
              <TextField
                label="Filter by Name"
                variant="outlined"
                value={filterName}
                onChange={(e) => setFilterName(e.target.value)}
                fullWidth
                aria-label="Filter by name"
              />
            </Grid>
            <Grid item xs={12} sm={4}>
              <FormControl variant="outlined" fullWidth>
                <InputLabel>Filter by Status</InputLabel>
                <Select
                  value={filterStatus}
                  onChange={(e) => setFilterStatus(e.target.value)}
                  label="Filter by Status"
                  aria-label="Filter by Status"
                >
                  <MenuItem value="">
                    <em>All</em>
                  </MenuItem>
                  <MenuItem value="Active" aria-label="Filter by Status Active">
                    Active
                  </MenuItem>
                  <MenuItem
                    value="Non-Active"
                    aria-label="Filter by Status Non-Active"
                  >
                    Non Active
                  </MenuItem>
                  <MenuItem value="Lead" aria-label="Filter by Status Lead">
                    Lead
                  </MenuItem>
                </Select>
              </FormControl>
            </Grid>
            <Grid item xs={12} sm={4}>
              <FormControl variant="outlined" fullWidth>
                <InputLabel>Sort By</InputLabel>
                <Select
                  value={sortField}
                  onChange={(e) => handleSortChange(e.target.value)}
                  label="Sort By"
                  aria-label="Sort By"
                >
                  <MenuItem value="">
                    <em>None</em>
                  </MenuItem>
                  <MenuItem value="name" aria-label="Sort By Name">Name</MenuItem>
                  <MenuItem value="status"aria-label="Sort By Status">Status</MenuItem>
                </Select>
              </FormControl>
            </Grid>
          </Grid>
        </Box>
        {sortField && (
          <Box mb={2} display="flex" alignItems="center">
            <Typography variant="subtitle1" color="textSecondary" gutterBottom>
              Sorting by: (case-sensitive) {sortField} (
              {sortDirection === "asc" ? "Ascending" : "Descending"})
            </Typography>
            <IconButton
              onClick={() =>
                setSortDirection((prev) => (prev === "asc" ? "desc" : "asc"))
              }
              aria-label="Sort Direction Toggle Button"
            >
              {sortDirection === "asc" ? (
                <ArrowUpwardIcon />
              ) : (
                <ArrowDownwardIcon />
              )}
            </IconButton>
          </Box>
        )}

        {loadingCustomers ? (
          <CircularProgress />
        ) : (
          <Grid container spacing={2}>
            {customers.map((customer: Customer) => (
              <Grid item xs={12} sm={6} md={4} key={customer.id}>
                <CustomerCard
                  customer={customer}
                  cardActions={
                    <CardActions style={{ marginTop: "auto" }}>
                      <Tooltip
                        title={`View Opportunities of customer = ${customer.name}`}
                      >
                        <Button
                          size="small"
                          color="primary"
                          onClick={() => handleCustomerClick(customer)}
                          aria-label={`View Opportunities of customer = ${customer.name}`}
                        >
                          View Opportunities
                        </Button>
                      </Tooltip>
                    </CardActions>
                  }
                />
              </Grid>
            ))}
          </Grid>
        )}

        <Pagination
          count={Math.ceil(totalCount / pageSize)}
          page={page}
          onChange={handlePageChange}
          variant="outlined"
          shape="rounded"
          color="primary"
          style={{ marginTop: "20px" }}
          renderItem={(item) => (
            <PaginationItem {...item} aria-label={`Go to page ${item.page}`} />
          )}
        />
      </Box>
    </Container>
  );
};

export default CustomerPage;
