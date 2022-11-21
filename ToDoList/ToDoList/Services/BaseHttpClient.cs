﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;
using ToDoList.Services.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace ToDoList.Services
{
    public class BaseHttpClient : IBaseHttpClient
    {
        public async Task<T> Get<T>(string url,
            IDictionary<string, string> headers = null,
            IDictionary<string, string> parameters = null)
        {
            var result = await SendRequest(HttpMethod.Get, url, null, headers, parameters).ConfigureAwait(false);
            return await Deserialize<T>(result).ConfigureAwait(false);
        }

        public Task<HttpResponseMessage> Post(string url,
            object data = null,
            IDictionary<string, string> headers = null)
        {
            return SendRequest(HttpMethod.Post, url, data, headers);
        }

        public async Task<T> Post<T>(string url,
            object data = null,
            IDictionary<string, string> headers = null)
        {
            var result = await SendRequest(HttpMethod.Post, url, data, headers).ConfigureAwait(false);
            return await Deserialize<T>(result).ConfigureAwait(false);
        }

        public Task<HttpResponseMessage> Delete(string url,
            object data = null,
            IDictionary<string, string> headers = null)
        {
            return SendRequest(HttpMethod.Delete, url, data, headers);
        }

        private async Task<HttpResponseMessage> SendRequest(
            HttpMethod method,
            string url,
            object data = null,
            IDictionary<string, string> headers = null,
            IDictionary<string, string> parameters = null)
        {
            HttpResponseMessage result;

            using (var client = new HttpClient())
            {
                var requestMessage = GetHttpRequestMessage(method, url, headers, parameters);
                requestMessage.Content = GetMessageContent(data);

                result = await client.SendAsync(requestMessage);
                await ErrorCheck(result);
            }

            return result;
        }

        private async Task<T> Deserialize<T>(HttpResponseMessage result)
        {
            var content = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
            return !string.IsNullOrEmpty(content) ? JsonConvert.DeserializeObject<T>(content) : default(T);
        }

        private static HttpRequestMessage GetHttpRequestMessage(HttpMethod method,
            string resource,
            IDictionary<string, string> headers = null,
            IDictionary<string, string> parameters = null)
        {
            var message = new HttpRequestMessage(method, resource);
            message.Headers.Accept.Clear();
            message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (headers != null)
            {
                foreach (var (key, value) in headers)
                {
                    message.Headers.Add(key, value);
                }
            }

            if (parameters != null)
            {
                foreach (var (key, value) in parameters)
                {
                    message.Properties.Add(key, value);
                }
            }

            return message;
        }

        private HttpContent GetMessageContent(object data)
        {
            return data == null ? null : new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
        }

        private async Task ErrorCheck(HttpResponseMessage result)
        {
            if (!result.IsSuccessStatusCode)
            {
                var errorMessage = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                throw new ApiException($"Error when calling {result.RequestMessage.Method.ToString().ToUpperInvariant()}.",
                    result.StatusCode,
                    errorMessage,
                    null);
            }
        }
    }
}
