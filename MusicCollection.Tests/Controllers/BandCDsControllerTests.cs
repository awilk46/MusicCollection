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
    public class BandCDsControllerTests
    {

        [TestMethod]
        public void Create()
        {
            BandCDsController controller = new BandCDsController();
            ViewResult result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Edit(BandCD bandCD)
        {
            Assert.Fail();

        }
        [TestMethod]
        public void Delete(int id)
        {
            Assert.Fail();
        }

    }
}