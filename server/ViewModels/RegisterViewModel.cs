namespace LeekQuest.ViewModels
{
  using System.ComponentModel.DataAnnotations;
  public class RegisterViewModel
  {
    [Required]
    public string UserName { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
  }
}