using System.Collections.Generic;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Brain.API.Managers.Interfaces;
using Brain.API.Managers;
using AutoFixture;
using Brain.API.ServiceModel.DTOs;

namespace Brain.API.UnitTest
{
    [TestClass]
    public class BrainManagerShould
    {
        private Mock<IGroupManager> _mockGroupManager;
        private Mock<IUserManager> _mockUserManager;
        private IBrainManager _brainManager;
        private Fixture _fixture;

        [TestInitialize]
        public void Init()
        {
            _mockGroupManager = new Mock<IGroupManager>();
            _mockUserManager = new Mock<IUserManager>();
            _brainManager = new BrainManager(_mockGroupManager.Object, _mockUserManager.Object);
            _fixture = new Fixture();
        }

        [TestMethod]
        public void GetUsers_ReturnsUsers()
        {
            // Arrange
            List<User> users = _fixture.Create<List<User>>();
            _mockUserManager.Setup(x => x.GetUsers()).Returns(users);

            // Act
            var result = _brainManager.GetUsers();


            // Assert
            CollectionAssert.AreEqual(result, users);
        }


        [TestMethod]
        public void GetUsers_ForAUser_ReturnsUsers()
        {
            // Arrange
            User user = _fixture.Create<User>();
            List<User> users = _fixture.Create<List<User>>();

            _mockUserManager.Setup(x => x.GetUsers()).Returns(users);
            _mockUserManager.Setup(x => x.AddToExistingUsers(It.IsAny<List<User>>(), It.IsAny<List<User>>())).Returns(users);

            // Act
            var result = _brainManager.GetUsers(user);


            // Assert
            CollectionAssert.AreEqual(result, users);
        }

        [TestMethod]
        public void GetUser_ForAUid_ReturnsUser()
        {
            // Arrange
            User user = _fixture.Create<User>();

            List<User> users = new List<User>()
            {
                user
            };

            _mockUserManager.Setup(x => x.GetUsers()).Returns(users);
            _mockUserManager.Setup(x => x.AddToExistingUsers(It.IsAny<List<User>>(), It.IsAny<List<User>>())).Returns(users);

            // Act
            var result = _brainManager.GetUser(user.Uid);


            // Assert
            Assert.AreEqual(user, result);
        }

        [TestMethod]
        public void GetGroup_ForAGid_DoesNotReturnGroup()
        {
            // Arrange
            Group group = _fixture.Create<Group>();

            List<Group> groups = _fixture.Create<List<Group>>();

            _mockGroupManager.Setup(x => x.GetGroups()).Returns(groups);

            // Act
            var result = _brainManager.GetGroup(It.IsAny<string>());


            // Assert
            Assert.AreEqual(null, result);
        }
    }
}
