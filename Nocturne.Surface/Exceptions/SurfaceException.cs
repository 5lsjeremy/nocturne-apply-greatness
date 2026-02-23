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