public class Club
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public List<Member> Members { get; private set; }

    private Club(string name, string description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        CreatedAt = DateTime.Now;
        Members = new List<Member>();
    }

    public static Club Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Tên câu lạc bộ không được để trống!");

        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Mô tả không được để trống!");

        return new Club(name, description);
    }

    public void AddMember(Member member)
    {
        if (member == null)
            throw new ArgumentException("Thành viên không hợp lệ!");

        Members.Add(member);
    }

    public int MemberCount()
    {
        return Members.Count;
    }
}