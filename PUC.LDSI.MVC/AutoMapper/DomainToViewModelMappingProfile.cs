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

            CreateMap<Publicacao, ProvaPublicadaViewModel>()
                .ForMember(x => x.Disciplina, opt => opt.MapFrom(x => x.Avaliacao.Disciplina))
                .ForMember(x => x.Descricao, opt => opt.MapFrom(x => x.Avaliacao.Descricao))
                .ForMember(x => x.Materia, opt => opt.MapFrom(x => x.Avaliacao.Materia))
                .ForMember(x => x.Status, opt => opt.MapFrom(x => x.Avaliacao))
                .ReverseMap();
        }
    }
}
