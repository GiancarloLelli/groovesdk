using GL.Sdk.Groove.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Sdk.Groove.Models.Providers
{
    public class ImageLinkProvider
    {
        private const string m_base = "http://musicimage.xboxlive.com/content/";

        public Uri GetDefaultImageUri(string id, string locale)
        {
            return new Uri(string.Format("{0}{1}/image?locale={2}&mode=scale", m_base, id, locale));
        }

        public Uri GetCustomImageUri(string id, string locale, PictureResizeMode mode, int width, int height)
        {
            Uri custom = new Uri(string.Format("{0}{1}/image?locale={2}", m_base, id, locale));

            switch (mode)
            {
                case PictureResizeMode.Letterbox:
                    string.Join("&", custom.AbsoluteUri, "mode=letterbox", string.Format("w={0}", width), string.Format("h={0}", height));
                    break;
                case PictureResizeMode.Crop:
                    string.Join("&", custom.AbsoluteUri, "mode=crop", string.Format("w={0}", width), string.Format("h={0}", height));
                    break;
                case PictureResizeMode.Square:
                    string.Join("&", custom.AbsoluteUri, string.Format("w={0}", width), string.Format("h={0}", width));
                    break;
            }

            return custom;
        }
    }
}
