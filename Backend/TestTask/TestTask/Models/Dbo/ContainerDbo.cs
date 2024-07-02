using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Models.Dbo;

public class ContainerDbo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ID { get; set; }
    public int Number { get; set; }
    [StringLength(100)]
    public string Type { get; set; }
    [Column(TypeName = "decimal(10, 2)")]
    public decimal Length { get; set; }
    [Column(TypeName = "decimal(10, 2)")]
    public decimal Width { get; set; }
    [Column(TypeName = "decimal(10, 2)")]
    public decimal Height { get; set; }
    [Column(TypeName = "decimal(10, 2)")]
    public decimal Weight { get; set; }
    public bool IsEmpty { get; set; }
    [Column(TypeName = "timestamp with time zone")]
    public DateTime DateReceived { get; set; }
}