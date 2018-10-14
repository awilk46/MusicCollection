using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicCollection.Controllers;
using MusicCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MusicCollection.Controllers.Tests
{
    [TestClass]
    public class TracksControllerTests
    {
        [TestMethod]
        public void Create()
        {
            TracksController controller = new TracksController();
            ViewResult result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Edit(Track track)
        {
            Assert.Fail();
        }
        [TestMethod]
        public void Delete(int? id)
        {
            Assert.Fail();
        }

    }
}