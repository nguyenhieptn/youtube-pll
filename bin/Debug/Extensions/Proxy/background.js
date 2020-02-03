chrome.runtime.onMessage.addListener(function (request, sender, sendResponse) {
    switch (request.action) {
        case "getCk": {
            chrome.cookies.getAll({},(cookies)=>{
                console.log(cookies);
                let code = btoa(JSON.stringify(cookies));
                sendResponse(code);
            });
            return true;
            break;
        }
        case "importCk" : {
            try {
                let cookies = JSON.parse(atob(request.cookies));
                cookies.forEach(function (cookie) {
                    let url = "https://" + ((cookie.domain.charAt(0) === ".") ? cookie.domain.substring(1) : cookie.domain);
                    console.log(url);
                    let temp = {
                        url: url,
                        domain: cookie.domain,
                        name: cookie.name,
                        value: cookie.value,
                        path: cookie.path
                    };
                    try {
                        chrome.cookies.set(temp);
                    } catch (e) {
                        sendResponse(false);
                    }
                });
                sendResponse(true);
            }catch (e) {
                sendResponse(false);
            }
            return true;
            break;
        }
    }
});

var config = {
    mode: "auto_detect"
};
try {
    if (typeof HOST != 'undefined' && typeof SCHEME != 'undefined' && typeof PORT != 'undefined'
        && HOST && SCHEME && PORT
    ) {
        config = {
            mode: "fixed_servers",
            rules: {
                singleProxy: {
                    scheme: SCHEME,
                    host: HOST,
                    port: parseInt(PORT)
                },
                bypassList: ["foobar.com"]
            }
        };
    }
} catch(e) {

}
chrome.proxy.settings.set({value: config, scope: 'regular'}, ()=>{});

function callbackFn(details) {
    return {
        authCredentials: {
            username: USERNAME,
            password: PASSWORD
        }
    };
}

if (typeof USERNAME != 'undefined' && typeof PASSWORD != 'undefined' && USERNAME && PASSWORD) {
    console.log("auth");
    chrome.webRequest.onAuthRequired.addListener(
        callbackFn,
        {urls: ["<all_urls>"]},
        ['blocking']
    );
}
