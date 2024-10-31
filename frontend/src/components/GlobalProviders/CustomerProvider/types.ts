import {
  BasePutRequest,
  BasePutResponse,
  BaseGetRequest,
  BaseGetResponse,
} from "../ErrorProvider";

// Enums for Customer Status and Sales Opportunity Status
export enum CustomerStatus {
  Active = "Active",
  NonActive = "Non Active",
  Lead = "Lead",
}

export enum SalesOpportunityStatus {
  New = "New",
  ClosedWon = "Closed Won",
  ClosedLost = "Closed Lost",
}

// Customer Interface
export interface Customer {
  id: string;
  name: string;
  email: string;
  phoneNumber: string;
  status: CustomerStatus; 
  createdAt: Date;
  updatedAt: Date;
}

// SalesOpportunity Interface
export interface SalesOpportunity {
  id: string;
  customerId: string;
  name: string;
  status: SalesOpportunityStatus;
  createdAt: Date;
  updatedAt: Date;
}

// Pagination Response
export interface PaginatedResponse<T> {
  data: T[];
  totalCount: number;
}

export interface CustomerFilter {
  status?: CustomerStatus; 
}

export interface GetCustomersRequest extends BaseGetRequest {
  pageNumber?: number;
  pageSize?: number;
  filter?: CustomerFilter; 
  sort?: string;
}

export interface GetCustomersResponse extends BaseGetResponse {
  data: PaginatedResponse<Customer>;
}

export interface GetSalesOpportunitiesRequest extends BaseGetRequest {}

export interface GetSalesOpportunitiesResponse extends BaseGetResponse {
  data: PaginatedResponse<SalesOpportunity>;
}

export interface CustomerPutRequest extends BasePutRequest {
  data: Customer;
}

export interface CustomerPutResponse extends BasePutResponse {
  data: {
    success: boolean;
  };
}

export interface SalesOpportunityPutRequest extends BasePutRequest {
  data: SalesOpportunity;
}

export interface SalesOpportunityPutResponse extends BasePutResponse {
  data: {
    success: boolean;
  };
}
