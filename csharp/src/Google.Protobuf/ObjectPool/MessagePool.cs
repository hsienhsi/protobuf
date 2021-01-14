namespace Google.Protobuf
{
    /// <summary>
    /// MessagePool for factory allocation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MessagePool<T> : IMessagePool where T : class, IMessage<T>
    {
        // factoryFunc is stored for the lifetime of the pool. We will call this only when pool needs to
        // expand. compared to "new T()", Func gives more flexibility to implementers and faster
        // than "new T()".
        private readonly System.Func<T> _factoryFunc;

        /// <summary>
        /// Allocate MessagePool
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="size"></param>
        public MessagePool(System.Func<T> factory, int size = 10)
        {
            _factoryFunc = factory;
            _pool = new ObjectPool<T>(_factoryFunc, size);
        }

        private ObjectPool<T> _pool;

        object IMessagePool.Allocate()
        {
            return _pool.Allocate();
        }

        void IMessagePool.Free(object obj)
        {
            if (obj is T && obj != null)
                _pool.Free(obj as T);
        }

        /// <summary>
        /// Allocate Object
        /// </summary>
        /// <returns></returns>
        public T Allocate() => _pool.Allocate();
        /// <summary>
        /// Free Object
        /// </summary>
        /// <param name="obj"></param>
        public void Free(T obj)
        {
            if (obj != null) _pool.Free(obj);
        }

        /// <summary>
        /// Allocated Object Count
        /// </summary>
        public int AllocateCount => _pool.AllocateCount;
        
        /// <summary>
        /// Created Object Count
        /// </summary>
        public int CreatedObjectCount => _pool.CreatedObjectCount;
        
        /// <summary>
        /// Useable Object Count
        /// </summary>
        public int UseableCount => _pool.UsableCount;

        /// <summary>
        /// Free Object Count
        /// </summary>
        public int FreeCount => _pool.FreeCount;
    }
}
