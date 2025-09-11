using System.Collections.Generic;
using CleanThatCode.Community.Models.Entities;
using CleanThatCode.Community.Repositories.Data;

namespace CleanThatCode.Community.Tests.Mocks;

// Simple implementation of ICleanThatCodeDbContext that uses FakeData
public sealed class CleanThatCodeDbContextMock : ICleanThatCodeDbContext
{
    public IEnumerable<Comment> Comments { get; }
    public IEnumerable<Post> Posts { get; }

    public CleanThatCodeDbContextMock()
    {
        // Use provided fake data
        Comments = FakeData.Comments;
        Posts = FakeData.Posts;
    }
}