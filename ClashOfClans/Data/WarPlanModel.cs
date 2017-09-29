namespace ClashOfClans.Data
{
    public class WarPlanModel
    {
        public int Id { get; set; }
        public string MemberName { get; set; }
        public string Plan { get; set; }
        
        public static WarPlanModel Empty() => new WarPlanModel{MemberName = "None", Plan = "No Plan"};
    }

    //implement Null Object pattern

}