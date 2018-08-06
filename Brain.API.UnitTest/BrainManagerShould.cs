using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Brain.API.Managers.Interfaces;
using Brain.API.Managers;

namespace Brain.API.UnitTest
{
    [TestClass]
    public class BrainManagerShould
    {
        private Mock<IGroupManager> _mockGroupManager;
        private Mock<IUserManager> _mockUserManager;
        private IBrainManager _brainManager;

        [TestInitialize]
        public void Init()
        {
            _mockGroupManager = new Mock<IGroupManager>();
            _mockUserManager = new Mock<IUserManager>();
            _brainManager = new BrainManager(_mockGroupManager.Object, _mockUserManager.Object);

        }

        public void GetUserWithAUid()
        {


        }
    }
}
