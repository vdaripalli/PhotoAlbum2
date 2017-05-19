using System.Collections.Generic;

namespace PhotoAlbum.Application
{
    public interface IAlbumProcessor
    {
        List<Photo> GetAlbumPhotos(string albumId);
        List<Photo> GetAllPhotos();
    }

    public class AlbumProcessor : IAlbumProcessor
    {
        private readonly IBaseHttpClient _baseHttpClient;

        public AlbumProcessor(IBaseHttpClient baseHttpClient)
        {
            _baseHttpClient = baseHttpClient;
        }
        public List<Photo> GetAlbumPhotos(string albumId)
        {
            //application code
            string baseUrl = @"https://jsonplaceholder.typicode.com/photos";
            baseUrl = baseUrl + "?albumId=" + albumId;

            var photos = _baseHttpClient.Get<List<Photo>>(baseUrl).Result;
            return photos;
        }

        public List<Photo> GetAllPhotos()
        {
            //application code
            string baseUrl = @"https://jsonplaceholder.typicode.com/photos";

            var photos = _baseHttpClient.Get<List<Photo>>(baseUrl).Result;
            return photos;
        }
    }
}
