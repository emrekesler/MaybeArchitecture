namespace MaybeArchitecture.Mapper.AutoMapperImp
{
    public class Mapper : IMapper
    {
        private readonly AutoMapper.IMapper _mapper;
        public Mapper(AutoMapper.IMapper mapper)
        {
            _mapper = mapper;
        }
        public TDestination Map<TDestination>(object source)
        {
            return _mapper.Map<TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return _mapper.Map(source, destination);
        }
    }
}
