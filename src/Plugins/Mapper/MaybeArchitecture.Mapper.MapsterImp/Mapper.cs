using Mapster;

namespace MaybeArchitecture.Mapper.MapsterImp
{
    public class Mapper : IMapper
    {
        public TDestination Map<TDestination>(object source)
        {
            TypeAdapterConfig typeAdapterConfig = TypeAdapterConfig<object, TDestination>.NewConfig().PreserveReference(true).Config;

            return source.Adapt<TDestination>(typeAdapterConfig);
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            TypeAdapterConfig typeAdapterConfig = TypeAdapterConfig<TSource, TDestination>.NewConfig().PreserveReference(true).Config;

            return source.Adapt<TDestination>(typeAdapterConfig);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return source.Adapt(destination);
        }
    }
}
