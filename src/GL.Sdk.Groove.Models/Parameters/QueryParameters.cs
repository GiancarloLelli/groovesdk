using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Sdk.Groove.Models.Parameters
{
    public enum CatalogType
    {
        Albums = 0,
        Tracks = 1,
        Artists = 2
    }

    public enum BrowseType
    {
        Album = 0,
        Artist = 1
    }

    public enum FilterType
    {
        Albums = 0,
        Tracks = 1,
        Artists = 2,
        Playlists = 3
    }
    public enum PictureResizeMode
    {
        Letterbox = 1,
        Crop = 2,
        Square = 3
    }

    public enum PlaybackType
    {
        Stream = 0,
        Preview = 1
    }

    public enum CatalogSortingType
    {
        ReleaseDate = 0,
        AllTimePlayCount = 1,
        MostPopular = 2
    }

    public enum NamespaceType
    {
        Music = 0
    }

    public enum DeepLinkAction
    {
        View = 1,
        Play = 2,
        AddToCollection = 3,
        Buy = 4
    }

    public enum DeepLinkTarget
    {
        App = 1,
        Web = 2
    }

    public enum ExtrasParameters
    {
        Albums = 0,
        TopTracks = 1,
        ArtistDetails = 2,
        Tracks = 3,
        AlbumDetails = 4
    }

    public enum SearchSource
    {
        Catalog = 0,
        Collection = 1
    }
}
