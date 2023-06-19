﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dlbb.Track.Application.Accounts.Queries.GetUser;
using Dlbb.Track.Application.Activities.Queries.GetActivity;
using Dlbb.Track.Application.Sessions.Queries.GetSession;
using Dlbb.Track.Domain.Entities;

namespace Dlbb.Track.Application.Common.Mappings;
public class ApplicationMappingProfile:Profile
{
	public ApplicationMappingProfile()
	{
		ApplyMappings();
	}

	private void ApplyMappings()
	{
		CreateMap<Activity, ActivityVm>()
			.ForMember(aVm => aVm.Name,
				opt => opt.MapFrom(a => a.Name))
			.ForMember(aVm => aVm.Id,
				opt => opt.MapFrom(a => a.Id))
			.ForMember(aVm => aVm.Description,
				opt => opt.MapFrom(a => a.Description));

		CreateMap<Session,SessionVm>()
			.ForMember(sVm=> sVm.Id,
				opt=> opt.MapFrom(s=>s.Id))
			.ForMember(sVm=> sVm.StartTime,
				opt=> opt.MapFrom(s=>s.StartTime))
			.ForMember(sVm=>sVm.Duration,
				opt=> opt.MapFrom(s=>s.Duration))
			.ForMember(sVm=>sVm.ActivityId,
				opt=> opt.MapFrom(s=>s.ActivityId));

		CreateMap<AppUser, AppUserVM>()
			.ForMember(vm => vm.Id, opt => opt.MapFrom(s => s.Id))
			.ForMember(vm => vm.Email, opt => opt.MapFrom(s => s.Email))
			.ForMember(vm => vm.UserName, opt => opt.MapFrom(s => s.UserName))
			.ForMember(vm => vm.Role, opt => opt.MapFrom(s => s.Role));
	}
}
