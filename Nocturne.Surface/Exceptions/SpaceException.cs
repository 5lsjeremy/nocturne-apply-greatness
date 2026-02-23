namespace Nocturne.Surface.Exceptions
{
    public class SpaceException : SurfaceException
    {
        public SpaceException(string message)
            : base(message)
        {
        }

        public SpaceException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}