using Microsoft.VisualStudio.TestTools.UnitTesting;
using CleanThatCode.Community.Common;

namespace CleanThatCode.Community.Tests;

// It is your job to make those tests pass, by implementing the methods in StringHelpers located in CleanThatCode.Community.Common
[TestClass]
public class StringHelperTests
{
    [TestMethod]
    public void ToDotSeparatedString_ContainingTwoWords_ShouldContainASingleDot()
    {
        var result = "Thundercats unite!".ToDotSeparatedString();
        Assert.AreEqual("Thundercats.unite!", result);
    }

    [TestMethod]
    public void ToDotSeparatedString_ContainingThreeWords_ShouldContainTwoDots()
    {
        var result = "Thunder Thunder Thundercats!!".ToDotSeparatedString();
        Assert.AreEqual("Thunder.Thunder.Thundercats!!", result);
    }

    [TestMethod]
    public void ToDotSeparatedString_ContainingSixWords_ShouldContainFiveDots()
    {
        var result = "Hola senior! Buenos diaz por favor".ToDotSeparatedString();
        Assert.AreEqual("Hola.senior!.Buenos.diaz.por.favor", result);
    }

    [TestMethod]
    public void CapitalizeAllWords_ContainingTwoWords_ShouldContainCapitalizedLetters()
    {
        var result = "all day".CapitalizeAllWords();
        Assert.AreEqual("All Day", result);
    }

    [TestMethod]
    public void CapitalizeAllWords_ContainingFourWords_ShouldContainCapitalizedLetters()
    {
        var result = "hasta la vista baby".CapitalizeAllWords();
        Assert.AreEqual("Hasta La Vista Baby", result);
    }

    [TestMethod]
    public void CapitalizeAllWords_ContainingSixWords_ShouldContainCapitalizedLetters()
    {
        var result = "is this supposed to be water?".CapitalizeAllWords();
        Assert.AreEqual("Is This Supposed To Be Water?", result);
    }

    [TestMethod]
    public void ReverseWords_ContainingThreeWords_ShouldBeReversed()
    {
        var result = "Hey, you guys!!".ReverseWords();
        Assert.AreEqual("guys!! you Hey,", result);
    }

    [TestMethod]
    public void ReverseWords_ContainingFourWords_ShouldBeReversed()
    {
        var result = "I know your name!".ReverseWords();
        Assert.AreEqual("name! your know I", result);
    }

    [TestMethod]
    public void ReverseWords_ContainingSixWords_ShouldBeReversed()
    {
        var result = "Chunk, chunk! Do the truffle shuffle!".ReverseWords();
        Assert.AreEqual("shuffle! truffle the Do chunk! Chunk,", result);
    }
}

// TEST COMMENT REPOSITRY
[TestClass]
public class CommentRepositoryTests
{
    [TestMethod]
    public void GetAllCommentsByPostId_WithExistingPost_ReturnsOnlyThatPostsComments()
    {
        // Arrange
        var db = new CleanThatCodeDbContextMock();
        var sut = new CommentRepository(db);
        var targetPostId = 1;

        // Act
        var result = sut.GetAllCommentsByPostId(targetPostId).ToList();

        // Assert
        Assert.IsTrue(result.Count > 0, "Expected at least one comment for post 1");
        Assert.IsTrue(result.All(c => c.PostId == targetPostId), "Repository returned comments for the wrong post");
    }

    [TestMethod]
    public void GetAllCommentsByPostId_WithNonExistingPost_ReturnsEmpty()
    {
        // Arrange
        var db = new CleanThatCodeDbContextMock();
        var sut = new CommentRepository(db);
        var nonexistentPostId = 999;

        // Act
        var result = sut.GetAllCommentsByPostId(nonexistentPostId).ToList();

        // Assert
        Assert.AreEqual(0, result.Count);
    }
}