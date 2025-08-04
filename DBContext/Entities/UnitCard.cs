using System;

namespace DBContext.Entities
{
    public class UnitCard
    {
        public Guid Id { get; set; }
        public string StreetName { get; set; }
        public string Number { get; set; }
        public int ConstructYear { get; set; }
        public string StagesAmount { get; set; }
        public int EntranceAmount { get; set; }
        public int LiftAmount { get; set; }
        public int FlatAmount { get; set; }
        public bool IsManagementing { get; set; }


        public Unit Unit { get; set; }
        public Guid UnitId { get; set; }
    }
} 