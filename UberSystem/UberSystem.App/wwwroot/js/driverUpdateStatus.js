function updateDriverStatus() {
    const driverId = "2"; // Replace with the actual driver ID
    const status = "Offline"; // Replace with the desired status (Available, Busy, Offline)

    fetch(`http://localhost:5261/api/uber-system/driver/${driverId}/status/${status}`, {
        method: 'PATCH',
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(response => response.json())
        .then(data => console.log('Success:', data))
        .catch((error) => console.error('Error:', error));
}

// Call updateDriverStatus every 15 seconds
setInterval(updateDriverStatus, 15000);
