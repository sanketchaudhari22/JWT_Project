namespace JWT_Project.Model.Domain
{
    public class SP_AddUpdWorkoutPlans
    {
        public int ID			 { get; set; }
        public string PLANNAME	 { get; set; }
        public string DESCRIPTION { get; set; }
        public string TRAINERID	 { get; set; }
        public string MEMBERID	 { get; set; }
        public string CREATEDAT { get; set; }
    }
}
