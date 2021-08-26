using Newtonsoft.Json;

namespace back_end_challenge.Models
{
  public class Error
  {
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public override string ToString() => JsonConvert.SerializeObject(this);
    
    
  }
}