
#nullable enable

namespace Gradium
{
    public sealed partial class GradiumClient
    {

        /// <inheritdoc/>
        public void AuthorizeUsingApiKeyInHeader(
            string apiKey)
        {
            apiKey = apiKey ?? throw new global::System.ArgumentNullException(nameof(apiKey));

            for (var i = Authorizations.Count - 1; i >= 0; i--)
            {
                var __authorization = Authorizations[i];
                if (__authorization.Type == "ApiKey" &&
                    __authorization.Location == "Header" &&
                    __authorization.Name == "x-api-key")
                {
                    Authorizations.RemoveAt(i);
                }
            }

            Authorizations.Add(new global::Gradium.EndPointAuthorization
            {
                Type = "ApiKey",
                SchemeId = "ApikeyXApiKey",
                Location = "Header",
                Name = "x-api-key",
                Value = apiKey,
            });
        }
    }
}