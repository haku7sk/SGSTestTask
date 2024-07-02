namespace TestTask.Models.Dto;

public class OperationDto
{
    public Guid ID { get; set; }
    public Guid ContainerID { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string OperationType { get; set; }
    public string OperatorName { get; set; }
    public string InspectionPlace { get; set; }
    public string Duration => $"{(EndDate - StartDate).TotalHours} hours";

}