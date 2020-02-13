using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Perlink.Data;
using Perlink.Web.Models;

namespace Perlink.Web.Validations
{
    public class MainValidator : AbstractValidator<LawViewModel>
    {
        public MainValidator()
        {
            RuleFor(u => u.NumeroDoProcesso).NotEmpty();
            RuleFor(u => u.dataDeCriacaoDoProcesso).NotEmpty();
            RuleFor(u => u.escritorioId).NotEmpty().NotNull();
            RuleFor(u => u.valor).NotEmpty();
        }
    }
}
