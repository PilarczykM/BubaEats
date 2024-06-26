﻿using BubaEats.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace BubaEats.Application.Authentication.Command.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;
