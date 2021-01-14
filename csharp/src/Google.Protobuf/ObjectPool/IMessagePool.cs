namespace Google.Protobuf
{
    /// <summary>
    /// MessagePool for message allocation
    /// </summary>
    public interface IMessagePool
    {
        /// <summary>
        /// Allocate Object
        /// </summary>
        /// <returns></returns>
        object Allocate();
        /// <summary>
        /// Free to pool
        /// </summary>
        /// <param name="obj"></param>
        void Free(object obj);

        /// <summary>
        /// Allocated Object Count
        /// </summary>
        int AllocateCount { get; }

        /// <summary>
        /// Created Object Count
        /// </summary>
        int CreatedObjectCount { get; }

        /// <summary>
        /// Useable Object Count
        /// </summary>
        int UseableCount { get; }

        /// <summary>
        /// Free Object Count
        /// </summary>
        int FreeCount { get; }

    }
}
