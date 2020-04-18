using AutoMapper;
using PUC.LDSI.Domain.Entities;
using PUC.LDSI.MVC.Models;

namespace PUC.LDSI.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Turma, TurmaViewModel>().ReverseMap();
        }
    }
}