namespace student_registration.Models
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool Sucess { get; set; } = true;
        public String Message { get; set; } = string.Empty;

    }
}