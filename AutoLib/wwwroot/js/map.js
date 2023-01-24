// Scripts pour générer et gérer la map
console.log("Map.js Launch");

/**
 * Retourne le JSON contenant les informations des stations
 * @returns {JSON} Promise : JSON contenant les informations des stations
*/
const getStations = async () => {
    try {
        const response = await fetch('/Station/Map');
        const data = await response.json();
        return data;
    } catch (error) {
        console.log(error);
    }
}

const setMarkers = (map, stations) => {
    stations.forEach(station => {
        // Options
        let containerPopup = `<h1 class="h6">Station</h1>
             <p>${station.adresse}</p>
             <p class="text-secondary">Voiture disponible : <a href="/Station/Details/${station.IdStation}", title="Consulter">${station.numero}</a> </p>`
        let popup = L.popup().setContent(containerPopup);

        let marker = L.marker([station.latitude, station.longitude])
            .addTo(map)
            .bindPopup(popup)

        // Vérification voirute disponible
        if (!station.numero) marker.setOpacity(0.5);
    });
}

/**
 * Génère la Map Leaflet.js et place les marqueurs correspondant aux stations
*/
const map = async () => {
    var map = L.map('map').setView([45.745013, 4.871353], 13);
    L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 19,
        attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
    }).addTo(map);

    let stations = await getStations();
    setMarkers(map, stations);
}

map();