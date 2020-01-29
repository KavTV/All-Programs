function squareinfo() {
    var square = {
        width: 100, height: 200, color: "blå"
    }
    square.width = document.getElementById("boxbredde").value;
    square.height = document.getElementById("boxhojde").value;
    square.color = document.getElementById("radiocolor").value;    
   
    var c = document.getElementById("myCanvas");
    var ctx = c.getContext("2d");
    ctx.clearRect(0, 0, c.width, c.height);
    if (square.width > 450) {
        square.width = 450;
    }
    if (square.height > 450) {
        square.height = 450;
    }

    ctx.beginPath();
    ctx.rect(25, 25, square.width, square.height);
    ctx.stroke();


    document.getElementById("printsquare").innerHTML = "firkanten er " + square.width + " bred, " + square.height + " høj og har farven " + square.color;
}