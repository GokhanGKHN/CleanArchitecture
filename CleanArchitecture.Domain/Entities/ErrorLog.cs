using CleanArchitecture.Domain.Apstractions;

namespace CleanArchitecture.Domain.Entities;
public sealed class ErrorLog : Entity
{
    public string ErrorMessage { get; set; }
    public string ErrorStackTrace { get; set; }
    public string RequestPath { get; set; }
    public string RequestMethod { get; set; }
    public DateTime Timestamp { get; set; }


}
