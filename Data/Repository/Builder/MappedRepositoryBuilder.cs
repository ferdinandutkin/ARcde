using Auto.Interfaces;
using AutoMapper;

namespace Data.Repository.Builder;

public class MappedRepositoryBuilder<TFrom, TTo> : IRepositoryBuilder<TTo>
{
    private readonly IBuilder<IRepository<TFrom>> _decorated;
    private readonly IMapper _mapper;

    public MappedRepositoryBuilder(IRepositoryBuilder<TFrom> decorated, IMapper mapper)
    {
        _decorated = decorated;
        _mapper = mapper;
    }

    public IRepository<TTo> Build()
    {
        return new RepositoryMapper<TFrom, TTo>(_decorated.Build(), _mapper);
    }
}