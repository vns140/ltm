using AutoMapper;
using System;

namespace LTM.Application.Mapper
{
    public class AutoMapperAdapter : IAutoMapperAdapter
    {
        private readonly IMapper _mapper;

        public AutoMapperAdapter(IMapper mapper)
        {
            _mapper = mapper;



        }

        public TTarget Adapt<TSource, TTarget>(TSource source)
        {
            return _mapper.Map<TTarget>(source);
        }

        public TTarget Adapt<TSource, TTarget>(TSource source, TTarget destination)
        {
            return _mapper.Map(source, destination);
        }

        public TTarget Adapt<TSource, TTarget>(TSource source, Action<IMappingOperationOptions<TSource, TTarget>> opts)
        {
            return _mapper.Map(source, opts);
        }
    }
}
