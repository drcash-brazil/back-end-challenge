using BookStore.Domain.Commands;
using BookStore.Domain.Commands.AuthorCommand;
using BookStore.Domain.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookStore.Domain.Tests.HandlerTests;

[TestClass]
public class UpdateAuthorHandlerTest
{
    [TestMethod]
    public void When_udapte_author_return_success()
    {
        var command = new UpdateAuthorCommand(System.Guid.NewGuid(), "António Gabriel");
        var handler = new AuthorHandler(new FakeRepository());
        var result = (GenericCommandResult)handler.Handle(command);

        Assert.AreEqual(result.success, true);
    }
}