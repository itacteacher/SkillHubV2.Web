using Moq;
using SkillsHubV2.BLL.Services;
using SkillsHubV2.DAL.Repositories.Interfaces;
using SkillsHubV2.Domain.Entities;

namespace SkillsHubV2.BLL.Tests;

public class SoftSkillServiceTests
{
    private readonly Mock<ISoftSkillsRepository> _softSkillRepositoryMock;
    private readonly SoftSkillsService _softSkillService;

    public SoftSkillServiceTests ()
    {
        _softSkillRepositoryMock = new Mock<ISoftSkillsRepository>();
        _softSkillService = new SoftSkillsService(_softSkillRepositoryMock.Object);
    }

    [Fact]
    public async Task CreateSoftSkillAsync_ShouldReturnSoftSkill_WhenSoftSkillIsValid ()
    {
        // Arrange
        var newSoftSkill = new SoftSkill { Id = 1, Name = "Communication" };

        _softSkillRepositoryMock.Setup(repo => repo.AddAsync(newSoftSkill)).Returns(Task.CompletedTask);

        // Act
        var result = await _softSkillService.CreateSoftSkillAsync(newSoftSkill);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Communication", result.Name);
        _softSkillRepositoryMock.Verify(repo => repo.AddAsync(newSoftSkill), Times.Once);
    }

    [Fact]
    public async Task CreateSoftSkillAsync_ShouldThrowException_WhenSoftSkillIsNull ()
    {
        // Arrange
        SoftSkill nullSoftSkill = null;

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => _softSkillService.CreateSoftSkillAsync(nullSoftSkill));
        _softSkillRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<SoftSkill>()), Times.Never);
    }
}