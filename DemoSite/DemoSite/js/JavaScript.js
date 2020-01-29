function writesquare() {
    var square = {
        width: 100, height: 200, color: 'blue'
    };
    square.width = document.getElementById('txthojde').value;
    document.getElementById('printsquare').innerHTML = "firkanten er "+ square.width +" bred og "+ square.height +" høj";
}