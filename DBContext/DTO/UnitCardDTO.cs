using System;

namespace DBContext.DTO
{
    public class UnitCardDTO
    {
        public Guid Id { get; set; }
        public string StreetName { get; set; } = null!;
        public string Number { get; set; } = null!;
        public int ConstructYear { get; set; }
        public string StagesAmount { get; set; } = null!;
        public int EntranceAmount { get; set; }
        public int LifeAmount { get; set; }
        public int FlatAmount { get; set; }
        public bool IsManagementing { get; set; }
    }
} 