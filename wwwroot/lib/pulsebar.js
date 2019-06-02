var initBar = function (selector, barHeight) {
    $(selector).css("height", barHeight);
    let innerBar = document.createElement("div");
    innerBar.setAttribute("class", "inner-bar");
    $(innerBar).attr("data-barheight", barHeight);
    selector.appendChild(innerBar);
    return innerBar;
}
var setBarValue = function (selector, value) {
    let inner = $(selector).find(".inner-bar")[0];
    var barheight = $(inner).attr("data-barheight");
    $(inner).css("height", value);
    $(inner).css("top", barheight - value);
}


