using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using RestEase;

namespace Syncromatics.Clients.RestEase
{
    /// <summary>
    /// Extensions to get RestEase clients for a type (Typically an interface)
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Gets a RestEase client
        /// </summary>
        /// <param name="rootUrl">Root URL on which to base client requests</param>
        /// <param name="responseDeserializer">Optional response deserializer implementation</param>
        /// <param name="requestModifier">Optional delegate called on every request</param>
        /// <typeparam name="TClient">Type of the RestEase-decorated interface</typeparam>
        /// <returns>Instance of the requested RestEase client</returns>
        public static TClient GetRestClient<TClient>(
            string rootUrl,
            ResponseDeserializer responseDeserializer = null,
            RequestModifier requestModifier = null)
        {
            return (TClient)typeof(TClient).GetRestClient(rootUrl, responseDeserializer, requestModifier);
        }

        /// <summary>
        /// Gets a RestEase client
        /// </summary>
        /// <param name="type">Type of the RestEase-decorated interface</param>
        /// <param name="rootUrl">Root URL on which to base client requests</param>
        /// <param name="responseDeserializer">Optional response deserializer implementation</param>
        /// <param name="requestModifier">Optional delegate called on every request</param>
        /// <returns>Instance of the requested RestEase client</returns>
        public static object GetRestClient(
            this Type type,
            string rootUrl,
            ResponseDeserializer responseDeserializer = null,
            RequestModifier requestModifier = null)
        {
            return new RestClient(rootUrl, requestModifier ?? NoopRequestModifier)
            {
                ResponseDeserializer = responseDeserializer ?? new BaseJsonResponseDeserializer(),
            }.For(type);
        }

        private static Task NoopRequestModifier(HttpRequestMessage request, CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
