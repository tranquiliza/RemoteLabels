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

var map;

window.LoadMap = function (lat, lon) {
    map = L.map('mapid').setView([lat, lon], 13);

    L.tileLayer('https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token={accessToken}', {
        attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors, <a href="https://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
        maxZoom: 24,
        id: 'tranquiliza/ckboajc9e362c1ipgsi30x8ar',
        tileSize: 512,
        zoomOffset: -1,
        accessToken: 'pk.eyJ1IjoidHJhbnF1aWxpemEiLCJhIjoiY2tibW5keW9hMG9kYzJ1cXQ2djRvY3l6NSJ9.AJiyP9uGMSYOFJSNC8MEEQ'
    }).addTo(map);
}

var marker = null;

window.UpdateView = function (lat, lon) {
    map.setView([lat, lon], 18)

    if (marker === null) {
        marker = L.circleMarker([lat, lon], {
            color: '#3388ff'
        }).addTo(map);
    }
    else {
        map.removeLayer(marker);
        marker = L.circleMarker([lat, lon], {
            color: '#3388ff'
        }).addTo(map);
    }
}