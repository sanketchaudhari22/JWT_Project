namespace JWT_Project.Model.Dto
{
    public class SP_AddUpdWorkoutPlansDto
    {
        public int ID { get; set; }
        public string PLANNAME { get; set; }
        public string DESCRIPTION { get; set; }
        public int TRAINERID { get; set; }
        public int MEMBERID { get; set; }
        public string CREATEDAT { get; set; }
    }
}
