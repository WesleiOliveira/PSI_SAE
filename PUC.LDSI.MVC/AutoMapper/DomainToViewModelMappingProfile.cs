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

            CreateMap<Avaliacao, AvaliacaoViewModel>()
                .ForMember(destino => destino.Professor, opt => opt.MapFrom(avaliacao => avaliacao.Professor.Nome))
                .ReverseMap();

            CreateMap<QuestaoAvaliacao, QuestaoAvaliacaoViewModel>().ReverseMap();
            CreateMap<Publicacao, PublicacaoViewModel>().ReverseMap();
            CreateMap<OpcaoAvaliacao, OpcaoAvaliacaoViewModel>().ReverseMap();
        }
    }
}
