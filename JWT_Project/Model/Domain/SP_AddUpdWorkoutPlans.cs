namespace JWT_Project.Model.Domain
{
    public class SP_AddUpdWorkoutPlans
    {
        public string ID			 { get; set; }
        public string PLANNAME	 { get; set; }
        public string DESCRIPTION { get; set; }
        public int TRAINERID	 { get; set; }
        public int MEMBERID	 { get; set; }
        public string CREATEDAT { get; set; }
    }
}
