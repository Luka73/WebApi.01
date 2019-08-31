using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Projeto.DAL.Entities;
using Projeto.Services.Models;

namespace Projeto.Services.App_Start
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ClienteCadastroModel, Cliente>();
        }
    }
}