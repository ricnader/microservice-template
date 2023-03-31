using Microsoft.AspNetCore.Http;
using Microsoft.IO;
using Serilog;
using Serilog.Events;
using System.Diagnostics;
using System.Text;

namespace Application.Middleware
{
    public class RequestResponseSerilLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;

        public RequestResponseSerilLogMiddleware(RequestDelegate next)
        {
            _next = next;
            _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await SaveLog(context);
        }

        async Task SaveLog(HttpContext context)
        {
            var elapsedMs = GetElapsedMilliseconds(Stopwatch.GetTimestamp(), Stopwatch.GetTimestamp());

            String requestText = await getRequestBody(context);

            var originalBodyStream = context.Response.Body;

            await using var responseBody = _recyclableMemoryStreamManager.GetStream();

            context.Response.Body = responseBody;

            await _next.Invoke(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            String responseText = await new StreamReader(context.Response.Body, Encoding.UTF8).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);


            await responseBody.CopyToAsync(originalBodyStream);

            var level = LogEventLevel.Information;

            Log.Write(level, "Request", requestText, elapsedMs);
            Log.Write(level, "Response", responseText, elapsedMs);
        }

        private async Task<String> getRequestBody(HttpContext context)
        {
            context.Request.EnableBuffering();

            await using var requestStream = _recyclableMemoryStreamManager.GetStream();
            await context.Request.Body.CopyToAsync(requestStream);

            String reqBody = ReadStreamInChunks(requestStream);

            context.Request.Body.Position = 0;

            return reqBody;
        }

        private static string ReadStreamInChunks(Stream stream)
        {
            const int readChunkBufferLength = 4096;

            stream.Seek(0, SeekOrigin.Begin);

            using var textWriter = new StringWriter();
            using var reader = new StreamReader(stream);

            var readChunk = new char[readChunkBufferLength];
            int readChunkLength;

            do
            {
                readChunkLength = reader.ReadBlock(readChunk,
                                                   0,
                                                   readChunkBufferLength);
                textWriter.Write(readChunk, 0, readChunkLength);

            } while (readChunkLength > 0);

            return textWriter.ToString();
        }

        private static double GetElapsedMilliseconds(long start, long stop)
        {
            return (stop - start) * 1000 / (double)Stopwatch.Frequency;
        }

    }
}
