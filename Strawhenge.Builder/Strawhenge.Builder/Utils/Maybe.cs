using System;

namespace Strawhenge.Builder
{
    public abstract class Maybe<T>
    {
        public abstract void Do(Action<T> action);

        public abstract Maybe<TNew> Map<TNew>(Func<T, TNew> mapping);

        public abstract T Reduce(Func<T> reducer);
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
    }

    sealed class Some<T> : Maybe<T>
    {
        readonly T value;

        public Some(T value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            this.value = value;
        }

        public override void Do(Action<T> action) => action(value);

        public override Maybe<TNew> Map<TNew>(Func<T, TNew> mapping) => new Some<TNew>(mapping(value));

        public override T Reduce(Func<T> fallback) => value;
    }
}
