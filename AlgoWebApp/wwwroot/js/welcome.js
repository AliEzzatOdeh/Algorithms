var txt;
var textXAxis = 15;
var i;
var dashLen;
var dashOffset;
var speed = 20;

var canvas = document.getElementById("myCanvas");
var ctx = canvas.getContext("2d");
ctx.font = "20px Comic Sans MS, cursive, TSCu_Comic, sans-serif";
ctx.lineWidth = 4;
ctx.lineJoin = "round";
ctx.globalAlpha = 2 / 3;
ctx.strokeStyle = ctx.fillStyle = "#1f2f90";

function writeTextAnimated(textToWrite) {
    txt = textToWrite;
    i = 0;
    dashOffset = 100;
    dashLen = 100;
    loop();
}


function loop() {
    ctx.clearRect(textXAxis, 0, 60, 150);
    ctx.setLineDash([dashLen - dashOffset, dashOffset - speed]); // create a long dash mask
    dashOffset -= speed; // reduce dash length
    ctx.strokeText(txt[i], textXAxis, canvas.height / 2); // stroke letter

    if (dashOffset > 0) requestAnimationFrame(loop); // animate
    else {
        ctx.fillText(txt[i], textXAxis, canvas.height / 2); // fill final letter
        dashOffset = dashLen; // prep next char
        textXAxis += ctx.measureText(txt[i++]).width + ctx.lineWidth * Math.random();
        ctx.setTransform(1, 0, 0, 1, 0, 1); // random y-delta
        //ctx.rotate(0.005); // random rotation
        if (i < txt.length) requestAnimationFrame(loop);
    }
};


writeTextAnimated("Welcome to Algorithms");