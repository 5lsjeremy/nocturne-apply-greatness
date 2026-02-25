namespace Nocturne.Surface.Exceptions
{
    public class SurfaceLoadException : SurfaceException
    {
        public SurfaceLoadException(string message)
            : base(message)
        {
        }

        public SurfaceLoadException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}