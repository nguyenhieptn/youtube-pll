

chrome.runtime.onMessage.addListener(function (request, sender, sendResponse) {
    switch (request.action) {
        case "reload": {
            // window.open("https://myaccount.google.com/", '_blank').focus();
            sendResponse(true);
            return true;
            break;
        }
    }
});