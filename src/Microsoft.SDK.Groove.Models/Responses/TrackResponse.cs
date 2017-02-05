using Microsoft.SDK.Groove.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.SDK.Groove.Models.Responses
{
    public class TrackResponse : BaseModel
    {
        public DateTime ReleaseDate { get; set; }

        public TimeSpan Duration { get; set; }

        public int TrackNumber { get; set; }

        public bool IsExplicit { get; set; }

        public string Subtitle { get; set; }

        public AlbumModel Album { get; set; }

        public IEnumerable<string> Rights { get; set; }

        public Uri GetDeepLink(DeepLinkAction action, DeepLinkTarget target)
        {
            Uri link = new Uri(string.Format("http://music.xbox.com/Track/{0}", Id));

            switch (action)
            {
                case DeepLinkAction.View:
                    string.Join("?", link, "action=view");
                    break;
                case DeepLinkAction.Play:
                    string.Join("?", link, "action=play");
                    break;
                case DeepLinkAction.AddToCollection:
                    string.Join("?", link, "action=addtocollection");
                    break;
                case DeepLinkAction.Buy:
                    string.Join("?", link, "action=buy");
                    break;
            }

            switch (target)
            {
                case DeepLinkTarget.App:
                    string.Join("&", link, "target=app");
                    break;
                case DeepLinkTarget.Web:
                    string.Join("&", link, "target=web");
                    break;
            }

            return link;
        }
    }
}
