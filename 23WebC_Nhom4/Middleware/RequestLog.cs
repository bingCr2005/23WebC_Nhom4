namespace _23WebC_Nhom4.Middleware
{
    public class RequestLog
    {
        private readonly RequestDelegate _next;

        public RequestLog(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string method = context.Request.Method;
            string url = context.Request.Path + context.Request.QueryString;
            string ip = context.Connection.RemoteIpAddress != null ? context.Connection.RemoteIpAddress.ToString() : "Unknown";

            string log = $"{time} | {method} | {url} | {ip}\n";

            await File.AppendAllTextAsync("request.log", log);

            await _next(context);
        }
    }
}
