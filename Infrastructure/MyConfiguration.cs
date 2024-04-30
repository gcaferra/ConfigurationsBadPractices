using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Infrastructure;

public class MyConfiguration
{
    [Required]
    [Range(1, 100)]
    public int MyServiceLevelSetting { get; set; }
    [Required]
    public string ExternalUrl { get; set; }
    [Required]
    public string ConnectionString { get; set; }
    public string AnotherConfig { get; set; }
}