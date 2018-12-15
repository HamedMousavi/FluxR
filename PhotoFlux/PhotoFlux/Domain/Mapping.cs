using System;


namespace PhotoFlux.Domain {


    public interface IMapper<TTarget, TSource> {
        TTarget Map(TSource source);

        TSource Map(TTarget target);

        void Map(TSource source, TTarget target);

        void Map(TTarget source, TSource target);
    }


    public abstract class BaseMapper<TTarget, TSource> : IMapper<TTarget, TSource> {


        public TTarget Map(TSource source) {
            var copy = Create(source);
            if (source != null) Copy(source, copy);
            return copy;
        }


        public TSource Map(TTarget target) {
            var copy = Create(target);
            if (target != null) Copy(target, copy);
            return copy;
        }


        public void Map(TSource source, TTarget target) {
            if (null == source) throw new ArgumentNullException(nameof(source),
                $"Value cannot be null. Parameter: {typeof(TSource).AssemblyQualifiedName}-{typeof(TSource).FullName}");
            if (null == target) throw new ArgumentNullException(nameof(target),
                $"Value cannot be null. Parameter: {typeof(TTarget).AssemblyQualifiedName}-{typeof(TTarget).FullName}");

            Copy(source, target);
        }


        public void Map(TTarget source, TSource target) {
            if (null == source) throw new ArgumentNullException(nameof(source),
                $"Value cannot be null. Parameter: {typeof(TSource).AssemblyQualifiedName}-{typeof(TSource).FullName}");
            if (null == target) throw new ArgumentNullException(nameof(target),
                $"Value cannot be null. Parameter: {typeof(TTarget).AssemblyQualifiedName}-{typeof(TTarget).FullName}");

            Copy(source, target);
        }


        protected virtual TTarget Create(TSource source) {
            return Activator.CreateInstance<TTarget>();
        }


        protected virtual TSource Create(TTarget target) {
            return Activator.CreateInstance<TSource>();
        }


        protected abstract void Copy(TSource source, TTarget target);

        protected abstract void Copy(TTarget source, TSource target);
    }
}
