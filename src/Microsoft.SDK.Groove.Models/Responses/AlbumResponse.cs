﻿using Microsoft.SDK.Groove.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.SDK.Groove.Models.Responses
{
    public class AlbumsResponse : BaseModel
    {
        public string ReleaseDate { get; set; }

        public string Duration { get; set; }

        public string TrackCount { get; set; }

        public string IsExplicit { get; set; }

        public string LabelName { get; set; }

        public string AlbumType { get; set; }

        public TrackLookupResponse Tracks { get; set; }

        public Uri GetDeepLink(DeepLinkAction action, DeepLinkTarget target)
        {
            Uri link = new Uri(string.Format("http://music.xbox.com/Album/{0}", Id));

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
