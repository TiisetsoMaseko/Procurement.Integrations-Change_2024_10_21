namespace MSprocure.Middleware
{
    public class ApiKeyMiddleware
    {
        #pragma warning disable CS8602, CS8601, IDE1006
        private readonly RequestDelegate _next;
        private const string APIKEYNAME = "ApiKey";
        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                throw new UnauthorizedAccessException("Api Key was not provided. Please provide a valid API Key.");
            }

            var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = appSettings.GetValue<string>(APIKEYNAME);
            if (!apiKey.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 401;
                throw new UnauthorizedAccessException("Unauthorized client. API Key provided is not valid.");
            }
            await _next(context);
        }
        #pragma warning restore CS8602, CS8601, IDE1006
    }
}
