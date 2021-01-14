namespace Google.Protobuf
{
    /// <summary>
    /// Pool object with allocate and free interface
    /// </summary>
    public interface IPoolObject
    {
        /// <summary>
        /// Allocate Object From Pool
        /// </summary>
        /// <returns></returns>
        object AllocateFromPool();
        /// <summary>
        /// Free Object back to Pool
        /// </summary>
        void FreeToPool();
    }
}
