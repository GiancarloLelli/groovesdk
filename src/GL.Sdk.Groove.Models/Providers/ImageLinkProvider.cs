using GL.Sdk.Groove.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Sdk.Groove.Models.Providers
{
    public class ImageLinkProvider
    {
        private const string m_base = "http://musicimage.xboxlive.com/content/";

        public Uri GetDefaultImageUri(string id, string locale) => new Uri($"{m_base}{id}/image?locale={locale}&mode=scale");

        public Uri GetCustomImageUri(string id, string locale, PictureResizeMode mode, int width, int height)
        {
            var m_custom = $"{m_base}{id}/image?locale={locale}";

            switch (mode)
            {
                case PictureResizeMode.Letterbox:
                    m_custom = string.Join("&", m_custom, "mode=letterbox", $"w={width}", $"h={height}");
                    break;
                case PictureResizeMode.Crop:
                    m_custom = string.Join("&", m_custom, "mode=crop", $"w={width}", $"h={height}");
                    break;
                case PictureResizeMode.Square:
                    m_custom = string.Join("&", m_custom, $"w={width}", $"h={width}");
                    break;
            }

            return new Uri(m_custom);
        }
    }
}
