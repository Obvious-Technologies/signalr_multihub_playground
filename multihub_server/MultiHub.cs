﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace multihub_server
{

    /// <summary>
    /// TODO: dynamic generate 
    /// </summary>
    public class MultiHub : MultiHubBase<IMultiClient>
    {
        protected override IEnumerable<Hub> GetHubs()
        {
            if (IsHubEnabled<Hello1Hub>())
                yield return Hello1Hub;
            if (IsHubEnabled<Hello1Hub>())
                yield return Hello2Hub;
        }

        public MultiHub(ILogger<MultiHub> logger, IServiceProvider provider) 
            : base(logger, provider)
        {
        }

        [HubMethodName("Hello1Hub_OnMessage")]
        public void Hello1Hub_OnMessage(string text)
        {
            Hello1Hub.OnMessage(text);
        }
        [HubMethodName("Hello2Hub_OnMessage")]
        public void Hello2Hub_OnMessage(string text)
        {
            Hello2Hub.OnMessage(text);
        }

        private Hello1Hub Hello1Hub => CreateHub<Hello1Hub, IHello1Client>();
        private Hello2Hub Hello2Hub => CreateHub<Hello2Hub, IHello2Client>();

    }

}