using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest
    {
        [Fact(DisplayName = "create product with valid state")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            // Action, Arrange, Assert
            Action action = () => new Product(1, "Product Name", "Product Description", 9.42m, 32, "Product Image");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "not create product with invalid id")]
        public void CreateProduct_WithNegativeIdValue_DomainExceptionInvalidId()
        {
            // Action, Arrange, Assert
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.42m, 32, "Product Image");
            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid Id, the id must be greater than 0.");
        }

        [Fact(DisplayName = "not create product with null name")]
        public void CreateProduct_WithNullName_DomainExceptionInvalidName()
        {
            // Action, Arrange, Assert
            Action action = () => new Product(1, null, "Product Description", 9.42m, 32, "Product Image");
            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid name, the name is required.");
        }

        [Fact(DisplayName = "not create product with to short name")]
        public void CreateProduct_WithToShortName_DomainExceptionInvalidName()
        {
            // Action, Arrange, Assert
            Action action = () => new Product(1, "P", "Product Description", 9.42m, 32, "Product Image");
            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Fact(DisplayName = "not create product with null description")]
        public void CreateProduct_WithNullDescription_DomainExceptionInvalidName()
        {
            // Action, Arrange, Assert
            Action action = () => new Product(1, "Product Name", null, 9.42m, 32, "Product Image");
            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid description, the description is required.");
        }

        [Fact(DisplayName = "not create product with to short description")]
        public void CreateProduct_WithToShortDescription_DomainExceptionInvalidName()
        {
            // Action, Arrange, Assert
            Action action = () => new Product(1, "Product Name", "PD", 9.42m, 32, "Product Image");
            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid description, too short, minimum 5 characters.");
        }

        [Fact(DisplayName = "not create product with negative price")]
        public void CreateProduct_WithNegativePrice_DomainExceptionInvalidName()
        {
            // Action, Arrange, Assert
            Action action = () => new Product(1, "Product Name", "Product Description", -7.0m, 32, "Product Image");
            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid price, the price must be positive.");
        }

        [Fact(DisplayName = "not create product with negative stock")]
        public void CreateProduct_WithNegativeStock_DomainExceptionInvalidName()
        {
            // Action, Arrange, Assert
            Action action = () => new Product(1, "Product Name", "Product Description", 7.0m, -12, "Product Image");
            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid stock, the stock must be positive.");
        }

        [Fact(DisplayName = "not create product with to long image")]
        public void CreateProduct_WithToLongImage_DomainExceptionInvalidName()
        {
            // Action, Arrange, Assert
            Action action = () => new Product(1, "Product Name", "Product Description", 7.0m, 12,
                "Product Image to long, to long, to long, to long, to long, to long, to long, to long, to long, " +
                "to long, to long, to long, to long, to long, to long, to long, to long, to long, to long, to long, to long," +
                "to long, to long, to long, to long, to long, to long, to long, to long, to long, to long, to long, to long");
            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid image name, too long, maximum 250 characters.");
        }
    }
}