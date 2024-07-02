using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Models.Dbo;

public class OperationDbo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ID { get; set; }
    [ForeignKey("Container")]
    public Guid ContainerID { get; set; }
    [Column(TypeName = "timestamp with time zone")]
    public DateTime StartDate { get; set; }
    [Column(TypeName = "timestamp with time zone")]
    public DateTime EndDate { get; set; }
    [StringLength(100)]
    public string OperationType { get; set; }
    [StringLength(200)]
    public string OperatorName { get; set; }
    [StringLength(200)]
    public string InspectionPlace { get; set; }
    public virtual ContainerDbo Container { get; set; }

}