import { render, screen, waitFor } from '@testing-library/react';
import { describe, it, expect, vi, beforeEach, Mock } from 'vitest';
import {
  get,
  handleError,
  patch,
  post,
  put,
} from "@frontend-ui/utils/apiUtils";
import { CustomerProvider, useCustomer } from '@frontend-ui/components/GlobalProviders';

// Mock API methods
vi.mock('@frontend-ui/utils/apiUtils', () => ({
  get: vi.fn(),
  handleError: vi.fn(),
  patch: vi.fn(),
  post: vi.fn(),
  put: vi.fn(),
}));

const TestComponent = () => {
  const {
    getCustomers,
    getCustomerById,
    patchCustomer,
    getSalesOpportunities,
    updateSalesOpportunity,
    createSalesOpportunity,
  } = useCustomer();

  return (
    <div>
      <button onClick={() => getCustomers(1, 5)}>Get Customers</button>
      <button onClick={() => getCustomerById('1')}>Get Customer by ID</button>
      <button onClick={() => patchCustomer('1', { name: 'Test Customer' })}>Patch Customer</button>
      <button onClick={() => getSalesOpportunities('1')}>Get Sales Opportunities</button>
      <button onClick={() => updateSalesOpportunity('1', '1', { name: 'Test Opportunity' })}>Update Sales Opportunity</button>
      <button onClick={() => createSalesOpportunity('1', { name: 'New Opportunity' })}>Create Sales Opportunity</button>
    </div>
  );
};

describe('CustomerProvider', () => {
  beforeEach(() => {
    vi.clearAllMocks();
  });

  it('renders CustomerProvider without crashing', () => {
    render(
      <CustomerProvider>
        <TestComponent />
      </CustomerProvider>
    );
    expect(screen.getByText('Get Customers')).toBeInTheDocument();
  });

  it('calls getCustomers API when getCustomers is invoked', async () => {
    (get as Mock).mockResolvedValueOnce({ data: { items: [] } });
    
    render(
      <CustomerProvider>
        <TestComponent />
      </CustomerProvider>
    );

    screen.getByText('Get Customers').click();

    await waitFor(() => {
      expect(get).toHaveBeenCalledWith({
        url: expect.stringContaining('/api/customers'),
      });
    });
  });

  it('calls getCustomerById API when getCustomerById is invoked', async () => {
    (get as Mock).mockResolvedValueOnce({ data: { id: '1', name: 'Test Customer' } });
    
    render(
      <CustomerProvider>
        <TestComponent />
      </CustomerProvider>
    );

    screen.getByText('Get Customer by ID').click();

    await waitFor(() => {
      expect(get).toHaveBeenCalledWith({
        url: expect.stringContaining('/api/customers/1'),
      });
    });
  });

  it('calls patchCustomer API when patchCustomer is invoked', async () => {
    (patch as Mock).mockResolvedValueOnce({ data: { id: '1', name: 'Updated Customer' } });

    render(
      <CustomerProvider>
        <TestComponent />
      </CustomerProvider>
    );

    screen.getByText('Patch Customer').click();

    await waitFor(() => {
      expect(patch).toHaveBeenCalledWith({
        url: expect.stringContaining('/api/customers/1'),
        data: { name: 'Test Customer' },
      });
    });
  });

  it('calls getSalesOpportunities API when getSalesOpportunities is invoked', async () => {
    (get as Mock).mockResolvedValueOnce({ data: { items: [] } });
    
    render(
      <CustomerProvider>
        <TestComponent />
      </CustomerProvider>
    );

    screen.getByText('Get Sales Opportunities').click();

    await waitFor(() => {
      expect(get).toHaveBeenCalledWith({
        url: expect.stringContaining('/api/customers/1/salesopportunities'),
      });
    });
  });

  it('calls updateSalesOpportunity API when updateSalesOpportunity is invoked', async () => {
    (put as Mock).mockResolvedValueOnce({ data: { id: '1', name: 'Updated Opportunity' } });

    render(
      <CustomerProvider>
        <TestComponent />
      </CustomerProvider>
    );

    screen.getByText('Update Sales Opportunity').click();

    await waitFor(() => {
      expect(put).toHaveBeenCalledWith({
        url: expect.stringContaining('/api/customers/1/salesopportunities/1'),
        data: { name: 'Test Opportunity' },
      });
    });
  });

  it('calls createSalesOpportunity API when createSalesOpportunity is invoked', async () => {
    (post as Mock).mockResolvedValueOnce({ data: { id: '1', name: 'New Opportunity' } });

    render(
      <CustomerProvider>
        <TestComponent />
      </CustomerProvider>
    );

    screen.getByText('Create Sales Opportunity').click();

    await waitFor(() => {
      expect(post).toHaveBeenCalledWith({
        url: expect.stringContaining('/api/customers/1/salesopportunities'),
        data: { name: 'New Opportunity' },
      });
    });
  });
});