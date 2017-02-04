using Microsoft.SDK.Groove.Client.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Microsoft.SDK.Groove.Client
{
    public sealed class GrooveMusicClient
    {
        private readonly string m_clientId;
        private readonly string m_secret;
        private readonly RegionInfo m_culture;
        private readonly Lazy<GrooveHttpClient> m_client;

        public GrooveMusicClient(string clientId, string clientSecret)
        {
            m_clientId = clientId;
            m_secret = clientSecret;
            m_culture = new RegionInfo("us");
            m_client = new Lazy<GrooveHttpClient>(() => new GrooveHttpClient(m_clientId, m_secret));
        }

        public GrooveMusicClient(string clientId, string clientSecret, RegionInfo locale)
        {
            m_culture = locale;
            m_clientId = clientId;
            m_secret = clientSecret;
            m_client = new Lazy<GrooveHttpClient>(() => new GrooveHttpClient(m_clientId, m_secret));
        }
    }
}
