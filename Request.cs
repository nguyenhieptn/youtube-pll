using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Http;


public class Request
{
    private static readonly HttpClient client = new HttpClient();
    string responseText;
    object response;
    WebHeaderCollection responseHeaders;
    int responseCode;

    String[] headers;
    string method;
    string url;
    string data;

    public Request(string method, string url, string data = null, Dictionary<string, string> headers = null)
    {
        this.Method = method;
        this.Url = url;

        Stream dataStream;
        WebRequest request = WebRequest.Create(url);

        request.Method = method;

        if (headers != null)
        {
            foreach (var item in headers)
            {
                request.Headers.Add(item.Key, item.Value);
            }
        }

        if (data != null)
        {
            string postData = data;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
        }

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        string responseFromServer = reader.ReadToEnd();
        reader.Close();
        dataStream.Close();
        response.Close();
        this.ResponseHeaders = response.Headers;
        this.ResponseText = responseFromServer;
        this.ResponseCode = (int)response.StatusCode;
    }

    public string ResponseText { get => responseText; set => responseText = value; }
    public WebHeaderCollection ResponseHeaders { get => responseHeaders; set => responseHeaders = value; }
    public object Response { get => response; set => response = value; }
    public int ResponseCode { get => responseCode; set => responseCode = value; }
    public string Method { get => method; set => method = value; }
    public string Url { get => url; set => url = value; }
    public string Data { get => data; set => data = value; }
    public string[] Headers { get => headers; set => headers = value; }
}

