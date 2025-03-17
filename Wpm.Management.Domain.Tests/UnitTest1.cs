using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Domain.Tests;

public class UnitTest1
{
    [Fact]
    public void Pet_should_be_equal()
    {
        var id = Guid.NewGuid();
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);

        var pet1 = new Pet(id,
                           "Rex",
                           5,
                           "Brown",
                           new Weight(10.5m),
                           SexOfPet.Male,
                           breedId);
        var pet2 = new Pet(id,
                           "Rex",
                           5,
                           "Brown",
                           new Weight(10.5m),
                           SexOfPet.Male,
                           breedId);

        Assert.True(pet1.Equals(pet2));
    }

    [Fact]
    public void Pet_should_be_equal_using_operator()
    {
        var id = Guid.NewGuid();
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);

        var pet1 = new Pet (id,
                            "Rex",
                            5,
                            "Brown",
                            new Weight(10.5m),
                            SexOfPet.Male,
                            breedId);
        var pet2 = new Pet (id,
                            "Rex",
                            5,
                            "Brown",
                            new Weight(10.5m),
                            SexOfPet.Male,
                            breedId);

        Assert.True(pet1 == pet2);
    }

    [Fact]
    public void Pet_should_be_not_equal_using_operator()
    {
        var id1 = Guid.NewGuid();
        var id2 = Guid.NewGuid();

        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);

        var pet1 = new Pet (id1,
                            "Rex",
                            5,
                            "Brown",
                            new Weight(10.5m),
                            SexOfPet.Male,
                            breedId);
        var pet2 = new Pet (id2,
                            "Rex",
                            5,
                            "Brown",
                            new Weight(10.5m),
                            SexOfPet.Male,
                            breedId);

        Assert.True(pet1 != pet2);
    }

    [Fact]
    public void Weight_should_be_equal()
    {
        var weight1 = new Weight(10.5m);
        var weight2 = new Weight(10.5m);
        Assert.True(weight1.Equals(weight2));
    }

    [Fact]
    public void WeightRange_should_be_equal()
    {
        var wrl = new WeightRange(10.5m, 20.5m);
        var wr2 = new WeightRange(10.5m, 20.5m);
        Assert.True(wrl == wr2);
    }

    [Fact]
    public void BreedId_should_be_valid()
    {
        var breedService = new FakeBreedService();
        var id = breedService.breeds[0].Id;
        var breedId = new BreedId(id, breedService);

        Assert.NotNull(breedId);
    }

    [Fact]
    public void BreedId_should_not_be_valid()
    {
        var breedService = new FakeBreedService();
        var id = Guid.NewGuid();

        Assert.Throws<ArgumentException>(() => new BreedId(id, breedService));
    }
}
