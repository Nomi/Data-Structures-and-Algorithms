using DSA.NeetCode150.Topics.T01_ArraysAndHashing.P01_ContainsDuplicate_LC217;

namespace DSA.NeetCode150.Tests.Topics.T01_ArraysAndHashing;

public class P01_ContainsDuplicate_LC217_Test
{
    [Fact]
    public async Task GIVEN_NumsWithDuplicates_RETURNS_True()
    {
        //Arrange
        var solution = new ContainsDuplicate();
        int[] nums = [0, 0];
        
        //Act
        var res = solution.HasDuplicate(nums);
        
        //Assert
        Assert.True(res);
    }
    
    [Fact]
    public async Task GIVEN_NumsEmpty_RETURNS_False()
    {
        //Arrange
        var solution = new ContainsDuplicate();
        int[] nums = [];
        
        //Act
        var res = solution.HasDuplicate(nums);
        
        //Assert
        Assert.False(res);
    }
    
    [Fact]
    public async Task GIVEN_NumsWith1Num_RETURNS_False()
    {
        //Arrange
        var solution = new ContainsDuplicate();
        int[] nums = [1];
        
        //Act
        var res = solution.HasDuplicate(nums);
        
        //Assert
        Assert.False(res);
    }
    
    [Fact]
    public async Task GIVEN_NumsWithNoDuplicates_RETURNS_False()
    {
        //Arrange
        var solution = new ContainsDuplicate();
        int[] nums = [1, 2];
        
        //Act
        var res = solution.HasDuplicate(nums);
        
        //Assert
        Assert.False(res);
    }
    
}