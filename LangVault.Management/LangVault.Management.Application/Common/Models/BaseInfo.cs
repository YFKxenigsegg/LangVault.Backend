namespace LangVault.Management.Application.Common.Models;
public class BaseInfo
{
    public int Id { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime CreatedUtc {  get; set; }
}
