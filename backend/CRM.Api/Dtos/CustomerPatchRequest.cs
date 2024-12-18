﻿namespace CRM.Api.DTOs;

public class CustomerPatchRequest
{
    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Status { get; set; }
}