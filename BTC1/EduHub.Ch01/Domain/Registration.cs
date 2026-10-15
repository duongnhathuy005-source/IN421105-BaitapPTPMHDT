public class Registration
{
    public Guid Id { get; private set; }
    public Guid MemberId { get; private set; }
    public Guid EventId { get; private set; }
    public DateTime RegisteredAt { get; private set; }
    public string Status { get; private set; }

    private Registration(Guid memberId, Guid eventId)
    {
        Id = Guid.NewGuid();
        MemberId = memberId;
        EventId = eventId;
        RegisteredAt = DateTime.Now;
        Status = "Pending";
    }

    public static Registration Create(Guid memberId, Guid eventId)
    {
        if (memberId == Guid.Empty)
            throw new ArgumentException("Mã thành viên không hợp lệ!");

        if (eventId == Guid.Empty)
            throw new ArgumentException("Mã sự kiện không hợp lệ!");

        return new Registration(memberId, eventId);
    }

    public void Confirm()
    {
        if (Status == "Cancelled")
            throw new InvalidOperationException("Không thể xác nhận đăng ký đã hủy!");

        Status = "Confirmed";
    }

    public void Cancel()
    {
        if (Status == "Cancelled")
            throw new InvalidOperationException("Đăng ký đã được hủy!");

        Status = "Cancelled";
    }
}