﻿using AutoMapper;
using ConsultaAlumnos.Application.Models;
using ConsultaAlumnos.Domain.Entities;

namespace ConsultaAlumnos.Application.Profiles;

public class SubjectProfile : Profile
{
    public SubjectProfile()
    {
        CreateMap<Subject, SubjectDto>();
    }
}
