namespace Store.Web.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        // Метод, который возвращает значение, указывающее, следует ли отображать идентификатор запроса
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
