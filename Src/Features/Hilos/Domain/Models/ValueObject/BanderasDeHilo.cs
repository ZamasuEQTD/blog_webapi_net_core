namespace Hilos.Domain
{
    public class BanderasDeHilo
    {
        public bool DadosActivado { get; private set; }
        public bool IdUnicoActivado { get; private set; }

        public BanderasDeHilo(bool dadosActivado, bool idUnicoActivado)
        {
            DadosActivado = dadosActivado;
            IdUnicoActivado = idUnicoActivado;
        }

    }
}