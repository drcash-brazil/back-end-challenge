using BookStore.Domain.Commands;
using BookStore.Domain.Commands.AuthorCommand;
using BookStore.Domain.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookStore.Domain.Tests.HandlerTests;

[TestClass]
public class CreateAuthorHandlerTest
{
    [TestMethod]
    public void When_create_author_return_success()
    {
        var command = new CreateAuthorCommand("António Gabriel");
        var handler = new AuthorHandler(new FakeRepository());
        var result = (GenericCommandResult)handler.Handle(command);

        Assert.AreEqual(result.success, true);
    }
}