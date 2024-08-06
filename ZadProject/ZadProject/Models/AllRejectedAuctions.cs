namespace ZadProject.Models
{
    public class AllRejectedAuctions
    {
        public List<CarAuction> RejectedCarAuctions { get; set; }
        public List<OtherAuction> RejectedOtherAuctions { get; set; }
        public List<RealStateAuction> RejectedRealStateAuctions { get; set; }

    }
}
