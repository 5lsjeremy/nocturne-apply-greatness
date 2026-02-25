namespace Nocturne.Surface.Exceptions
{
    public class SurfaceException : Exception
    {
        public SurfaceException(string message)
            : base(message)
        {
        }

        public SurfaceException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}