using NUnit.Framework;
using EducationalPractice;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.Linq;

namespace EducationalPractice.Tests
{
    [TestFixture]
    public class EnemyFactoryTests
    {
        private EnemyFactory _factory = null!;
        private Panel _gamePanel = null!;

        // Константы для упрощения поддержки
        private const int EnemyWidth = 15;
        private const int EnemyHeight = 15;
        private const int PanelWidth = 800;
        private const int PanelHeight = 600;

        [SetUp]
        public void Setup()
        {
            _factory = new EnemyFactory();
            _gamePanel = new Panel { Width = PanelWidth, Height = PanelHeight };
        }

        [Test]
        public void CreateEnemy_ReturnsEnemyWithCorrectSize()
        {
            // Arrange
            var existingEnemies = new List<PictureBox>();

            // Act
            var enemy = _factory.CreateEnemy(existingEnemies, _gamePanel);

            // Assert
            Assert.That(enemy.Width, Is.EqualTo(EnemyWidth));
            Assert.That(enemy.Height, Is.EqualTo(EnemyHeight));
        }

        [Test]
        public void CreateEnemy_ReturnsEnemyWithinPanelBounds()
        {
            // Arrange
            var existingEnemies = new List<PictureBox>();

            // Act
            var enemy = _factory.CreateEnemy(existingEnemies, _gamePanel);

            // Assert
            Assert.That(enemy.Location.X, Is.InRange(0, _gamePanel.Width - enemy.Width));
            Assert.That(enemy.Location.Y, Is.InRange(0, _gamePanel.Height - enemy.Height));
        }

        [Test]
        public void CreateEnemy_DoesNotOverlapWithExisting()
        {
            // Arrange
            var existingEnemies = new List<PictureBox>
            {
                new PictureBox
                {
                    Size = new Size(20, 20),
                    Location = new Point(100, 100)
                }
            };

            // Act
            var enemy = _factory.CreateEnemy(existingEnemies, _gamePanel);

            // Assert
            foreach (var e in existingEnemies)
            {
                Assert.That(enemy.Bounds.IntersectsWith(e.Bounds), Is.False);
            }
        }

        [Test]
        public void CreateEnemy_WhenNoExisting_ReturnsValidEnemy()
        {
            // Arrange
            var existingEnemies = new List<PictureBox>();

            // Act
            var enemy = _factory.CreateEnemy(existingEnemies, _gamePanel);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(enemy, Is.Not.Null);
                Assert.That(enemy.Width, Is.GreaterThan(0));
                Assert.That(enemy.Height, Is.GreaterThan(0));
            });
        }

        [Test]
        public void CreateEnemy_ReturnsUniqueInstancesEachTime()
        {
            // Arrange
            var existingEnemies = new List<PictureBox>();

            // Act
            var enemy1 = _factory.CreateEnemy(existingEnemies, _gamePanel);
            var enemy2 = _factory.CreateEnemy(existingEnemies, _gamePanel);

            // Assert
            Assert.That(enemy1, Is.Not.SameAs(enemy2));
        }

        [Test]
        public void CreateEnemy_WithMultipleExisting_DoesNotOverlap()
        {
            // Arrange
            var existingEnemies = new List<PictureBox>
            {
                new PictureBox { Size = new Size(30, 30), Location = new Point(100, 100) },
                new PictureBox { Size = new Size(30, 30), Location = new Point(150, 150) },
                new PictureBox { Size = new Size(30, 30), Location = new Point(200, 200) }
            };

            // Act
            var enemy = _factory.CreateEnemy(existingEnemies, _gamePanel);

            // Assert
            foreach (var e in existingEnemies)
            {
                Assert.That(enemy.Bounds.IntersectsWith(e.Bounds), Is.False);
            }
        }

        [Test]
        public void CreateEnemy_WhenPanelHasZeroSize_ThrowsException()
        {
            // Arrange
            var panel = new Panel { Width = 0, Height = 0 };
            var existingEnemies = new List<PictureBox>();

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                _factory.CreateEnemy(existingEnemies, panel));
        }

        [Test]
        public void CreateEnemy_CreatesDifferentPositionsEachTime()
        {
            // Arrange
            var existingEnemies = new List<PictureBox>();
            var positions = new HashSet<Point>();

            // Act
            for (int i = 0; i < 100; i++)
            {
                var enemy = _factory.CreateEnemy(existingEnemies, _gamePanel);
                positions.Add(enemy.Location);
            }

            // Assert
            Assert.That(positions.Count, Is.GreaterThan(1), "Все враги были созданы в одной точке");
        }

        [Test]
        public void CreateEnemy_CannotBeCreatedOnEdgeOfPanel()
        {
            // Arrange
            var existingEnemies = new List<PictureBox>();

            // Act
            var enemy = _factory.CreateEnemy(existingEnemies, _gamePanel);

            // Assert
            Assert.That(enemy.Location.X + enemy.Width, Is.LessThanOrEqualTo(_gamePanel.Width));
            Assert.That(enemy.Location.Y + enemy.Height, Is.LessThanOrEqualTo(_gamePanel.Height));
        }

        [Test]
        public void CreateEnemy_CannotBeCreatedOutsideOfPanel()
        {
            // Arrange
            var existingEnemies = new List<PictureBox>();
            var enemy = _factory.CreateEnemy(existingEnemies, _gamePanel);

            // Assert
            Assert.That(enemy.Location.X, Is.GreaterThanOrEqualTo(0));
            Assert.That(enemy.Location.X, Is.GreaterThanOrEqualTo(0));
        }

        [Test]
        public void CreateEnemy_CreationIsRandomized()
        {
            // Arrange
            var existingEnemies = new List<PictureBox>();
            var enemies = new List<PictureBox>();

            // Act
            for (int i = 0; i < 100; i++)
            {
                enemies.Add(_factory.CreateEnemy(existingEnemies, _gamePanel));
            }

            // Assert
            var uniqueLocations = new HashSet<Point>(enemies.Select(e => e.Location));
            Assert.That(uniqueLocations.Count, Is.GreaterThan(10), "Слишком мало уникальных позиций");
        }
    }
}