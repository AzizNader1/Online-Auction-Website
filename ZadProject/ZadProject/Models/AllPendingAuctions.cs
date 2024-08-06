namespace ZadProject.Models
{
    public class AllPendingAuctions
    {
        public List<CarAuction> PendingCarAuctions { get; set; }
        public List<OtherAuction> PendingOtherAuctions { get; set; }
        public List<RealStateAuction> PendingRealStateAuctions { get; set; }

    }
}
