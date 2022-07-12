namespace Managely.Models.ViewModel;

public class CollaboratorViewModel
{
    public Guid EmployeeId { get; set; }
    public string DisplayName { get; set; }
    public string AvatarUrl { get; set; }
    public string Email { get; set; }
    public string JobPosition { get; set; }
    public string Department { get; set; }
}