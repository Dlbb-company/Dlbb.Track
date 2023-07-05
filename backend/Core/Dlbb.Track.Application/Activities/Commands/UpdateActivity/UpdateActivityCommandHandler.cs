﻿using System.Security.Claims;
using Dlbb.Track.Application.Exceptions;
using Dlbb.Track.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dlbb.Track.Application.Activities.Commands.UpdateActivity;
public class UpdateActivityCommandHandler : IRequestHandler<UpdateActivityCommand>
{
	private readonly AppDbContext _context;

	public UpdateActivityCommandHandler(AppDbContext context)
	{
		_context = context;
	}

	public async Task<Unit> Handle(UpdateActivityCommand request, CancellationToken cancellationToken)
	{
		var activity = await _context.Activities.SingleOrDefaultAsync
			(a => a.Id == request.Id, cancellationToken);

		if (activity is null)
		{
			throw new UserFriendlyException
				(Status.NotFound, $"Not found \"Id\" : {request.Id}");
		}

		var id = request.Cliams.First(c => c.Type == ClaimTypes.IsPersistent).Value;
		var owner = await _context.AppUsers.SingleOrDefaultAsync(u => u.Id == Guid.Parse(id));

		activity.Name = request.Name;
		activity.Description = request.Description;
		activity.AppUser = owner;

		await _context.SaveChangesAsync(cancellationToken);

		return Unit.Value;
	}
}