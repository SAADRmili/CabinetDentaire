namespace CabinetDentaire.Shared.Entities
{
    public class WorkCategory
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public TimeSpan HourStartWork { get; set; }
        public TimeSpan HourEndWork { get; set; }


    }
}
