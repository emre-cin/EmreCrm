namespace EmreCrm.Core.Models
{
    public class ReturnModel<TEntity>
    {
        public bool IsSuccess { get; set; }
        public string Redirect { get; set; }
        public TEntity Data { get; set; }
        public string Message { get; set; }
    }

    public class ReturnModel
    {
        public bool IsSuccess { get; set; }
        public string Redirect { get; set; }
        public string Message { get; set; }
    }
}

