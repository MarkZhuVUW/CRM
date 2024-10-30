import {
  BasePutRequest,
  BasePutResponse,
  BaseGetRequest,
  BaseGetResponse,
} from "../ErrorProvider";

// Customer Interface
export interface Customer {
  id: string;
  name: string;
  email: string;
  phoneNumber: string;
  status: string; // "Active", "Non-Active", "Lead"
  createdAt: Date;
  updatedAt: Date;
}

// SalesOpportunity Interface
export interface SalesOpportunity {
  id: string;
  customerId: string;
  name: string;
  status: string; // "New", "Closed Won", "Closed Lost"
  createdAt: Date;
  updatedAt: Date;
}

// Pagination Response
export interface PaginatedResponse<T> {
  data: T[];
  totalCount: number;
}

// Get Customers Request and Response
export interface GetCustomersRequest extends BaseGetRequest {
  pageNumber?: number;
  pageSize?: number;
  filter?: string;
  sort?: string;
}

export interface GetCustomersResponse extends BaseGetResponse {
  data: PaginatedResponse<Customer>;
}

// Get Sales Opportunities Request and Response
export interface GetSalesOpportunitiesRequest extends BaseGetRequest {}

export interface GetSalesOpportunitiesResponse extends BaseGetResponse {
  data: PaginatedResponse<SalesOpportunity>;
}

// Put Customer Request and Response
export interface CustomerPutRequest extends BasePutRequest {
  data: Customer;
}

export interface CustomerPutResponse extends BasePutResponse {
  data: {
    success: boolean;
  };
}

// Put Sales Opportunity Request and Response
export interface SalesOpportunityPutRequest extends BasePutRequest {
  data: SalesOpportunity;
}

export interface SalesOpportunityPutResponse extends BasePutResponse {
  data: {
    success: boolean;
  };
}
