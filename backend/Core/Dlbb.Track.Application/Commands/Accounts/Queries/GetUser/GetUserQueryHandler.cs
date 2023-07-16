﻿using System.Security.Claims;
using AutoMapper;
using Dlbb.Track.Application.Exceptions;
using Dlbb.Track.Common.Exceptions.Extensions;
using Dlbb.Track.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dlbb.Track.Application.Accounts.Queries.GetUser;
public class GetUserQueryHandler : IRequestHandler<GetUserQuery, AppUserVM>
{
	private readonly AppDbContext _dbContext;
	private readonly IMapper _mapper;

	public GetUserQueryHandler(AppDbContext dbContext, IMapper mapper)
	{
		_dbContext = dbContext;
		_mapper = mapper;
	}


	public async Task<AppUserVM> Handle
		(GetUserQuery request,
		CancellationToken cancellationToken)
	{
		var id = request.Claims.First(c => ClaimTypes.IsPersistent == c.Type).Value;

		(id is null || id == String.Empty).ThrowUserFriendlyExceptionIfTrue
			(Status.Validation, "request isn't correct");

		var userDb = await _dbContext.AppUsers.SingleOrDefaultAsync
			(u => u.Id == Guid.Parse(id!), cancellationToken);

		userDb!.ThrowUserFriendlyExceptionIfNull
			(Status.NotFound, $"Not Found \"AppUserId\" : {id}");

		var result = _mapper.Map<AppUserVM>(userDb);

		return result;
	}
}
