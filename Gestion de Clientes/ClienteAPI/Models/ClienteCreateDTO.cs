using System;
using System.Collections.Generic;
using FluentValidation;

namespace ClienteAPI.Models
{
    public class ClienteCreateDTO
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; } = null!;

        public string ApellidoPaterno { get; set; } = null!;

        public string ApellidoMaterno { get; set; } = null!;

        public int Celular { get; set; }

        public string? Genero { get; set; }
    }

    public class ClienteValidator : AbstractValidator<ClienteCreateDTO>
    {
        public ClienteValidator(){
            RuleFor(t => t.IdCliente).Empty();
            RuleFor(t => t.Nombre).NotEmpty().MaximumLength(15).WithMessage("El nombre debe tener como maximo 15 caracteres.");
            RuleFor(t => t.ApellidoPaterno).NotEmpty().MaximumLength(50);
            RuleFor(t => t.ApellidoMaterno).NotEmpty().MaximumLength(50);
            /* RuleFor(t => t.Celular).NotEmpty().GreaterThan(0).WithMessage("INGRESAR UN NUMERO DE 9 DIGITOS"); */
            RuleFor(t => t.Celular)
                .GreaterThan(0)
                .WithMessage("El número de celular debe ser mayor que 0")
                .Must(celular => celular >= 100000000 && celular <= 999999999)
                .WithMessage("El número de celular debe tener exactamente 9 dígitos")
                .When(celular => celular != null) // Solo aplica la validación si el valor no es nulo
                .Must(celular => celular.ToString().Length == 9)
                .WithMessage("El número de celular debe tener exactamente 9 dígitos");
            RuleFor(t => t.Genero).NotEmpty().MaximumLength(30);
        }
    }

}
