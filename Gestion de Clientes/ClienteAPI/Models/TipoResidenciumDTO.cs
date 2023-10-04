using System;
using System.Collections.Generic;
using FluentValidation;

namespace ClienteAPI.Models;

public partial class TipoResidenciumDTO
{
    public byte IdResidencia { get; set; }

    public int IdCli { get; set; }

    public string DesTipResi { get; set; } = null!;

    public string Pais { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public string Provincia { get; set; } = null!;

}


public class TipoResidenciumDTOValidator : AbstractValidator<TipoResidenciumDTO>
{
    public TipoResidenciumDTOValidator(){
        RuleFor(t => t.IdResidencia).Empty();
        RuleFor(t => t.IdCli).NotEmpty();
        RuleFor(t => t.DesTipResi).NotEmpty().MaximumLength(40);
        RuleFor(t => t.Pais).NotEmpty().MaximumLength(50);
        RuleFor(t => t.Ciudad).NotEmpty().MaximumLength(15);
        RuleFor(t => t.Provincia).NotEmpty().MaximumLength(30).WithMessage("SE EXCEDIO EL RANGO DE 30 CARACTERES");
    }
}