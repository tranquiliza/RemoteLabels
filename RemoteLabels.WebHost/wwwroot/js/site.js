window.GetCoordinates = function (dotnetHelper) {
    window.reference = dotnetHelper;
    this.navigator.geolocation.getCurrentPosition(window.LocationCallback);
}


window.LocationCallback = function (result) {
    let lat = result.coords.latitude;
    let lon = result.coords.longitude;

    console.log("Updating Location");
    window.reference.invokeMethodAsync('UpdateLocation', lat, lon);
}