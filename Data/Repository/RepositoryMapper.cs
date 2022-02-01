using Auto.Interfaces;
using AutoMapper;

namespace Data.Repository
{
    internal class RepositoryMapper<TFrom, TTo> : IRepository<TTo>
    {

        private readonly IRepository<TFrom> _source;

        private readonly IMapper _mapper;
        public RepositoryMapper(IRepository<TFrom> source, IMapper mapper)
        {
            _mapper = mapper;
            _source = source;
        }
        public TTo Add(TTo value)
        {
            var mapped = _mapper.Map<TFrom>(value);
            var added = _source.Add(mapped);
            return _mapper.Map<TTo>(added);
        }

        public IEnumerable<TTo> All()
        {
            var all = _source.All().ToArray();
            return _mapper.Map<TTo[]>(all);
        }

        public void Remove(TTo value)
        {
            var mapped = _mapper.Map<TFrom>(value);
            _source.Remove(mapped);
        }

        public TTo Update(TTo value)
        {
            var mapped = _mapper.Map<TFrom>(value);
            var updated = _source.Update(mapped);
            return _mapper.Map<TTo>(updated);
        }
    }
}
