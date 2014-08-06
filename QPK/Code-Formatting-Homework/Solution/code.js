var browserName = navigator.appName
var addScroll = false;
var page_X = 0;
var page_Y = 0;
var theLayer;

if ((navigator.userAgent.indexOf("MSIE 5") > 0) || (navigator.userAgent.indexOf("MSIE 6")) > 0) {
    addScroll = true;
}

document.onmousemove = mouseMove;
if (browserName === "Netscape") {
    document.captureEvents(Event.MOUSEMOVE)
};

function mouseMove(evn) {
    if (browserName === "Netscape") {
        page_X = evn.pageX - 5;
        page_Y = evn.pageY;
        if (document.layers['ToolTip'].visibility === 'show') {
            PopTip();
        }
    } else {
        page_X = event.x - 5;
        page_Y = event.y;
        if (document.all['ToolTip'].style.visibility === 'visible') {
            PopTip();
        }
    }
}

function popTip() {
    if (browserName === "Netscape") {
        theLayer = document.layers["ToolTip"];
        if ((page_X + 120) > window.innerWidth) {
            page_X = window.innerWidth - 150;
        }

        theLayer.left = page_X + 10;
        theLayer.top = page_Y + 15;
        theLayer.visibility = "show";
    } else {
        theLayer = document.all["ToolTip"];

        if (theLayer) {
            page_X = event.x - 5;
            page_Y = event.y;
            if (addScroll) {
                page_X = page_X + document.body.scrollLeft;
                page_Y = page_Y + document.body.scrollTop;
            }

            if ((page_X + 120) > document.body.clientWidth) {
                page_X = page_X - 150;
            }

            theLayer.style.pixelLeft = page_X + 10;
            theLayer.style.pixelTop = page_Y + 15;
            theLayer.style.visibility = "visible";
        }
    }
}

function hideTip() {
    var args = hideTip.arguments;
    if (browserName === "Netscape") {
        document.layers["ToolTip"].visibility = "hide";
    } else {
        document.all["ToolTip"].style.visibility = "hidden";
    }
}

function hideMenu1() {
    if (browserName === "Netscape") {
        document.layers["menu1"].visibility = "hide";
    } else {
        document.all["menu1"].style.visibility = "hidden";
    }
}

function showMenu1() {
    if (browserName === "Netscape") {
        theLayer = document.layers["menu1"];
        theLayer.visibility = "show";
    } else {
        theLayer = document.all["menu1"];
        theLayer.style.visibility = "visible";
    }
}

function hideMenu2() {
    if (browserName === "Netscape") {
        document.layers["menu2"].visibility = "hide";
    } else {
        document.all["menu2"].style.visibility = "hidden";
    }
}

function showMenu2() {
    if (browserName === "Netscape") {
        theLayer = document.layers["menu2"];
        theLayer.visibility = "show";
    } else {
        theLayer = document.all["menu2"];
        theLayer.style.visibility = "visible";
    }
}