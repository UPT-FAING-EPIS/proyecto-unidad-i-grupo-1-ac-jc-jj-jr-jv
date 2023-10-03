using System;
using System.Collections.Generic;
<<<<<<< HEAD
using FluentValidation;
=======
>>>>>>> e6bea6542e711101d2348b7149afdc02d34216da

namespace ClienteAPI.Models
{
    public class ClienteCreateDTO
    {
<<<<<<< HEAD
        public int IdCliente { get; set; }
        public string Nombre { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public int Celular { get; set; }
=======
        public int? IdCliente { get; set; }
        public string NomCliente { get; set; }

        public string ApePaterno { get; set; }

        public string ApeMaterno { get; set; }

        public int Numero { get; set; }
>>>>>>> e6bea6542e711101d2348b7149afdc02d34216da

        public string? Genero { get; set; }
    }

<<<<<<< HEAD
    public class ClienteValidator : AbstractValidator<ClienteCreateDTO>
    {
        public ClienteValidator(){
            RuleFor(t => t.IdCliente).Empty();
            RuleFor(t => t.Nombre).NotEmpty().MaximumLength(5).WithMessage("El nombre debe tener como maximo 5 caracteres.");
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

=======
>>>>>>> e6bea6542e711101d2348b7149afdc02d34216da
}
