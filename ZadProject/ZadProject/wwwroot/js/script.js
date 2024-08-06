document.addEventListener('DOMContentLoaded', () => {
    // Sample counts for demonstration purposes
    const pendingCount = 5;
    const acceptedCount = 3;
    const rejectedCount = 2;

    // Update counts on the index page
    if (document.getElementById('pending-count')) {
        document.getElementById('pending-count').innerText = pendingCount;
    }
    if (document.getElementById('accepted-count')) {
        document.getElementById('accepted-count').innerText = acceptedCount;
    }
    if (document.getElementById('rejected-count')) {
        document.getElementById('rejected-count').innerText = rejectedCount;
    }

    // Add event listeners for accept and reject buttons on pending.html
    document.querySelectorAll('.accept-button').forEach(button => {
        button.addEventListener('click', (e) => {
            const auctionId = e.target.getAttribute('data-id');
            console.log(`Accepted auction with ID: ${auctionId}`);
            moveAuction(auctionId, 'accepted');
        });
    });

    document.querySelectorAll('.reject-button').forEach(button => {
        button.addEventListener('click', (e) => {
            const auctionId = e.target.getAttribute('data-id');
            console.log(`Rejected auction with ID: ${auctionId}`);
            moveAuction(auctionId, 'rejected');
        });
    });

    // Add event listeners for details buttons
    document.querySelectorAll('.details-button').forEach(button => {
        button.addEventListener('click', (e) => {
            const auctionType = e.target.getAttribute('data-type');
            if (auctionType === 'car') {
                window.location.href = 'car_details.html';
            } else if (auctionType === 'house') {
                window.location.href = 'house_details.html';
            } else {
                window.location.href = 'other_details.html';
            }
        });
    });

    // Function to move auction to accepted or rejected
    function moveAuction(auctionId, status) {
        console.log(`Moving auction ID ${auctionId} to ${status}`);
        const auctionCard = document.querySelector(`.auction-card[data-id="${auctionId}"]`);
        if (auctionCard) {
            auctionCard.remove();
        }
        // In a real application, you would also update the server/database here.
    }

    // Sample notification handling
    const notificationList = document.getElementById('notification-list');
    if (notificationList) {
        const notifications = [
            "Auction ID 1 has been accepted.",
            "Auction ID 2 has been rejected.",
            "New auction submitted for approval."
        ];
        notifications.forEach(notification => {
            const li = document.createElement('li');
            li.className = "mb-2 p-3 bg-gray-100 rounded shadow transition duration-300 ease-in-out transform hover:scale-105";
            li.textContent = notification;
            notificationList.appendChild(li);
        });
    }
});
