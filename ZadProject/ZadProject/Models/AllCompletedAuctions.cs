namespace ZadProject.Models
{
    public class AllCompletedAuctions
    {
        public List<CarAuction> CompletedCarAuctions { get; set; }
        public List<OtherAuction> CompletedOtherAuctions { get; set; }
        public List<RealStateAuction> CompletedRealStateAuctions { get; set; }
    }
}
