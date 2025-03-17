namespace Wpm.Management.Domain.Tests;

public class UnitTest1
{
    [Fact]
    public void Pet_should_be_equal()
    {
        var id = Guid.NewGuid();
        // generate new object for Pet with id
        
        var pet1 = new Pet(id,
                           "Rex",
                           5,
                           "Brown",
                           new Weight(10.5m),
                           SexOfPet.Male);
        var pet2 = new Pet(id,
                           "Rex",
                           5,
                           "Brown",
                           new Weight(10.5m),
                           SexOfPet.Male);

        Assert.True(pet1.Equals(pet2));
    }

    [Fact]
    public void Pet_should_be_equal_using_operator()
    {
        var id = Guid.NewGuid();
        var pet1 = new Pet (id,
                            "Rex",
                            5,
                            "Brown",
                            new Weight(10.5m),
                            SexOfPet.Male);
        var pet2 = new Pet (id,
                            "Rex",
                            5,
                            "Brown",
                            new Weight(10.5m),
                            SexOfPet.Male);

        Assert.True(pet1 == pet2);
    }

    [Fact]
    public void Pet_should_be_not_equal_using_operator()
    {
        var id1 = Guid.NewGuid();
        var id2 = Guid.NewGuid();
        var pet1 = new Pet (id1,
                            "Rex",
                            5,
                            "Brown",
                            new Weight(10.5m),
                            SexOfPet.Male);
        var pet2 = new Pet (id2,
                            "Rex",
                            5,
                            "Brown",
                            new Weight(10.5m),
                            SexOfPet.Male);

        Assert.True(pet1 != pet2);
    }

    [Fact]
    public void Weight_should_be_equal()
    {
        var weight1 = new Weight(10.5m);
        var weight2 = new Weight(10.5m);
        Assert.True(weight1.Equals(weight2));
    }
}
