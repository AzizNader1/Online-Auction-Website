using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ZadProject.Data; // Replace with your actual namespace for the DbContext
using ZadProject.Models; // Replace with your actual namespace for your models

namespace ZadProject.Services // Replace with the desired namespace for your service
{
    public class AuctionStatusUpdater : IHostedService, IDisposable
    {
        private readonly ZadDbContextFactory dbContextFactory;
        private Timer _timer;

        public AuctionStatusUpdater(ZadDbContextFactory context)
        {
            dbContextFactory = context;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Set up the timer to check for completed auctions every minute
            _timer = new Timer(CheckCompletedAuctions, null, 0, 60000); // 60000 milliseconds = 1 minute
            return Task.CompletedTask;
        }

        private void CheckCompletedAuctions(object state)
        {
            var _context = dbContextFactory.CreateDbContext();
            // Get all auctions that have ended
            var completedCarAuctions = _context.CarAuctions.Where(a => a.AuctionEndDate < DateTime.UtcNow && a.AuctionStatus == Status.Accepted).ToList();
            var completedOtherAuctions = _context.OtherAuctions.Where(a => a.AuctionEndDate < DateTime.UtcNow && a.AuctionStatus == Status.Accepted).ToList();
            var completedRealStateAuctions = _context.RealStateAuctions.Where(a => a.AuctionEndDate < DateTime.UtcNow && a.AuctionStatus == Status.Accepted).ToList();

            // Update the status of completed auctions
            foreach (var auction in completedCarAuctions)
            {
                auction.AuctionStatus = Status.Complete;
                _context.CarAuctions.Update(auction);

                var WinnerBidding = _context.BidingCarAuctions.Where(a => a.CarAuctionId == auction.CarAuctionId).OrderByDescending(a => a.BidingPrice).FirstOrDefault();
                
                var WinnerUser = _context.Users.Where(a => a.UserId == WinnerBidding.UserId).FirstOrDefault();

                var NewPurchase = new BuyingCarAuction()
                {
                    CarAuctionId = auction.CarAuctionId,
                    UserId = WinnerUser.UserId 
                };
                _context.BuyingCarAuctions.Add(NewPurchase);
                _context.SaveChanges();
            }
            foreach (var auction in completedOtherAuctions)
            {
                auction.AuctionStatus = Status.Complete;
                _context.OtherAuctions.Update(auction);

                var WinnerBidding = _context.BidingOtherAuctions.Where(a => a.OtherAuctionId == auction.OtherAuctionId).OrderByDescending(a => a.BidingPrice).FirstOrDefault();
                var WinnerUser = _context.Users.Where(a => a.UserId == WinnerBidding.UserId).FirstOrDefault();

                var NewPurchase = new BuyingOtherAuction()
                {
                    OtherAuctionId = auction.OtherAuctionId,
                    UserId = WinnerUser.UserId
                };
                _context.BuyingOtherAuctions.Add(NewPurchase);
                _context.SaveChanges();
            }
            foreach (var auction in completedRealStateAuctions)
            {
                auction.AuctionStatus = Status.Complete;
                _context.RealStateAuctions.Update(auction);

                var WinnerBidding = _context.BidingRealStateAuctions.Where(a => a.RealStateAuctionId == auction.RealStateAuctionId).OrderByDescending(a => a.BidingPrice).FirstOrDefault();
                var WinnerUser = _context.Users.Where(a => a.UserId == WinnerBidding.UserId).FirstOrDefault();

                var NewPurchase = new BuyingRealStateAuction()
                {
                    RealStateAuctinoId = auction.RealStateAuctionId,
                    UserId = WinnerUser.UserId
                };
                _context.BuyingRealStateAuctions.Add(NewPurchase);
                _context.SaveChanges();
            }

           
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Dispose();
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}