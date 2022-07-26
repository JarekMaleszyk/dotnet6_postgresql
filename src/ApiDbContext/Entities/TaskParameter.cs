namespace ApiDbContext.Entities
{
    public class TaskParameter
    {
        public int Id { get; set; }
        public string ParameterName { get; set; }
        public string ParameterDescription { get; set; }
        public string ParameterValue { get; set; }
        public int ParameterOrder { get; set; }
        public int TaskSetingId { get; set; }
        public virtual TaskSetting TaskSeting { get; set; }
    }
}
