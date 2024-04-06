namespace DomainProjetoBack.Entities
{
    public class ResponseMicroService<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
        public string ProcessingTime { get; set; }
    }

    public class EnumeratorsCommons
    {
        public enum EnumStatus
        {
            Active,
            Inactive
        }

        public enum EnumYesNo
        {
            Yes,
            No
        }

        public enum DataOperation
        {
            Insert,
            Update,
            Delete,
            Select
        }
    }
}
