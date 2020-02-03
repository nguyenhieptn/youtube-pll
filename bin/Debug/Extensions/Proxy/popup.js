window.addEventListener("load", function (e) {
    chrome.runtime.sendMessage({
        action: "getCk",
    }, function (response) {
        console.log(response);
        document.querySelector("#cookies").value = response;
    });
});

document.querySelector("#import").addEventListener("click", function (e) {
    var cookies = document.querySelector("#cookies").value;
    if (cookies.length === 0) return false;
    let that = this;
    chrome.runtime.sendMessage({
        action: "importCk",
        cookies: cookies
    }, function (response) {
        if(response) {
            that.innerHTML = "Imported";
            setTimeout(() => {
                that.innerHTML = "Import";
            }, 1500);
        }
    });
});
document.querySelector("#copy").addEventListener("click", function (e) {
    var element = document.querySelector("#cookies");
    element.select();
    document.execCommand('copy');
    this.innerHTML = "Copied";
    setTimeout(()=>{
        this.innerHTML = "Copy";
    },1500);
});