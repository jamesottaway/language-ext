﻿using System;
using LanguageExt.TypeClasses;
using static LanguageExt.Prelude;
using System.Diagnostics.Contracts;

namespace LanguageExt.ClassInstances
{
    public struct FOptionUnsafe<A, B> : 
        Functor<OptionUnsafe<A>, OptionUnsafe<B>, A, B>,
        BiFunctor<OptionUnsafe<A>, OptionUnsafe<B>, Unit, A, B>,
        Applicative<OptionUnsafe<Func<A, B>>, OptionUnsafe<A>, OptionUnsafe<B>, A, B>
    {
        public static readonly FOptionUnsafe<A, B> Inst = default(FOptionUnsafe<A, B>);

        [Pure]
        public OptionUnsafe<B> BiMap(OptionUnsafe<A> ma, Func<Unit, B> fa, Func<A, B> fb) =>
            FOptional<
                MOptionUnsafe<A>, MOptionUnsafe<B>, 
                OptionUnsafe<A>, OptionUnsafe<B>, 
                A, B>
            .Inst.BiMap(ma, fa, fb);

        [Pure]
        public OptionUnsafe<B> Map(OptionUnsafe<A> ma, Func<A, B> f) =>
            FOptional<
                MOptionUnsafe<A>, MOptionUnsafe<B>, 
                OptionUnsafe<A>, OptionUnsafe<B>, 
                A, B>
            .Inst.Map(ma, f);

        [Pure]
        public OptionUnsafe<B> Apply(OptionUnsafe<Func<A, B>> fab, OptionUnsafe<A> fa) =>
            ApplOptional<
                MOptionUnsafe<Func<A, B>>, MOptionUnsafe<A>, MOptionUnsafe<B>, 
                OptionUnsafe<Func<A, B>>, OptionUnsafe<A>, OptionUnsafe<B>, 
                A, B>                
            .Inst.Apply(fab, fa);

        [Pure]
        public OptionUnsafe<A> Pure(A x) =>
            ApplOptional<
                MOptionUnsafe<Func<A, B>>, MOptionUnsafe<A>, MOptionUnsafe<B>, 
                OptionUnsafe<Func<A, B>>, OptionUnsafe<A>, OptionUnsafe<B>, 
                A, B>
            .Inst.Pure(x);

        [Pure]
        public OptionUnsafe<B> Action(OptionUnsafe<A> fa, OptionUnsafe<B> fb) =>
            ApplOptional<
                MOptionUnsafe<Func<A, B>>, MOptionUnsafe<A>, MOptionUnsafe<B>, 
                OptionUnsafe<Func<A, B>>, OptionUnsafe<A>, OptionUnsafe<B>, 
                A, B>
            .Inst.Action(fa, fb);
    }

    public struct FOptionUnsafe<A, B, C> :
        Applicative<OptionUnsafe<Func<A, Func<B, C>>>, OptionUnsafe<Func<B, C>>, OptionUnsafe<A>, OptionUnsafe<B>, OptionUnsafe<C>, A, B, C>
    {
        public static readonly FOptionUnsafe<A, B, C> Inst = default(FOptionUnsafe<A, B, C>);

        [Pure]
        public OptionUnsafe<Func<B, C>> Apply(OptionUnsafe<Func<A, Func<B, C>>> fab, OptionUnsafe<A> fa) =>
            ApplOptional<
                MOptionUnsafe<Func<A, Func<B, C>>>, MOptionUnsafe<Func<B, C>>, MOptionUnsafe<A>, MOptionUnsafe<B>, MOptionUnsafe<C>,
                OptionUnsafe<Func<A, Func<B, C>>>, OptionUnsafe<Func<B, C>>, OptionUnsafe<A>, OptionUnsafe<B>, OptionUnsafe<C>,
                A, B, C>
            .Inst.Apply(fab, fa);

        [Pure]
        public OptionUnsafe<C> Apply(OptionUnsafe<Func<A, Func<B, C>>> fab, OptionUnsafe<A> fa, OptionUnsafe<B> fb) =>
            ApplOptional<
                MOptionUnsafe<Func<A, Func<B, C>>>, MOptionUnsafe<Func<B, C>>, MOptionUnsafe<A>, MOptionUnsafe<B>, MOptionUnsafe<C>,
                OptionUnsafe<Func<A, Func<B, C>>>, OptionUnsafe<Func<B, C>>, OptionUnsafe<A>, OptionUnsafe<B>, OptionUnsafe<C>,
                A, B, C>
            .Inst.Apply(fab, fa, fb);

        [Pure]
        public OptionUnsafe<A> Pure(A x) =>
            ApplOptional<
                MOptionUnsafe<Func<A, Func<B, C>>>, MOptionUnsafe<Func<B, C>>, MOptionUnsafe<A>, MOptionUnsafe<B>, MOptionUnsafe<C>,
                OptionUnsafe<Func<A, Func<B, C>>>, OptionUnsafe<Func<B, C>>, OptionUnsafe<A>, OptionUnsafe<B>, OptionUnsafe<C>,
                A, B, C>
            .Inst.Pure(x);
    }
}
