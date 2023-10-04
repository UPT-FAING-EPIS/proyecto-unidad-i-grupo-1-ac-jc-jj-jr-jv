using System;
using System.Collections.Generic;
using FluentValidation;

namespace ClienteAPI.Models;

public partial class TipoSeguroDTO
{
    public byte IdSeguro { get; set; }

    public int IdCli { get; set; }

    public string TipSeguro { get; set; } = null!;

    public string Poliza { get; set; } = null!;

    public decimal Cobertura { get; set; }

    public byte[]? DocumentoSeguro { get; set; }
}

public class TipoSeguroDTOValidator : AbstractValidator<TipoSeguroDTO>
{
    public TipoSeguroDTOValidator(){
        RuleFor(t => t.IdSeguro).Empty();
        RuleFor(t => t.IdCli).NotEmpty();
        RuleFor(t => t.TipSeguro).NotEmpty().MaximumLength(40);
        RuleFor(t => t.Poliza)
            .NotEmpty().WithMessage("La Poliza no puede estar vacía.")
            .Matches(@"^\d{10}$").WithMessage("La Poliza debe tener exactamente 10 dígitos.");
        RuleFor(t => t.Cobertura).NotEmpty().WithMessage("ERROR AL INGRESAR DECIMAL");
        RuleFor(t => t.DocumentoSeguro).NotEmpty().WithMessage("ERROR AL REGISTRAR EL DOCUMENTO SEGURO");
    }
}