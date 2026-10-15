public class CheckIn
{
    public Guid Id { get; private set; }
    public Guid RegistrationId { get; private set; }
    public DateTime CheckedInAt { get; private set; }
    public string Method { get; private set; }

    private CheckIn(Guid registrationId, string method)
    {
        Id = Guid.NewGuid();
        RegistrationId = registrationId;
        CheckedInAt = DateTime.Now;
        Method = method;
    }

    public static CheckIn Create(Guid registrationId, string method)
    {
        if (registrationId == Guid.Empty)
            throw new ArgumentException("Mã đăng ký không hợp lệ!");

        if (string.IsNullOrWhiteSpace(method))
            throw new ArgumentException("Phương thức điểm danh không được để trống!");

        return new CheckIn(registrationId, method);
    }

    public string Summary()
    {
        return "Thời gian: " + CheckedInAt
            + ", Phương thức: " + Method;
    }
}