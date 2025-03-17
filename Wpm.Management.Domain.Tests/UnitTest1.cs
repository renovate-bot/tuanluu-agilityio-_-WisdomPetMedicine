namespace Wpm.Management.Domain.Tests;

public class UnitTest1
{
    [Fact]
    public void Pet_should_be_equal()
    {
        var id = Guid.NewGuid();
        var pet1 = new Pet { Id = id, Name = "Rex", Age = 5 };
        var pet2 = new Pet { Id = id, Name = "Rex", Age = 5 };

        Assert.True(pet1.Equals(pet2));
    }

    [Fact]
    public void Pet_should_be_equal_using_operator()
    {
        var id = Guid.NewGuid();
        var pet1 = new Pet { Id = id, Name = "Rex", Age = 5 };
        var pet2 = new Pet { Id = id, Name = "Rex", Age = 5 };

        Assert.True(pet1 == pet2);
    }

    [Fact]
    public void Pet_should_be_not_equal_using_operator()
    {
        var id1 = Guid.NewGuid();
        var id2 = Guid.NewGuid();
        var pet1 = new Pet { Id = id1, Name = "Rex", Age = 5 };
        var pet2 = new Pet { Id = id2, Name = "Rex", Age = 5 };

        Assert.True(pet1 != pet2);
    }
}
