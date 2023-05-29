using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

namespace Toolset
{
    public class MetaWebRequest
    {
        public static async Task<T> Get<T>(string url, Dictionary<string, string> header = null)
            where T : MetaResponse
        {
            try
            {
                using var webRequest = UnityWebRequest.Get(url);

                if (header != null)
                    foreach (var item in header)
                        webRequest.SetRequestHeader(item.Key, item.Value);

                var operation = webRequest.SendWebRequest();

                while (!operation.isDone) await Task.Delay(10);

                return webRequest.result == UnityWebRequest.Result.Success ?
                    JsonConvert.DeserializeObject<T>(webRequest.downloadHandler.text) :
                    ErrorResponse<T>(webRequest.error);
            }
            catch (Exception ex)
            {
                return ErrorResponse<T>(ex.Message);
            }
        }

        public static async Task<T> Post<T>(string url, Dictionary<string, string> header = null, WWWForm forData = null)
            where T : MetaResponse
        {
            try
            {
                using var webRequest = UnityWebRequest.Post(url, forData);

                if (header != null)
                    foreach (var item in header)
                        webRequest.SetRequestHeader(item.Key, item.Value);

                var operation = webRequest.SendWebRequest();

                while (!operation.isDone) await Task.Delay(10);

                return webRequest.result == UnityWebRequest.Result.Success ?
                    JsonConvert.DeserializeObject<T>(webRequest.downloadHandler.text) :
                    ErrorResponse<T>(webRequest.error);
            }
            catch (Exception ex)
            {
                return ErrorResponse<T>(ex.Message);
            }
        }

        private static TResponse ErrorResponse<TResponse>(string message) where TResponse : MetaResponse =>
            new MetaResponse(-1, message) as TResponse;
    }

}