namespace Encuestas.Infraestructure
{
    public class GetEncuestaDto
    {
        public string Id { get; set; }
        public int VotosTotales { get; set; }
        public List<GetOpcionDeEncuestaDto> Opciones { get; set; }
    }
}