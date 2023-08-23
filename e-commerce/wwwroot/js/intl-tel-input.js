
$(document).ready(function () {
    var iti = intlTelInput(document.querySelector("#intlTelInput2"), {
        initialCountry: "auto",
        preferredCountries: ["us", "co", "in", "de", "lb"],
        geoIpLookup: getIp,
        nationalMode: true,
    });
});

function getIp(callback) {
    fetch('https://ipinfo.io/json?token=f82a6f605c0a2a', { headers: { 'Accept': 'application/json' } })
        .then((resp) => resp.json())
        .catch(() => {
            return {
                country: 'us',
            };
        })
        .then((resp) => callback(resp.country));
}



