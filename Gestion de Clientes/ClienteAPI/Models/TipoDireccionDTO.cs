using System;
using System.Collections.Generic;
using FluentValidation;

namespace ClienteAPI.Models;

public partial class TipoDireccionDTO
{
    public byte IdDireccion { get; set; }

    public int IdCli { get; set; }

    public string TipoDireccion1 { get; set; } = null!;

    public string DesTipoDireccion { get; set; } = null!;

    public string Calle { get; set; } = null!;

    public string? Referencia { get; set; }
}
public class TipoDireccionDTOValidator : AbstractValidator<TipoDireccionDTO>
{
    public TipoDireccionDTOValidator(){
        RuleFor(t => t.IdDireccion).Empty();
        RuleFor(t => t.IdCli).NotEmpty();
        RuleFor(t => t.TipoDireccion1).NotEmpty().MaximumLength(40);
        RuleFor(t => t.DesTipoDireccion).NotEmpty().MaximumLength(50);
        RuleFor(t => t.Calle).NotEmpty().MaximumLength(15);
        RuleFor(t => t.Referencia).NotEmpty().MaximumLength(20);
    }
}
