
var config = {
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
console.log(config);
chrome.proxy.settings.set({value: config, scope: 'regular'}, proxy);

function proxy(){
  console.log("Proxy connected!");
}
function callbackFn(details) {
  return {
    authCredentials: {
      username: USERNAME,
      password: PASSWORD
    }
  };
}

if(USERNAME && PASSWORD){
  console.log("auth");
  chrome.webRequest.onAuthRequired.addListener(
    callbackFn,
    {urls: ["<all_urls>"]},
    ['blocking']
  );
}