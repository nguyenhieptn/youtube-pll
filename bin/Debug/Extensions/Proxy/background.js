chrome.storage.local.get(["ytbCk"], function(result){
    if(result.ytbCk){
        try{
            var json = result.ytbCk;
            // let cookies = JSON.parse(atob(json));
            // importCK(cookies);
        }catch(e){
            console.log(e);
        }
    }
});

var urls = {
    "accounts":"https://accounts.google.com",
    "accountsyoutube":"https://accounts.youtube.com",
    "ogs":"https://ogs.google.com",
    "clients4":"https://clients4.google.com",
    "0.client-channel":"https://0.client-channel.google.com",
    "contacts":"https://contacts.google.com",
    "hangouts":"https://hangouts.google.com",
    "myaccount":"https://myaccount.google.com",
    "mail":"https://mail.google.com",
    "youtube":"https://www.youtube.com",
};


function getCk(cookies, key, callback){
    if(key.length == 0){
        callback(cookies);
        return;
    }
    let keys = key.splice(1);
    key = key[0];
    chrome.cookies.getAll({url:urls[key]},(cks)=>{
        cookies[key] = cks;
        return getCk(cookies, keys, callback);
    });
}

chrome.runtime.onMessage.addListener(function (request, sender, sendResponse) {
    switch (request.action) {
        case "getCk": {
            let keys = Object.keys(urls);
            let cks = {};
            getCk(cks, keys, function(cookies){
                console.log(cookies);
                let code = btoa(JSON.stringify(cookies));
                sendResponse(code);
            });
            return true;
            break;
        }
        case "importCk" : {
            try {                
                chrome.storage.local.set({"ytbCk":request.cookies}, function() {
                    let cookies = JSON.parse(atob(request.cookies));
                    console.log(cookies);
                    let keys = Object.keys(urls);
                    importKey(cookies, keys);
                    sendResponse(true);
                });
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
} catch(e) {}
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

function importKey(cookies,key){
    if(key.length == 0){
       return;  
    }
    let keys = key.splice(1);
    key = key[0];
    try{
        importCK(cookies[key], urls[key]);
    }catch(e){
        console.log(e);
    }
}

function importCK(cookie, url){    
    if(cookie.length == 0) return;
    let cookies = cookie.splice(1);
    try {
        cookie = cookie[0];
        var temp = {
            url: url,
            domain: cookie.domain,
            name: cookie.name,
            value: cookie.value,
            path: cookie.path
        };
        try{
            // chrome.cookies.set(temp, function(ck){
            //     importCK(cookies, url);
            // });
            chrome.cookies.remove({
                url:url,
                name:cookie.name
            },function(){                    
                chrome.cookies.set(temp, function(ck){
                    importCK(cookies, url);
                });
            });
        } catch (e) {
            console.log(e);
        }
    } catch (e) {
        console.log(e);
    }
}