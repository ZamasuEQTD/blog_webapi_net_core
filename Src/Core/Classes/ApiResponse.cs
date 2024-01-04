namespace Core
{
    public class ApiResponse<T>
    {

        public T? Body { get; set; }
        public bool Ok { get; set; } = true;

        public string? Mensaje { get; set; }


        public void SetError(string mensaje)
        {
            Ok = false;
            Mensaje = mensaje;
        }


    }
}