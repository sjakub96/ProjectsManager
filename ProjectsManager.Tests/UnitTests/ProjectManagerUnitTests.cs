using Moq;
using ProjectsManager.App;
using ProjectsManager.App.Concrete;
using ProjectsManager.App.Managers;
using ProjectsManager.Domain.Entity;
using System;
using System.Collections.Generic;
using Xunit;

namespace ProjectsManager.Tests.UnitTests
{
    public class ProjectManagerUnitTests
    {
        [Fact]
        public void AddNewProjectTest()
        {
            //Arrange
            var newProject = new Project()
            {
                Id = 1, 
                Name = "TestProject",
                TypeId = 111
            };

            var mock = new Mock<IService<Project>>();
            mock.Setup(s => s.AddNewProject(newProject)).Returns(newProject.Id);

            var manager = new ProjectManager(new MenuActionService(), mock.Object);

            //Act
            var returnedIdFromNewProject = manager.AddNewProject();

            //Assert
            Assert.Equal(newProject.Id, returnedIdFromNewProject);

        }
    }
}
