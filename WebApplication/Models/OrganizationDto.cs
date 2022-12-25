﻿using AutoMapper;
using System;
using Application.Common.Mappings;
using Domain;

namespace WebApplication.Models
{
    public class OrganizationDto : IMapWith<Organization>
    {
        public int id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrganizationDto, Organization>()
                .ForMember(command => command.id,
                    opt => opt.MapFrom(Dto => Dto.id));
        }
    }
}
