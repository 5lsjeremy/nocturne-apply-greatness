namespace Nocturne.Surface.Exceptions
{
    public class InvalidConceptException : SurfaceException
    {
        public InvalidConceptException(string message) : base(message)
        {
        }

        public InvalidConceptException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}