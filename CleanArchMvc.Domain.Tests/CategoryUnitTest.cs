using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest
    {
        [Fact(DisplayName = "create category with valid state")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            // Action, Arrange, Assert
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "not create category with invalid id")]
        public void CreateCategory_WithNegativeIdValue_DomainExceptionInvalidId()
        {
            // Action, Arrange, Assert
            Action action = () => new Category(0, "Category Name");
            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid Id, the id must be greater than 0.");
        }

        [Fact(DisplayName = "not create category with to short name")]
        public void CreateCategory_WithToShortName_DomainExceptionInvalidName()
        {
            // Action, Arrange, Assert
            Action action = () => new Category(1, "CN");
            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Fact(DisplayName = "not create category with null name")]
        public void CreateCategory_WithNullName_DomainExceptionInvalidName()
        {
            // Action, Arrange, Assert
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<DomainExceptionValidation>();
        }
    }
}