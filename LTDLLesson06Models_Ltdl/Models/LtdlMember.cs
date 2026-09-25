namespace LTDLLesson06Models.Models
{
    public class LtdlMember
    {
        public Guid LtdlMemberId { get; set; }
        public string LtdlMemberUserName { get; set; } = "";
        public string LtdlMemberPassword { get; set; } = "";
        public string LtdlMemberEmail { get; set; } = "";
        public string LtdlMemberFullName { get; set; } = "";
    }
}