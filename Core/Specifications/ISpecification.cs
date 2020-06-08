using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
         // Expression<Func<T, bool>>  
         // Expression  -   Generic expression
         // Func        -   Function
         // T           -   This means the function takes a Type, 
         // bool        -   This is the return type
         Expression<Func<T, bool>> Criteria { get; }        // Criteria is the WHERE e.g. where product id = 1
         List<Expression<Func<T, object>>> Includes { get; }
         Expression<Func<T, object>> OrderBy { get; }
         Expression<Func<T, object>> OrderByDescending { get; }

         int Take { get; }
         int Skip { get; }
         bool IsPagingEnabled { get; }
    }
}