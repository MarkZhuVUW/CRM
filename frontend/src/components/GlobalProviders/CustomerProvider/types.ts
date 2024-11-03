import {
  BaseGetRequest,
  BaseGetResponse,
  BasePatchRequest,
  BasePatchResponse,
  BasePutRequest,
  BasePutResponse,
} from "../ErrorProvider";

// Enums for Customer Status and Sales Opportunity Status
export enum CustomerStatus {
  Active = "Active",
  NonActive = "Non-Active",
  Lead = "Lead",
}

export enum SalesOpportunityStatus {
  New = "New",
  ClosedWon = "Closed-Won",
  ClosedLost = "Closed-Lost",
}

// Customer Interface
export interface Customer {
  id?: string;
  name?: string;
  email?: string;
  phoneNumber?: string;
  status?: CustomerStatus;
  createdAt?: Date;
  updatedAt?: Date;
}
export interface SalesOpportunity {
  id?: string;
  customerId?: string;
  name?: string;
  status?: SalesOpportunityStatus;
  createdAt?: Date;
  updatedAt?: Date;
}

// Pagination Response
export interface PaginationMeta {
  totalCount: number;
}
export interface CustomerFilter {
  status?: CustomerStatus;
}
export interface GetCustomerByIdRequest extends BaseGetRequest {}

export interface GetCustomerByIdResponse extends BaseGetResponse {
  data: Customer | null;
}
export interface GetCustomersRequest extends BaseGetRequest {
  pageNumber?: number;
  pageSize?: number;
  filter?: CustomerFilter;
  sort?: string;
}

export interface GetCustomersResponse extends BaseGetResponse {
  data: Customer[];
  meta: PaginationMeta;
}

export interface CustomerPatchRequest extends BasePatchRequest {
  data: Customer;
}

export interface CustomerPatchResponse extends BasePatchResponse {
  data: {
    success: boolean;
  };
}

export interface GetSalesOpportunitiesRequest extends BaseGetRequest {}

export interface GetSalesOpportunitiesResponse extends BaseGetResponse {
  data: SalesOpportunity[];
}

export interface SalesOpportunityPostRequest extends BasePutRequest {
  data: SalesOpportunity;
}

export interface SalesOpportunityPostResponse extends BasePutResponse {
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
