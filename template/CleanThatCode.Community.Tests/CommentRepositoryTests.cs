using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CleanThatCode.Community.Repositories.Implementations;
using CleanThatCode.Community.Tests.Mocks;

namespace CleanThatCode.Community.Tests;

[TestClass]
public class CommentRepositoryTests
{
    [TestMethod]
    public void GetAllCommentsByPostId_GivenWrongPostId_ShouldReturnNoComments()
    {
        var repo = new CommentRepository(new CleanThatCodeDbContextMock());

        var result = repo.GetAllCommentsByPostId(5).ToList(); // PostId 5 does not exist in the fake data.
        Assert.AreEqual(0, result.Count);
    }

    [TestMethod]
    public void GetAllCommentsByPostId_GivenValidPostId_ShouldReturnTwoComments()
    {
        var repo = new CommentRepository(new CleanThatCodeDbContextMock());

        var result = repo.GetAllCommentsByPostId(1).ToList();

        Assert.AreEqual(2, result.Count);
    }
}
