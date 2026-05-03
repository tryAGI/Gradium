namespace Gradium.IntegrationTests;

[TestClass]
public partial class Tests
{
    private static GradiumClient GetAuthenticatedClient()
    {
        var apiKey =
            Environment.GetEnvironmentVariable("GRADIUM_API_KEY") is { Length: > 0 } apiKeyValue
                ? apiKeyValue
                : throw new AssertInconclusiveException("GRADIUM_API_KEY environment variable is not found.");

        var client = new GradiumClient(apiKey);
        
        return client;
    }
}
