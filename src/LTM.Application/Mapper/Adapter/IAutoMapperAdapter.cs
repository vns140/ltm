using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTM.Application.Mapper
{
    public interface IAutoMapperAdapter
    {
        TTarget Adapt<TSource, TTarget>(TSource source);
        TTarget Adapt<TSource, TTarget>(TSource source, Action<IMappingOperationOptions<TSource, TTarget>> opts);
        TTarget Adapt<TSource, TTarget>(TSource source, TTarget destination);
    }
}
