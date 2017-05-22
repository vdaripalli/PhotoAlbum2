using AutoMoq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PhotoAlbum;
using PhotoAlbum.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.Test
{
    [TestClass]
    public class BatchAlbumTest
    {
        private AutoMoqer _mocker;

        [TestInitialize]
        public void BeforeTest()
        {
            _mocker = new AutoMoqer();
        }

        [TestMethod]
        public void RunBatchAlbum_Should_CallGetAllPhotos()
        {
            //Arrange
            string[] commandArgs = new string[0];

            //Act
            var batchAlbumRunner = _mocker.Create<BatchAlbum>();
            var result = batchAlbumRunner.Run(commandArgs);

            //Assert
            _mocker.GetMock<IAlbumProcessor>().Verify(x => x.GetAllPhotos());
        }

        [TestMethod]
        public void RunBatchAlbum_Should_CallGetAlbumPhotos()
        {
            //Arrange
            string[] commandArgs = new string[1];
            commandArgs[0] = "1";

            //Act
            var batchAlbumRunner = _mocker.Create<BatchAlbum>();
            var result = batchAlbumRunner.Run(commandArgs);

            //Assert
            _mocker.GetMock<IAlbumProcessor>().Verify(x => x.GetAlbumPhotos(It.IsAny<string>()));
        }
    }
}
