namespace Core.Failures
{
    public sealed record Failure(string Code, string? Descripcion = null)
    {
        public static readonly Failure None = new(string.Empty);
    }
}