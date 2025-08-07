public class Role
{
    public int Id { get; set; }
    public int ActorId { get; set; }
    public int MovieId { get; set; }
    public string RoleName { get; set; }
    public Actor Actor { get; set; }
    public Movie Movie { get; set; }
}