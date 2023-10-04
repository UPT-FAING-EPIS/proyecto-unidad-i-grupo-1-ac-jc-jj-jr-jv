using System;
using System.Collections.Generic;
using FluentValidation;

namespace ClienteAPI.Models;

public partial class TiposDocumentoDTO
{
    public byte IdTipoDocumento { get; set; }

    public int IdCli { get; set; }

    public string DesTipoDocumento { get; set; } = null!;

    public int NumDocumento { get; set; }

    public DateTime FechaEmision { get; set; }

    public DateTime FechaVencimiento { get; set; }

    public byte[]? Imagen { get; set; }
}

public class TiposDocumentoDTOValidator : AbstractValidator<TiposDocumentoDTO>
{
    public TiposDocumentoDTOValidator(){
        RuleFor(t => t.IdTipoDocumento).Empty();
        RuleFor(t => t.IdCli).NotEmpty();
        RuleFor(t => t.DesTipoDocumento).NotEmpty().MaximumLength(40);
        RuleFor(t => t.NumDocumento).NotEmpty();
        RuleFor(t => t.FechaEmision).NotEmpty();
        RuleFor(t => t.FechaVencimiento).NotEmpty().WithMessage("SE EXCEDIO EL RANGO DE 30 CARACTERES");
    }
}