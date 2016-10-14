﻿namespace Burble.Events
{
   using System;
   using System.Net.Http;

   public class HttpClientResponseReceived
   {
      public string EventType => GetType().Name;

      public DateTimeOffset Timestamp { get; set; }

      public string Uri { get; set; }

      public string Method { get; set; }

      public long DurationMs { get; set; }

      public int StatusCode { get; set; }

      public static HttpClientResponseReceived Create(HttpResponseMessage response, long durationMs)
      {
         return new HttpClientResponseReceived
         {
            Timestamp = DateTimeOffset.UtcNow,
            Uri = response.RequestMessage.RequestUri.LocalPath,
            Method = response.RequestMessage.Method.Method,
            DurationMs = durationMs,
            StatusCode = (int)response.StatusCode
         };
      }
   }
}