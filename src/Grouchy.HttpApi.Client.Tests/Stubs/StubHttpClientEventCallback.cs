﻿using System.Collections.Generic;
using System.Linq;
using Grouchy.HttpApi.Client.Abstractions.EventCallbacks;
using Grouchy.HttpApi.Client.Abstractions.Events;
using Grouchy.HttpApi.Client.Events;

namespace Grouchy.HttpApi.Client.Tests.Stubs
{
   public class StubHttpClientEventCallback : IHttpClientEventCallback
   {
      public List<IHttpClientEvent> Events { get; } = new List<IHttpClientEvent>();

      public HttpClientRequestInitiated[] RequestsInitiated => Events.OfType<HttpClientRequestInitiated>().ToArray();

      public HttpClientResponseReceived[] ResponsesReceived => Events.OfType<HttpClientResponseReceived>().ToArray();

      public HttpClientServerUnavailable[] ServersUnavailable => Events.OfType<HttpClientServerUnavailable>().ToArray();

      public HttpClientExceptionThrown[] ExceptionsThrown => Events.OfType<HttpClientExceptionThrown>().ToArray();

      public HttpClientTimedOut[] TimeOuts => Events.OfType<HttpClientTimedOut>().ToArray();

      public HttpClientRetryAttempt[] RetryAttempts => Events.OfType<HttpClientRetryAttempt>().ToArray();

      public virtual void Invoke(IHttpClientEvent @event)
      {
         Events.Add(@event);
      }
   }
}