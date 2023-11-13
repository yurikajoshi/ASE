using System;
using System.Drawing;
using GraphicalProgrammingEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GraphicalProgrammingEnvironmentTests
{/*
    [TestClass]
    public class CircleTests
    {
        private Mock<Form1> mockForm;
        private Circle circle;

        [TestInitialize]
        public void Setup()
        {
            mockForm = new Mock<Form1>();
            mockForm.Setup(form => form.GetPictureBox()).Returns(new PictureBox());
            circle = new Circle(mockForm.Object);
        }

        [TestMethod]
        public void ProcessCircleCommand_ValidCommand_ShouldSetCursorPosition()
        {
            // Arrange
            string[] commandParts = new string[] { "circle", "50" }; // Example command
            var expectedPosition = new Point(0, 0); // Example expected position

            // Act
            circle.ProcessCircleCommand(commandParts);

            // Assert
            mockForm.Verify(form => form.SetCursorPosition(It.IsAny<Point>()), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(MessageBox))]
        public void ProcessCircleCommand_InvalidCommand_ShouldThrowMessageBoxException()
        {
            // Arrange
            string[] commandParts = new string[] { "circle", "invalid" }; // Invalid command

            // Act & Assert
            circle.ProcessCircleCommand(commandParts);
        }

        // Additional tests for other scenarios...
    }
    */
}
