using System;

namespace webapi.DTO
{
    public class UnitCardDTO
    {
        public Guid Id { get; set; }
        public string StreetName { get; set; }
        public string Number { get; set; }
        public int ConstructYear { get; set; }
        public string StagesAmount { get; set; }
        public int EntranceAmount { get; set; }
        public int LifeAmount { get; set; }
        public int FlatAmount { get; set; }
        public bool IsManagementing { get; set; }
    }
} 