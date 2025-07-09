using Mediator.Abstractions;
using Moq;

namespace Mediator.Tests;

public class TestRequest : IRequest<string>;

public class MediatorTests
{
    [Fact]
    public async Task SendAsync_DeveRetornarResposta_QuandoHandlerExiste()
    {
        // Arrange
        var request = new TestRequest();
        const string expectedResponse = "resposta";

        var handlerMock = new Mock<IHandler<TestRequest, string>>();
        handlerMock
            .Setup(h => h.HandleAsync(request, It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedResponse);

        var serviceProviderMock = new Mock<IServiceProvider>();
        serviceProviderMock
            .Setup(sp => sp.GetService(typeof(IHandler<TestRequest, string>)))
            .Returns(handlerMock.Object);

        var mediator = new Mediator(serviceProviderMock.Object);

        // Act
        var result = await mediator.SendAsync(request);

        // Assert
        Assert.Equal(expectedResponse, result);
    }

    [Fact]
    public async Task SendAsync_DeveLancarExcecao_QuandoHandlerNaoEncontrado()
    {
        // Arrange
        var request = new TestRequest();
        var serviceProviderMock = new Mock<IServiceProvider>();
        serviceProviderMock
            .Setup(sp => sp.GetService(typeof(IHandler<TestRequest, string>)))
            .Returns(null!);

        var mediator = new Mediator(serviceProviderMock.Object);

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() => mediator.SendAsync(request));
    }

    [Fact]
    public async Task SendAsync_DeveLancarExcecao_QuandoHandleAsyncNaoExiste()
    {
        // Arrange
        var request = new TestRequest();

        var handler = new object(); // Não implementa HandleAsync

        var serviceProviderMock = new Mock<IServiceProvider>();
        serviceProviderMock
            .Setup(sp => sp.GetService(typeof(IHandler<TestRequest, string>)))
            .Returns(handler);

        var mediator = new Mediator(serviceProviderMock.Object);

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() => mediator.SendAsync(request));
    }
}