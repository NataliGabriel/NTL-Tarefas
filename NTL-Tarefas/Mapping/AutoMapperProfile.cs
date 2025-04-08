using AutoMapper;
using NTL_Tarefas.Models;
using NTL_Tarefas.DTOs;

namespace NTL_Tarefas.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Tarefa, TarefaResponseDTO>();
            CreateMap<TarefaCriarDTO, Tarefa>();
            CreateMap<TarefaAtualizarDTO, Tarefa>();
        }
    }
}
