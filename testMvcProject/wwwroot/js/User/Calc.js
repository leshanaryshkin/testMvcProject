function calc() {
    var profile = document.getElementById("profile");
    var furniture = document.getElementById("furniture");
    var camers = document.getElementById("camers");
    var result = document.getElementById("result");
    var sashes = document.getElementById("sashes");
    var height = document.getElementById("height");
    var width = document.getElementById("width");
    var price = 0;

    document.getElementById("volume2").innerHTML = height.value;
    document.getElementById("volume").innerHTML = width.value;



    price += height.value * width.value * parseInt(profile.options[profile.selectedIndex].value) / 10000;
    price *= parseInt(camers.options[camers.selectedIndex].value);
    price += parseInt(furniture.options[furniture.selectedIndex].value);
    price *= parseInt(sashes.options[sashes.selectedIndex].value);

    document.getElementById("profile_price").innerHTML = profile.options[profile.selectedIndex].value;
    document.getElementById("furniture_price").innerHTML = furniture.options[furniture.selectedIndex].value;
    document.getElementById("how_many_furniture").innerHTML = sashes.options[sashes.selectedIndex].value;


    document.getElementById("camers_amount").innerHTML = camers.options[camers.selectedIndex].value;
    document.getElementById("sashes_amount").innerHTML = sashes.options[sashes.selectedIndex].value;

    if (price > 0) {
        result.innerHTML = price;
        document.getElementById("price").value = price; 

    }
}

function changeImg(lin) {
    var img = document.getElementById("window_img");
    if (lin == '1') {
        img.src = "/img/AboutUs/window1.png";
    } else if (lin == '2') {
        img.src = "/img/AboutUs/window2.png";
    } else if (lin == '3') {
        img.src = "/img/AboutUs/window3.png";
    }
}

