﻿namespace BubaEats.Application;

public record class AuthenticationResult(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string Token);