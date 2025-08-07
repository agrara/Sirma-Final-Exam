public class Actor
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public ICollection<Role> Roles { get; set; }
}