using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CleanThatCode.Community.Repositories.Implementations;
using CleanThatCode.Community.Repositories.Data;
using CleanThatCode.Community.Tests.Mocks;
using CleanThatCode.Community.Models.Dtos;
using Moq;
using CleanThatCode.Community.Repositories.Interfaces;
using Bogus;
using CleanThatCode.Community.Models.Entities;

namespace CleanThatCode.Community.Tests;

[TestClass]
public class PostRepositoryTests
{
    private Mock<ICleanThatCodeDbContext> _dbMock = null!;
    private PostRepository _repo = null!;

    [TestInitialize]
    public void Initialize()
    {
        // Bogus: exactly 3 posts; only set Title & Author as required
        var faker = new Faker<Post>();
        var posts = faker.Generate(3);

        // First two: title contains "Grayskull", author "He-Man"
        posts[0].Title = "By the power of Grayskull";
        posts[0].Author = "He-Man";

        posts[1].Title = "Secrets of Castle Grayskull";
        posts[1].Author = "He-Man";

        // Last: title contains "Hack the planet!", author "Richard Stallman"
        posts[2].Title = "Hack the planet!";
        posts[2].Author = "Richard Stallman";

        _dbMock = new Mock<ICleanThatCodeDbContext>();
        _dbMock.Setup(c => c.Posts).Returns(posts);

        _repo = new PostRepository(_dbMock.Object);
    }

    [TestMethod]
    public void GetAllPosts_NoFilter_ShouldContainAListOfThree()
    {
        var result = _repo.GetAllPosts("", "").ToList();

        Assert.AreEqual(3, result.Count);
    }
    [TestMethod]
    public void GetAllPosts_FilteredByTitle_ShouldContainAListOfTwo()
    {
        var result = _repo.GetAllPosts("Grayskull", "").ToList();

        Assert.AreEqual(2, result.Count);
    }

    [TestMethod]
    public void GetAllPosts_FilteredByAuthor_ShouldContainAListOfOne()
    {
        var result = _repo.GetAllPosts("", "Stallman").ToList();

        Assert.AreEqual(1, result.Count);
    }
}
