//funkcja pobierajaca aktulany czas i wykorzystujaca go jako zegar
function CountingTime() {
    let today = new Date();

    let hour = today.getHours();
    if (hour < 10)
        hour = "0" + hour;
    let minute = today.getMinutes();
    if (minute < 10)
        minute = "0" + minute;
    let second = today.getSeconds();
    if (second < 10)
        second = "0" + second;

    document.getElementById("clock").innerHTML = hour + ":" + minute + ":" + second;

    setTimeout("CountingTime()", 1000);
}
