namespace PruebaECommerce.Common.Results
{
    //Objeto global para retornar resultados de operaciones, incluyendo éxito, mensaje de error y código de estado.
    public class Result<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public int StatusCode { get; set; }

        public T? Data { get; set; }
    }

    public class Result
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public int StatusCode { get; set; }
    }
}
