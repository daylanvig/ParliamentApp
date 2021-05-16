using AutoMapper;
using System;
using System.Linq.Expressions;

namespace ParliamentApp.MappingProfiles
{
    public static class MappingProfileExtensions
    {

        public static IMappingExpression<TSource, TDestination> Ignore<TSource, TDestination, TMember>(this IMappingExpression<TSource, TDestination> mappingExpression, Expression<Func<TDestination, TMember>> property)
        {
            return mappingExpression
                .ForMember(property, o => o.Ignore());
        }
    }
}
