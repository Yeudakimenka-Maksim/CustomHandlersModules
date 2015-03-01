(function () {
    var xhr = new XMLHttpRequest();
    var url = "/Task2.CustomAuthenticationModule/Handlers/CheckCookies.ashx";
    //var url = "/Handlers/CheckCookies.ashx";
    xhr.open("POST", url, true);
    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4 && xhr.status === 200)
            if (xhr.responseText !== "no cookies")
                task2.showUI();
    };
    xhr.send(null);
})();

var task2 = task2 || {};

task2.showUI = function () {
    document.getElementById("link-login").style.display = "none";
    document.getElementById("link-logoff").style.display = "inline";
    document.getElementById("link-load-data").style.display = "block";
};

task2.hideUI = function () {
    document.getElementById("link-login").style.display = "inline";
    document.getElementById("link-logoff").style.display = "none";
    document.getElementById("link-load-data").style.display = "none";
};

task2.showLoginForm = function () {
    document.getElementById("form-login").style.display = "inline";
};

task2.logOff = function () {
    var xhr = new XMLHttpRequest();
    var url = "Handlers/LogOff.ashx";
    xhr.open("POST", url, true);
    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4 && xhr.status === 200)
            if (xhr.responseText === "logged off")
                task2.hideUI();
    }
    xhr.send(null);
};

task2.sendLoginData = function () {
    var username = document.getElementById("input-username").value;
    var password = document.getElementById("input-password").value;
    var query = "username=" + encodeURIComponent(username) + "&password=" + encodeURIComponent(password);
    var xhr = new XMLHttpRequest();
    var url = "/Task2.CustomAuthenticationModule/Handlers/Login.ashx";
    //var url = "/Handlers/Login.ashx";
    xhr.open("POST", url, true);
    //xhr.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4 && xhr.status === 200) {
            if (xhr.responseText === "logged in")
                task2.showUI();
            else
                alert(xhr.responseText);
        }
    };
    xhr.send(query);
    //return false;
};

task2.loadData = function () {
    var xhr = new XMLHttpRequest();
    var url = "Handlers/LoadData.ashx";
    xhr.open("GET", url, true);
    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4 && xhr.status === 200)
            document.getElementById("div-data").innerHTML = xhr.responseText;
    }
    xhr.send(null);
}

task2.JsonTree = function (json) {
    var tree = "<ul class='Container'> <li class='Node IsRoot IsLast ExpandClosed'> <div class='Expand'></div> <div class='Content'>JSON</div> <ul class='Container'>";
    for (prop in json) {
        var value = json[prop];
        if (typeof value == "object") {
            if (value == null) break;
            tree += "<li class='Node ExpandClosed'>" + prop + "<div class='Expand'></div><div class='Content'>" + task2.JsonTree(value) + "</div><ul class='Container'>";
        } else
            tree += "<li class='Node ExpandLeaf'>" + prop + " : " + value + "</li>";
    }
    return tree + "</ul> </li> </ul>";
};