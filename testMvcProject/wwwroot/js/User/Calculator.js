function heightSlider(value){
    if (value > 99)
        document.getElementById('heightSlider').style.width = '13px';
    else
        document.getElementById('heightSlider').style.width = '10px';
    document.getElementById('heightSlider').innerHTML = value;
}


function widthSlider(value){
    if (value > 99)
        document.getElementById('widthSlider').style.width = '13px';
    else
        document.getElementById('widthSlider').style.width = '10px';
    document.getElementById('widthSlider').innerHTML = value;
}

