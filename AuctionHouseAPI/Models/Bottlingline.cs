using FSharp.Data.Runtime.StructuralTypes;
using System.Numerics;

namespace AuctionHouseAPI.Models
{
    public class Bottlingline
    {
        public int Id { get; set; }
        public int ItemsPerHour { get; set; }
        public decimal ChangeOverTimeShort { get; set; }
        public decimal ChangeOverTimeLong { get; set; }
        public int Tolerances { get; set; }
        public int ErrorSensitivity {  get; set; }
        public int PeopleAtLine { get; set; }
        public BigInteger CostsPerYear { get; set; }
        public decimal Investment { get; set; }
        public int FillingLineType { get; set; }
        public Bit CupsFillingLine { get; set; }
        public decimal BootLoss { get; set; }
        public decimal KwhPerWorkingHour { get; set; }
        public decimal KgCo2EmissionCleaning { get; set; }
        public decimal LitreJuiceLossCleaning { get; set; }


    }
}
