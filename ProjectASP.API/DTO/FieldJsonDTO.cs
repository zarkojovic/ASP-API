namespace ProjectASP.API.DTO
{
    public class FieldJsonDTO
    {
        public string type { get; set; }
        public bool IsRequired { get; set; }
        public string title { get; set; }
        public string field_name { get; set; }
        public string formLabel { get; set; }
        public List<FieldItemJsonDTO> items { get; set; } = new List<FieldItemJsonDTO>();
    }
}
