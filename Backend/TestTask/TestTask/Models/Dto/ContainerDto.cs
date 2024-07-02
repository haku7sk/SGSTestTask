namespace TestTask.Models.Dto;

public class ContainerDto
{
    public Guid ID { get; set; }
    public int Number { get; set; }
    public string Type { get; set; }
    public decimal Length { get; set; }
    public decimal Width { get; set; }
    public decimal Height { get; set; }
    public decimal Weight { get; set; }
    public bool IsEmpty { get; set; }
    public DateTime DateReceived { get; set; }
    public string DisplayDate => DateReceived.ToString("yyyy-MM-dd");
}