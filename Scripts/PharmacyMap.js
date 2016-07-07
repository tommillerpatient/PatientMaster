
var map;
var infoWindow;
var service;
var addrInfo;

var txtPharmacy;
var txtStreet;
var txtCity;
var txtState;
var txtCountry;
var txtZip;
var txtPhone;
//default value
var lat = '32.7846762';
var lng = '-96.80274639';
var zoomLevel = 15;

function getLatLng() {
    var address = $('#PharmacyZipcode').val();

    zoomLevel = 15;

    //test:
    var foundZip = false;
    var zipTxt = '';
    $.ajax({
        url: "/Content/ziplatlng.txt",
        async: false,
        dataType: "text",
        success: function (data) {
            zipTxt = data;
        },
        error: function (e) {
            console.log(e);
        }
    });

    if (zipTxt != '') {
        var start_pos = zipTxt.indexOf('|' + address) + 7;
        if (start_pos >= 7) {
            var end_pos = zipTxt.indexOf('|', start_pos);
            var zipInfo = zipTxt.substring(start_pos, end_pos)
            var aryZip = zipInfo.split(',');
            lat = aryZip[0].trim();
            lng = aryZip[1].trim();
            if (lat != '' && lng != '') {
                foundZip = true;
                initialize();
                return;
            }
        }
    }

    if (!foundZip) {
        var geocoder = new google.maps.Geocoder();
        geocoder.geocode({ 'address': address }, function (results, status) {
            if (status === google.maps.GeocoderStatus.OK) {
                lat = results[0].geometry.location.lat();
                lng = results[0].geometry.location.lng();
                initialize();
            }
            else if (status === google.maps.GeocoderStatus.OVER_QUERY_LIMIT) {
                setTimeout(function () {
                    GeocodeFind(address);
                }, 500);
            }
            else {
                alert("Geocode was not successful for the following reason:" + status);
            }
        });
    }
}

function initialize() {
    var myLatlng = new google.maps.LatLng(lat, lng);

    map = new google.maps.Map(document.getElementById('map-canvas'), {
        center: myLatlng,
        zoom: zoomLevel,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    });

    infoWindow = new google.maps.InfoWindow();
    service = new google.maps.places.PlacesService(map);

    google.maps.event.addListenerOnce(map, 'bounds_changed', performSearch);
    google.maps.event.addListenerOnce(map, 'zoom_changed', performSearch);
}

function performSearch() {
    var request = {
        bounds: map.getBounds(),
        keyword: 'pharmacy',
        type: ['pharmacy']
    };
    service.radarSearch(request, callback);
}

function callback(results, status) {
    if (status != google.maps.places.PlacesServiceStatus.OK
            && zoomLevel == 11) {
        alert('No results found');
        //var txt = $('#nearZip').text() + ': No results found.';
        //$('#nearZip').text(txt);
        return;
    }
    else if (status == google.maps.places.PlacesServiceStatus.ZERO_RESULTS) {
        zoomLevel = (zoomLevel == 15 ? 13 : 11);
        initialize();
        return;
    }

    for (var i = 0, result; result = results[i]; i++) {
        createMarker(result);
    }
}

function removeApostrophe(str) {
    if (typeof str != "string") return str;
    return str.replace("'", "");
}

function removeUnitedStates(str) {
    if (typeof str != "string") return str;
    return str.slice(0, str.lastIndexOf(", United States"))
}

function createMarker(place) {
    var addrFormatted;
    var marker = new google.maps.Marker({
        map: map,
        position: place.geometry.location,
        icon: 'http://www.google.com/intl/en_us/mapfiles/ms/micons/red-dot.png'
    });

    google.maps.event.addListener(marker, 'click', function () {
        service.getDetails(place, function (result, status) {

            if (status != google.maps.places.PlacesServiceStatus.OK) {
                alert(status);
                return;
            }

            txtPharmacy = removeApostrophe(result.name);
            txtPhone = result.formatted_phone_number;
            addrFormatted = removeApostrophe(result.formatted_address);
            addrFormatted = removeUnitedStates(addrFormatted);


            var addrContent = '<div><strong>' + txtPharmacy + '</strong><br />' +
                    addrFormatted + '<br />' + txtPhone + '<br />' +
                    '<button type="button" class="btn zn_sub_button btn-fullcolor btn-xs" style="padding: 1px 1px !important;" onclick="showInfo(\'' + txtPharmacy + '\',\'' + txtPhone + '\',\'' + addrFormatted + '\');">SELECT</button>';

            infoWindow.setContent(addrContent);
            infoWindow.open(map, marker);
        });
    });
}

function showInfo(pharm, phone, addr) {
    infoWindow.close();
    alert(pharm+' - '+ phone+' - '+addr);
    //$('#PharmacyName').text(pharm);
    //$('#PharmacyNumber').text(phone);
    //$('#PharmacyAddress').text(addr);
    //$('#preferred-pharmacy-information').show('slow');
    //$("#modal-content, #modal-background").toggleClass("active");
}

function GeocodeFind(address) {
    var geocoder = new google.maps.Geocoder();

    geocoder.geocode({ 'address': address }, function (results, status) {
        if (status === google.maps.GeocoderStatus.OK) {
            lat = results[0].geometry.location.lat();
            lng = results[0].geometry.location.lng();
        }
        else if (status === google.maps.GeocoderStatus.OVER_QUERY_LIMIT) {
            setTimeout(function () {
                GeocodeFind(address);
            }, 500);
        }
        else {
            alert("Geocode was not successful for the following reason:" + status);
        }
    });
}
