namespace ZadProject.Models
{
    public class AllAuctions
    {
        public List<CarAuction> CarAuction { get; set; }  
        public List<OtherAuction> OtherAuction { get; set; }
        public List<RealStateAuction> RealStateAuction { get; set; }
    }
}
