using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMoq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PhotoAlbum.Application;

namespace PhotoAlbum.Test
{
    [TestClass]
    public class PhotoAlbumProcessorTest
    {
        private AutoMoqer _mocker;

        [TestInitialize]
        public void BeforeTest()
        {
            _mocker = new AutoMoqer();
        }

        [TestMethod]
        public void GetAlbumPhotos_Should_CallBaseHttpClientGet()
        {
            //Arrange
            _mocker.GetMock<IBaseHttpClient>().Setup(x => x.Get<List<Photo>>(It.IsAny<string>())).ReturnsAsync(new List<Photo>() { new Photo() { Id=1, Title = "test1"} });

            //Act
            var albumProcessor = _mocker.Create<AlbumProcessor>();
            var result = albumProcessor.GetAlbumPhotos("1");

            //Assert
            _mocker.GetMock<IBaseHttpClient>().Verify(x=>x.Get<List<Photo>>(It.IsAny<string>()));
        }

        [TestMethod]
        public void GetAllPhotos_Should_CallBaseHttpClientGet()
        {
            //Arrange
            _mocker.GetMock<IBaseHttpClient>().Setup(x => x.Get<List<Photo>>(It.IsAny<string>())).ReturnsAsync(new List<Photo>() { new Photo() { Id = 1, Title = "test1" } });

            //Act
            var albumProcessor = _mocker.Create<AlbumProcessor>();
            var result = albumProcessor.GetAllPhotos();

            //Assert
            _mocker.GetMock<IBaseHttpClient>().Verify(x => x.Get<List<Photo>>(It.IsAny<string>()));
        }
    }
}
