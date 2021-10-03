using System;

namespace TransNeftTest.Exceptions
{
    /// <summary> Ислкючение, возникающее при отсутствии запрошенной сущности в базе </summary>
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(string message)
            : base(message)
        {
        }

        public EntityNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}