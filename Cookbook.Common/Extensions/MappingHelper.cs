namespace Cookbook.Common.Extensions
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using AutoMapper;

    /// <summary>
    ///     The extensions methods for mapping.
    /// </summary>
    public static class MappingHelper
    {
        /// <summary>
        ///     For member mapping.
        /// </summary>
        /// <param name="expression">
        ///     The mapping expression.
        /// </param>
        /// <param name="destinationMember">
        ///     The destination member.
        /// </param>
        /// <param name="sourceMember">
        ///     The source member.
        /// </param>
        /// <typeparam name="TSource">
        /// </typeparam>
        /// <typeparam name="TDestination">
        /// </typeparam>
        /// <typeparam name="TMappingMember">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IMappingExpression"/>.
        /// </returns>
        public static IMappingExpression<TSource, TDestination> ForMember<TSource, TDestination, TMappingMember>(
            this IMappingExpression<TSource, TDestination> expression,
            Expression<Func<TDestination, TMappingMember>> destinationMember,
            Expression<Func<TSource, TMappingMember>> sourceMember)
        {
            return expression
                .ForMember(destinationMember, opt => opt.MapFrom(sourceMember));
        }

        /// <summary>
        ///     For path mapping.
        /// </summary>
        /// <param name="expression">
        ///     The mapping expression.
        /// </param>
        /// <param name="destinationMember">
        ///     The destination member.
        /// </param>
        /// <param name="sourceMember">
        ///     The source member.
        /// </param>
        /// <typeparam name="TSource">
        /// </typeparam>
        /// <typeparam name="TDestination">
        /// </typeparam>
        /// <typeparam name="TMappingMember">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IMappingExpression"/>.
        /// </returns>
        public static IMappingExpression<TSource, TDestination> ForPath<TSource, TDestination, TMappingMember>(
            this IMappingExpression<TSource, TDestination> expression,
            Expression<Func<TDestination, TMappingMember>> destinationMember,
            Expression<Func<TSource, TMappingMember>> sourceMember)
        {
            return expression
                .ForPath(destinationMember, opt => opt.MapFrom(sourceMember));
        }

        /// <summary>
        ///     Ignore member.
        /// </summary>
        /// <param name="expression">
        ///     The expression.
        /// </param>
        /// <param name="memberExpression">
        ///     The member expression.
        /// </param>
        /// <typeparam name="TSource">
        /// </typeparam>
        /// <typeparam name="TDestination">
        /// </typeparam>
        /// <typeparam name="TMappingMember">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IMappingExpression"/>.
        /// </returns>
        public static IMappingExpression<TSource, TDestination> IgnoreMember<TSource, TDestination, TMappingMember>(
            this IMappingExpression<TSource, TDestination> expression,
            Expression<Func<TDestination, TMappingMember>> memberExpression)
        {
            return expression.ForMember(memberExpression, opt => opt.Ignore());
        }

        /// <summary>
        ///     Ignore members.
        /// </summary>
        /// <param name="expression">
        ///     The expression.
        /// </param>
        /// <param name="memberExpressions">
        ///     The member expressions.
        /// </param>
        /// <typeparam name="TSource">
        /// </typeparam>
        /// <typeparam name="TDestination">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IMappingExpression"/>.
        /// </returns>
        public static IMappingExpression<TSource, TDestination> IgnoreMembers<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> expression,
            params Expression<Func<TDestination, object>>[] memberExpressions)
        {
            return memberExpressions.Aggregate(
                expression,
                (mappingExpression, member) => mappingExpression.IgnoreMember(member));
        }
    }
}