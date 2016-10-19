﻿using LanguageExt;
using System.Diagnostics.Contracts;
using static LanguageExt.TypeClass;
using static LanguageExt.Prelude;
using LanguageExt.TypeClasses;

public static class NewTypeSemiOrdExtensions
{
    /// <summary>
    /// Add the bound values of x and y, uses an Add type-class to provide the add
    /// operation for type A.  For example x.Add<Metres, TInt, int>(y)
    /// </summary>
    /// <typeparam name="ADD">Add of A</typeparam>
    /// <typeparam name="A">Bound value type</typeparam>
    /// <param name="x">Left hand side of the operation</param>
    /// <param name="y">Right hand side of the operation</param>
    /// <returns>An NewType with y added to x</returns>
    [Pure]
    public static NEWTYPE Add<NEWTYPE, SEMI, ORD, ADD, A>(this NewType<NEWTYPE, SEMI, ORD, A> lhs, NewType<NEWTYPE, SEMI, ORD, A> rhs)
        where SEMI : struct, Semigroup<A>
        where ORD : struct, Ord<A>
        where ADD     : struct, Addition<A>
        where NEWTYPE : NewType<NEWTYPE, SEMI, ORD, A> =>
        from x in lhs
        from y in rhs
        select add<ADD, A>(x, y);

    /// <summary>
    /// Find the difference between the two bound values of x and y, uses a Difference type-class 
    /// to provide the difference operation for type A.  For example x.Difference<TInteger,int>(y)
    /// </summary>
    /// <typeparam name="DIFF">Difference of A</typeparam>
    /// <typeparam name="A">Bound value type</typeparam>
    /// <param name="x">Left hand side of the operation</param>
    /// <param name="y">Right hand side of the operation</param>
    /// <returns>An NewType with the difference between x and y</returns>
    [Pure]
    public static NEWTYPE Difference<NEWTYPE, SEMI, ORD, DIFF, A>(this NewType<NEWTYPE, SEMI, ORD, A> x, NewType<NEWTYPE, SEMI, ORD, A> y)
        where SEMI : struct, Semigroup<A>
        where ORD : struct, Ord<A>
        where DIFF : struct, Difference<A>
        where NEWTYPE : NewType<NEWTYPE, SEMI, ORD, A> =>
        from a in x
        from b in y
        select difference<DIFF, A>(a, b);

    /// <summary>
    /// Find the product between the two bound values of x and y, uses a Product type-class 
    /// to provide the product operation for type A.  For example x.Product<TInteger,int>(y)
    /// </summary>
    /// <typeparam name="PROD">Product of A</typeparam>
    /// <typeparam name="A">Bound value type</typeparam>
    /// <param name="x">Left hand side of the operation</param>
    /// <param name="y">Right hand side of the operation</param>
    /// <returns>Product of x and y</returns>
    [Pure]
    public static NEWTYPE Product<NEWTYPE, SEMI, ORD, PROD, A>(this NewType<NEWTYPE, SEMI, ORD, A> x, NewType<NEWTYPE, SEMI, ORD, A> y)
        where SEMI : struct, Semigroup<A>
        where ORD : struct, Ord<A>
        where PROD : struct, Product<A>
        where NEWTYPE : NewType<NEWTYPE, SEMI, ORD, A> =>
        from a in x
        from b in y
        select product<PROD, A>(a, b);

    /// <summary>
    /// Divide the two bound values of x and y, uses a Divide type-class to provide the divide
    /// operation for type A.  For example x.Divide<TDouble,double>(y)
    /// </summary>
    /// <typeparam name="DIV">Divide of A</typeparam>
    /// <typeparam name="A">Bound value type</typeparam>
    /// <param name="x">Left hand side of the operation</param>
    /// <param name="y">Right hand side of the operation</param>
    /// <returns>x / y</returns>
    [Pure]
    public static NEWTYPE Divide<NEWTYPE, SEMI, ORD, DIV, A>(this NewType<NEWTYPE, SEMI, ORD, A> x, NewType<NEWTYPE, SEMI, ORD, A> y)
        where SEMI : struct, Semigroup<A>
        where ORD : struct, Ord<A>
        where DIV     : struct, Divisible<A>
        where NEWTYPE : NewType<NEWTYPE, SEMI, ORD, A> =>
        from a in x
        from b in y
        select divide<DIV, A>(a, b);

    public static A Sum<NEWTYPE, SEMI, ORD, NUM, A>(this NewType<NEWTYPE, SEMI, ORD, A> self)
        where SEMI : struct, Semigroup<A>
        where ORD : struct, Ord<A>
        where NEWTYPE : NewType<NEWTYPE, SEMI, ORD, A>
        where NUM : Num<A> =>
        self.Value;
}
