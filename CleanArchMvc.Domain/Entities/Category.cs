using CleanArchMvc.Domain.Validation;
using System.Data;

namespace CleanArchMvc.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; private set; } = string.Empty;
        public ICollection<Product> Products { get; private set; }

        public Category(string name)
        {
            ValidateNameAssign(name);
        }

        public Category(int id, string name)
        {
            ValidateIdAssign(id);
            ValidateNameAssign(name);
        }

        public void Update(string name)
        {
            ValidateNameAssign(name);
        }

        private void ValidateIdAssign(int id)
        {
            DomainExceptionValidation.When(id <= 0,
                "Invalid Id, the id must be greater than 0.");

            Id = id;
        }

        private void ValidateNameAssign(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name, the name is required.");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters.");

            Name = name;
        }
    }
}
