
#nullable enable

namespace Gradium
{
    public sealed partial class GradiumClient
    {
        /// <inheritdoc cref="GradiumClient(global::System.Net.Http.HttpClient?, global::System.Uri?, global::System.Collections.Generic.List{global::Gradium.EndPointAuthorization}?, bool)"/>

        public GradiumClient(
            string apiKey,
            global::System.Net.Http.HttpClient? httpClient = null,
            global::System.Uri? baseUri = null,
            global::System.Collections.Generic.List<global::Gradium.EndPointAuthorization>? authorizations = null,
            bool disposeHttpClient = true) : this(httpClient, baseUri, authorizations, disposeHttpClient)
        {
            Authorizing(HttpClient, ref apiKey);

            AuthorizeUsingApiKeyInHeader(apiKey);

            Authorized(HttpClient);
        }

        partial void Authorizing(
            global::System.Net.Http.HttpClient client,
            ref string apiKey);
        partial void Authorized(
            global::System.Net.Http.HttpClient client);

    }
}