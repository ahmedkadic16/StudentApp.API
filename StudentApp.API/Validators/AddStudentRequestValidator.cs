using FluentValidation;
using StudentApp.API.DomainModels;
using StudentApp.API.Repositories;
using System.Linq;

namespace StudentApp.API.Validators
{
    public class AddStudentRequestValidator: AbstractValidator<AddStudentRequest>
    {
        public AddStudentRequestValidator(IStudentRepository studentRepository)
        {
            RuleFor(x=>x.FirstName).NotEmpty();
            RuleFor(x=>x.LastName).NotEmpty();
            RuleFor(x=>x.DateOfBirth).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Mobile).GreaterThan(99999).LessThan(1234567890123);
            RuleFor(x=> x.GenderId).NotEmpty().Must(id =>
            {
                var gender = studentRepository.GetGenders().Result.ToList().FirstOrDefault(X => X.Id == id);
                if (gender != null)
                    return true;
                return false;
            }).WithMessage("Please select valid gender");
            RuleFor(x => x.PhysicalAddress).NotEmpty();
            RuleFor(x=> x.PostalAddress).NotEmpty();
        }
    }
}
