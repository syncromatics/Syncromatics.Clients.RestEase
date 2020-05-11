using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using RestEase;

namespace Syncromatics.Clients.RestEase
{
    /// <summary>
    /// Default implementation of IResponseDeserializer, using RestEase.JsonResponseDeserializer
    /// </summary>
    /// <remarks>
    /// This implementation throws <see cref="ClientException" />s for unsuccessful responses, including deserializing <see cref="ProblemDetails" />
    /// </remarks>
    public class BaseJsonResponseDeserializer : JsonResponseDeserializer
    {
        /// <summary>
        /// Deserializes a successful response
        /// </summary>
        /// <param name="content"></param>
        /// <param name="response"></param>
        /// <param name="info"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual T DeserializeSuccessfulResult<T>(string content, HttpResponseMessage response, ResponseDeserializerInfo info)
        {
            return base.Deserialize<T>(content, response, info);
        }

        /// <summary>
        /// Deserializes an unsuccessful response and throws a <see cref="ClientException" /> where applicable
        /// </summary>
        /// <param name="content"></param>
        /// <param name="response"></param>
        /// <param name="info"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual T DeserializeUnsuccessfulResult<T>(string content, HttpResponseMessage response, ResponseDeserializerInfo info)
        {
            if (string.IsNullOrEmpty(content))
            {
                throw new ClientException<HttpResponseMessage>(response.ReasonPhrase, response.StatusCode, response);
            }

            if (response.Content.Headers.ContentType.MediaType == "application/problem+json")
            {
                var problemDetails = base.Deserialize<ValidationProblemDetails>(content, response, info);
                throw new ClientException<ProblemDetails>(problemDetails.Title, response.StatusCode, problemDetails);
            }

            throw new ClientException<HttpResponseMessage>(content, response.StatusCode, response);
        }

        public override T Deserialize<T>(string content, HttpResponseMessage response, ResponseDeserializerInfo info)
        {
            if (response.IsSuccessStatusCode)
            {
                return DeserializeSuccessfulResult<T>(content, response, info);
            }

            return DeserializeUnsuccessfulResult<T>(content, response, info);
        }
    }

}
