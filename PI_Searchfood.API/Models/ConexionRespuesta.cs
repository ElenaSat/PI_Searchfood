using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Web;

namespace PI_Searchfood.API.Models
{
    public class ConexionRespuesta
    {

        public string APIRequests(string url, object request, Methods method, ContentType content_type) {
            try
            {
                HttpWebRequest httpRequest;
                httpRequest = (HttpWebRequest)WebRequest.Create(url);
                httpRequest.Method = method == Methods.POST ? "POST" :
                                    method == Methods.GET ? "GET" : string.Empty;

                httpRequest.Timeout = 320000;
                httpRequest.ContentType = content_type == ContentType.URL_ENCODED ? "application/x-www-form-urlencoded" :
                                        content_type == ContentType.JSON ? "application/json" : string.Empty;

                if (request != null) {
                    using (var streamWriter = new StreamWriter (httpRequest.GetRequestStream())) {
                        streamWriter.Write(JsonConvert.SerializeObject(request));
                        streamWriter.Flush();
                        streamWriter.Close();

                    }

                }
                HttpWebResponse resp;
                resp = (HttpWebResponse)httpRequest.GetResponse();

                string json = string.Empty;

                if (resp.StatusCode.Equals(HttpStatusCode.OK)) {
                    using (var streamReader = new StreamReader(resp.GetResponseStream())) {

                        json = streamReader.ReadToEnd();
                    }
                   
                }
                return json;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }

    public enum Methods {
        POST, GET
    }

    public enum ContentType {

        URL_ENCODED,
        JSON
    }
}