//获取url参数
function GetParam() {
    var url = location.search; //获取url中"?"符后的字串
    var theRequest = new Object();
    if (url.indexOf("?") != -1) {
        var str = url.substr(1);
        strs = str.split("&");
        for (var i = 0; i < strs.length; i++) {
            theRequest[strs[i].split("=")[0]] = unescape(strs[i].split("=")[1]);
        }
    }
    return theRequest;
}
//获取cookie
function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i].trim();
        if (c.indexOf(name) == 0) { return c.substring(name.length, c.length); }
    }
    return "";
}
//设置cookie
function setCookie(cname, cvalue, exseconds, path) {
    var d = new Date();
    d.setTime(d.getTime() + (exseconds * 1000));
    var expires = "expires=" + d.toGMTString();
    path = path == "" ? "" : ";path=" + path;
    document.cookie = cname + "=" + cvalue + "; " + expires + path;
}
//清除cookie  
function clearCookie(name, path) {
    if (path === undefined) {
        path="/"
    }
    setCookie(name, "", -1,path);
}