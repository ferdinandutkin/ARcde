using AutoMapper;

namespace Data.Repository.Builder;

public static class RepositoryBuilderExtensions
{
    public static IRepositoryBuilder<TTo> WithMapper<TFrom, TTo>(this IRepositoryBuilder<TFrom> repositoryBuilder,
        IMapper mapper) => new MappedRepositoryBuilder<TFrom, TTo>(repositoryBuilder, mapper);
}