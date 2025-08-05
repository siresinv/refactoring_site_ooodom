using System;

namespace DBContext.Entities
{
    public class UnitCard
    {
        public Guid Id { get; set; }
        public string StreetName { get; set; } = null!;
        public string Number { get; set; } = null!;
        public int ConstructYear { get; set; }
        public string StagesAmount { get; set; } = null!;
        public int EntranceAmount { get; set; }
        public int LiftAmount { get; set; }
        public int FlatAmount { get; set; }
        public bool IsManagementing { get; set; }


        public Unit Unit { get; set; } = null!;
        public Guid UnitId { get; set; }
    }
} 