function calc() {
    var profile = document.getElementById("profile");
    var camers = document.getElementById("camers");
    var result = document.getElementById("result");
    var sashes = document.getElementById("sashes");
    var option1 = document.getElementById("option1");
    var option2 = document.getElementById("option2");
    var option3 = document.getElementById("option3");
    var additionallySum = 0;
    var height = document.getElementById("height");
    var width = document.getElementById("width");
    var price = 0;

    document.getElementById("volume2").innerHTML = height.value;
    document.getElementById("volume").innerHTML = width.value;

    price += height.value * width.value * parseInt(profile.options[profile.selectedIndex].value) / 10000;
    price *= parseInt(camers.options[camers.selectedIndex].value);
    price *= parseInt(sashes.options[sashes.selectedIndex].value);
    price += (option1.checked == true) ? parseInt(option1.value) : 0;
    price += (option2.checked == true) ? parseInt(option2.value) : 0;
    price += (option3.checked == true) ? parseInt(option3.value) : 0;

    document.getElementById("profile_price").innerHTML = profile.options[profile.selectedIndex].value;
    document.getElementById("camers_amount").innerHTML = camers.options[camers.selectedIndex].value;
    document.getElementById("sashes_amount").innerHTML = sashes.options[sashes.selectedIndex].value;
    if (option1.checked) {
        additionallySum += parseInt(option1.value);
    }
    if (option2.checked) {
        additionallySum += parseInt(option2.value);
    }
    if (option3.checked) {
        additionallySum += parseInt(option3.value);
    }
    if (additionallySum > 0) {
        document.getElementById("additionally").innerHTML = additionallySum;
    }

    if (price > 0) {
        result.innerHTML = price;
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

