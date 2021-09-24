namespace EmreCrm.Core.Models
{
    public class AjaxReturnModel
    {
        public bool IsSuccess { get; set; }
        public string Redirect { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}

