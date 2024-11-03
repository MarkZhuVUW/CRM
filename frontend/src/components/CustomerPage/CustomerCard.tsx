import { Card, CardActions, CardContent, Typography } from "@mui/material";
import { Customer } from "../GlobalProviders/CustomerProvider";

type CustomerCardProps = {
  cardActions?: JSX.Element;
  customer: Customer;
};
const CustomerCard = (props: CustomerCardProps) => {
  const { customer, cardActions } = props;
  return (
    <Card
      style={{
        height: "100%",
        display: "flex",
        flexDirection: "column",
      }}
    >
      <CardContent>
        <Typography variant="h6" gutterBottom>
          {customer.name}
        </Typography>
        <Typography variant="body2">Id: {customer.id}</Typography>
        <Typography variant="body2">Email: {customer.email}</Typography>
        <Typography variant="body2">Phone: {customer.phoneNumber}</Typography>
        <Typography variant="body2">Status: {customer.status}</Typography>
        <Typography variant="body2">
          Created At: {new Date(customer.createdAt!).toISOString()}
        </Typography>
        <Typography variant="body2">
          Updated At: {new Date(customer.updatedAt!).toISOString()}
        </Typography>
      </CardContent>
      <CardActions>{cardActions}</CardActions>
    </Card>
  );
};
export default CustomerCard;
