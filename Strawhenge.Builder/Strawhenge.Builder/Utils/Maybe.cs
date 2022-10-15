﻿using System;

namespace Strawhenge.Builder
{
    public abstract class Maybe<T>
    {
        public abstract void Do(Action<T> action);

        public abstract Maybe<TNew> Map<TNew>(Func<T, TNew> mapping);

        public abstract T Reduce(Func<T> reducer);

        public abstract bool HasSome(out T value);
    }

    public static class Maybe
    {
        public static Maybe<T> Some<T>(T value) => new Some<T>(value);

        public static Maybe<T> None<T>() => new None<T>();
    }

    sealed class None<T> : Maybe<T>
    {
        public override void Do(Action<T> action)
        {
        }

        public override Maybe<TNew> Map<TNew>(Func<T, TNew> mapping) => new None<TNew>();

        public override T Reduce(Func<T> fallback) => fallback();

        public override bool HasSome(out T value)
        {
            value = default;
            return false;
        }
    }

    sealed class Some<T> : Maybe<T>
    {
        readonly T _value;

        public Some(T value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            _value = value;
        }

        public override void Do(Action<T> action) => action(_value);

        public override Maybe<TNew> Map<TNew>(Func<T, TNew> mapping) => new Some<TNew>(mapping(_value));

        public override T Reduce(Func<T> fallback) => _value;

        public override bool HasSome(out T value)
        {
            value = this._value;
            return true;
        }
    }
}
