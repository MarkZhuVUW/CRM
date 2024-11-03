import { Card, CardActions, CardContent, Typography } from "@mui/material";
import {
  Customer,
  SalesOpportunity,
} from "../GlobalProviders/CustomerProvider";

type SalesOpportunityCardProps = {
  cardActions?: JSX.Element;
  salesOpportunity: SalesOpportunity;
};
const SalesOpportunityCard = (props: SalesOpportunityCardProps) => {
  const { salesOpportunity, cardActions } = props;
  return (
    <Card
      style={{
        height: "100%",
        display: "flex",
        flexDirection: "column",
      }}
    >
      <CardContent>
        <Typography variant="h6">{salesOpportunity.name}</Typography>
        <Typography variant="body2">Status: {salesOpportunity.id}</Typography>
        <Typography variant="body2">
          Status: {salesOpportunity.status}
        </Typography>
        <Typography variant="body2">
          Customer Id: {salesOpportunity.customerId}
        </Typography>
        <Typography variant="body2">
          Created At:
          {salesOpportunity.createdAt &&
            new Date(salesOpportunity.createdAt).toISOString()}
        </Typography>
        <Typography variant="body2">
          Updated At:
          {salesOpportunity.updatedAt &&
            new Date(salesOpportunity.updatedAt).toISOString()}
        </Typography>
      </CardContent>
      <CardActions>{props.cardActions}</CardActions>
    </Card>
  );
};
export default SalesOpportunityCard;
