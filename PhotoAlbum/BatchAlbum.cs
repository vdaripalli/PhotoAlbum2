using System;
using System.Collections.Generic;
using PhotoAlbum.Application;

namespace PhotoAlbum
{
    public interface IBatchAlbum
    {
        ReturnCode Run(string[] args);
        void PrintPhotos(List<Photo> photos);
    }

    public class BatchAlbum : IBatchAlbum
    {
        private readonly IAlbumProcessor _albumProcessor;

        public BatchAlbum(IAlbumProcessor albumProcessor)
        {
            _albumProcessor = albumProcessor;
        }
        public ReturnCode Run(string[] args)
        {
            if (args.Length > 1)
            {
                Console.WriteLine("Incorrect Usage. Correct usage photos for specific album 'PhotoAlbum <int:albumId>' or all photos 'PhotoAlbum'");
                return ReturnCode.Failure;
            }
            var photos = args.Length == 0 ? _albumProcessor.GetAllPhotos() : _albumProcessor.GetAlbumPhotos(args[0]);
            PrintPhotos(photos);
            return 0;
        }

        public void PrintPhotos(List<Photo> photos)
        {
            foreach (var photo in photos)
            {
                Console.WriteLine(photo.Id + " " + photo.Title);
            }
        }

    }
}