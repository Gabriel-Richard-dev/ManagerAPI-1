using Manager.Core.Exceptions;
using Manager.Domain.Validators;

namespace Manager.Domain.Entities
{
    public class User : Base
    {
        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            _erros = new List<string>();
        }
        //EF
        protected User(){}
        
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public void ChangeName(string name)
        {
            Name = name;
            Validate();
        }
        public void ChangePassword(string password)
        {
            Password = password;
            Validate();
        }
        public void ChangeEmail(string email)
        {
            Email = email;
            Validate();
        }

        public override bool Validate()
        {
            var validator = new UserValidator();
            var validation = validator.Validate(this);
            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                {
                    _erros.Add(error.ErrorMessage);
                }

                throw new DomainException($"Alguns campos estão inválidos, corrija-os, \n", _erros);
            }
            return true;
        }
        
    }
}