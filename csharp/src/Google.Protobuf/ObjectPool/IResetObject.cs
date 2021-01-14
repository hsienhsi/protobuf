using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Protobuf
{
    /// <summary>
    /// Resetable Object interface for message
    /// </summary>
    public interface IResetObject
    {
        /// <summary>
        /// Reset Properties
        /// </summary>
        void Reset();
    }
}
