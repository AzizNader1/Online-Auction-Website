namespace ZadProject.Models
{
    public class AllAcceptedAuctions
    {
        public List<CarAuction> AcceptedCarAuctions { get; set; }
        public List<OtherAuction> AcceptedOtherAuctions { get; set; }
        public List<RealStateAuction> AcceptedRealStateAuctions { get; set; }

    }
}
