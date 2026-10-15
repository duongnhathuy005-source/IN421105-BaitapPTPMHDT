try
{
    Club club = Club.Create("Tech Club", "Câu lạc bộ công nghệ");

    Member member1 = Member.Create("Nguyen Van A", "a@gmail.com", "SV001");
    Member member2 = Member.Create("Tran Van B", "b@gmail.com", "SV002");
    Member member3 = Member.Create("Le Van C", "c@gmail.com", "SV003");

    club.AddMember(member1);
    club.AddMember(member2);
    club.AddMember(member3);

    Console.WriteLine(" THONG TIN CAU LAC BO ");
    Console.WriteLine("Ten CLB: " + club.Name);
    Console.WriteLine("So thanh vien: " + club.MemberCount());

    Event ev = Event.Create(
        club.Id,
        "Workshop AI",
        DateTime.Now.AddDays(7),
        50,
        false);

    Console.WriteLine("\n THONG TIN SU KIEN ");
    Console.WriteLine("Ten su kien: " + ev.Title);
    Console.WriteLine("Suc chua: " + ev.Capacity);

    Registration registration1 = Registration.Create(member1.Id, ev.Id);
    Registration registration2 = Registration.Create(member2.Id, ev.Id);

    registration1.Confirm();
    registration2.Confirm();

    Console.WriteLine("\n DANH SACH DANG KY ");
    Console.WriteLine(member1.Name + ": " + registration1.Status);
    Console.WriteLine(member2.Name + ": " + registration2.Status);

    CheckIn checkIn = CheckIn.Create(registration1.Id, "QR");

    Console.WriteLine("\n DIEM DANH ");
    Console.WriteLine(member1.Name + " da diem danh.");
    Console.WriteLine(checkIn.Summary());

    Console.WriteLine("\n BAO CAO ");
    Console.WriteLine("Tong so dang ky: 2");
    Console.WriteLine("Tong so diem danh: 1");
    Console.WriteLine("Thanh vien tham gia:");
    Console.WriteLine("- " + member1.Name);
    Console.WriteLine("- " + member2.Name);
}
catch (Exception ex)
{
    Console.WriteLine("Loi: " + ex.Message);
}