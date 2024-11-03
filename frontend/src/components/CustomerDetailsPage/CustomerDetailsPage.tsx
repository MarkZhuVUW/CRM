import React, { useEffect, useState } from "react";
import {
  Button,
  Card,
  CardActions,
  CardContent,
  Container,
  Typography,
  CircularProgress,
  Grid,
  TextField,
  FormControl,
  InputLabel,
  Select,
  MenuItem,
  Box,
  Divider,
  Tooltip,
} from "@mui/material";
import {
  CustomerStatus,
  SalesOpportunity,
  SalesOpportunityStatus,
  useCustomer,
} from "../GlobalProviders/CustomerProvider";
import { useRoute } from "../GlobalProviders";
import AddIcon from "@mui/icons-material/Add";
import { CustomerCard } from "../CustomerPage";
import SalesOpportunityCard from "./SalesOpportunityCard";

const CustomerDetailsPage: React.FC = () => {
  const { setPageTitle } = useRoute();
  const {
    currentCustomer,
    getSalesOpportunities,
    updateSalesOpportunity,
    createSalesOpportunity,
    patchCustomer,
    getCustomerById,
    setCurrentCustomer,
  } = useCustomer();
  const [salesOpportunities, setSalesOpportunities] = useState<
    SalesOpportunity[]
  >([]);
  const [isCreating, setIsCreating] = useState<boolean>(false);
  const [editingOpportunity, setEditingOpportunity] =
    useState<SalesOpportunity | null>(null);
  const [name, setName] = useState("");
  const [isEditingSalesOpportunity, setIsEditingSalesOpportunity] =
    useState<boolean>(false);

  const [salesOpportunityStatus, setSalesOpportunityStatus] =
    useState<SalesOpportunityStatus>(SalesOpportunityStatus.New);
  const [loading, setLoading] = useState<boolean>(true);

  const [isEditingCustomer, setIsEditingCustomer] = useState(false);
  const [customerStatus, setCustomerStatus] = useState(CustomerStatus.Active);
  useEffect(() => {
    setPageTitle("Sales Opportunities");
    if (currentCustomer) {
      fetchSalesOpportunities(currentCustomer.id!);
    }
  }, [currentCustomer]);

  const fetchSalesOpportunities = async (customerId: string) => {
    setLoading(true);
    try {
      const response = await getSalesOpportunities(customerId);
      setSalesOpportunities(response.data);
    } finally {
      setLoading(false);
    }
  };

  const handleEditCustomerClick = () => {
    setCustomerStatus(currentCustomer!.status!);
    setIsEditingCustomer(true);
  };

  const handleCustomerUpdateSubmit = async () => {
    if (currentCustomer) {
      const updatedCustomerData = {
        status: customerStatus,
      };
      try {
        await patchCustomer(currentCustomer.id!, updatedCustomerData);

        setCurrentCustomer((await getCustomerById(currentCustomer.id!)).data);
      } finally {
        setIsEditingCustomer(false);
      }
    }
  };
  const handleSalesOpportunityEditButtonClick = (
    opportunity: SalesOpportunity,
  ) => {
    setEditingOpportunity(opportunity);
    setName(opportunity.name!);
    setSalesOpportunityStatus(opportunity.status!);
    setIsEditingSalesOpportunity(true);
    setIsCreating(false);
  };

  const handleCancel = () => {
    setEditingOpportunity(null);
    setIsEditingSalesOpportunity(false);
    setIsCreating(false);
    setIsEditingCustomer(false);
  };

  const handleCreateButtonClick = () => {
    setEditingOpportunity(null);
    setName("");
    setSalesOpportunityStatus(SalesOpportunityStatus.New);
    setIsEditingSalesOpportunity(false);
    setIsCreating(true);
  };

  const handleSalesOpportunitySubmit = async () => {
    if (currentCustomer) {
      try {
        if (editingOpportunity) {
          const updatedData: SalesOpportunity = {
            ...editingOpportunity,
            name,
            status: salesOpportunityStatus,
          };

          await updateSalesOpportunity(
            currentCustomer.id!,
            editingOpportunity.id!,
            updatedData,
          );
        }
        if (isCreating) {
          const newSalesOpportunity: SalesOpportunity = {
            name,
            status: salesOpportunityStatus,
            customerId: currentCustomer.id,
          };
          await createSalesOpportunity(
            currentCustomer.id!,
            newSalesOpportunity,
          );
        }
        fetchSalesOpportunities(currentCustomer.id!);
      } finally {
        handleCancel();
      }
    }
  };

  return (
    <Container maxWidth="lg">
      <Box mt={10}>
        {currentCustomer && (
          <Typography variant="h4" gutterBottom>
            {currentCustomer.name}
          </Typography>
        )}
        {currentCustomer && !isEditingCustomer && (
          <Grid container spacing={2}>
            <Grid item xs={12} sm={6} md={4}>
              <CustomerCard
                customer={currentCustomer}
                cardActions={
                  <Tooltip title="Edit Customer">
                    <Button
                      size="large"
                      color="primary"
                      onClick={handleEditCustomerClick}
                      aria-label="Edit Customer"
                    >
                      Edit
                    </Button>
                  </Tooltip>
                }
              />
            </Grid>
          </Grid>
        )}

        {isEditingCustomer && (
          <Card>
            <CardContent>
              <Typography variant="h6" marginBottom="10px">
                Edit Customer
              </Typography>
              <FormControl fullWidth>
                <InputLabel>Status</InputLabel>
                <Select
                  value={customerStatus}
                  onChange={(e) =>
                    setCustomerStatus(e.target.value as CustomerStatus)
                  }
                >
                  <MenuItem value="Active">Active</MenuItem>
                  <MenuItem value="Non-Active">Non-Active</MenuItem>
                  <MenuItem value="Lead">Lead</MenuItem>
                </Select>
              </FormControl>
            </CardContent>
            <CardActions>
              <Tooltip title="Submit customer update">
                <Button
                  variant="contained"
                  color="primary"
                  onClick={handleCustomerUpdateSubmit}
                  aria-label="Submit customer update"
                >
                  Update
                </Button>
              </Tooltip>

              <Tooltip title="Cancel customer update">
                <Button
                  variant="outlined"
                  onClick={handleCancel}
                  aria-label="Cancel customer update"
                >
                  Cancel
                </Button>
              </Tooltip>
            </CardActions>
          </Card>
        )}

        <Divider style={{ marginBottom: "20px", marginTop: "30px" }} />

        {currentCustomer && (
          <Box display="flex" alignItems="center">
            <Typography variant="h4" gutterBottom>
              {currentCustomer.name}'s Sales Opportunities
            </Typography>
            <Tooltip title="Create Sales Opportunity">
              <Button
                style={{ marginLeft: "20px", marginBottom: "10px" }}
                variant="contained"
                aria-label="Create Sales Opportunity"
                onClick={handleCreateButtonClick}
              >
                <AddIcon />
              </Button>
            </Tooltip>
          </Box>
        )}

        {loading ? (
          <CircularProgress />
        ) : (
          <>
            {isEditingSalesOpportunity || isCreating ? (
              <Grid container spacing={2}>
                <Grid item xs={12} sm={6} md={4}>
                  <Card
                    style={{
                      height: "100%",
                      display: "flex",
                      flexDirection: "column",
                    }}
                  >
                    <CardContent>
                      <Typography variant="h6" marginBottom="10px">
                        Edit Sales Opportunity
                      </Typography>
                      <Box mb={2}>
                        <TextField
                          label="Name"
                          variant="outlined"
                          fullWidth
                          value={name}
                          onChange={(e) => setName(e.target.value)}
                        />
                      </Box>
                      <Box mb={2}>
                        <FormControl variant="outlined" fullWidth>
                          <InputLabel>Status</InputLabel>
                          <Select
                            value={salesOpportunityStatus}
                            onChange={(e) =>
                              setSalesOpportunityStatus(
                                e.target.value as SalesOpportunityStatus,
                              )
                            }
                            label="Status"
                          >
                            <MenuItem value={SalesOpportunityStatus.New}>
                              New
                            </MenuItem>
                            <MenuItem value={SalesOpportunityStatus.ClosedWon}>
                              Closed Won
                            </MenuItem>
                            <MenuItem value={SalesOpportunityStatus.ClosedLost}>
                              Closed Lost
                            </MenuItem>
                          </Select>
                        </FormControl>
                      </Box>
                    </CardContent>
                    <CardActions>
                      {isEditingSalesOpportunity && (
                        <Tooltip title="Submit Sales opportunity edit">
                          <Button
                            variant="contained"
                            color="primary"
                            onClick={handleSalesOpportunitySubmit}
                            aria-label="Submit Sales opportunity edit"
                          >
                            Edit
                          </Button>
                        </Tooltip>
                      )}
                      {isCreating && (
                        <Tooltip title="Submit Sales opportunity creation">
                          <Button
                            variant="contained"
                            color="primary"
                            onClick={handleSalesOpportunitySubmit}
                            aria-label="Submit Sales opportunity creation"
                          >
                            Create
                          </Button>
                        </Tooltip>
                      )}
                      <Button variant="outlined" onClick={handleCancel}>
                        Cancel
                      </Button>
                    </CardActions>
                  </Card>
                </Grid>
              </Grid>
            ) : (
              <Grid container spacing={2}>
                {salesOpportunities.map((opportunity) => (
                  <Grid item xs={12} sm={6} md={4} key={opportunity.id}>
                    <SalesOpportunityCard
                      salesOpportunity={opportunity}
                      cardActions={
                        <Tooltip title="Edit Sales Opportunity">
                          <Button
                            size="large"
                            color="primary"
                            onClick={() =>
                              handleSalesOpportunityEditButtonClick(opportunity)
                            }
                            aria-label="Edit Sales Opportunity"
                          >
                            Edit
                          </Button>
                        </Tooltip>
                      }
                    />
                  </Grid>
                ))}
              </Grid>
            )}
          </>
        )}
      </Box>
    </Container>
  );
};

export default CustomerDetailsPage;
