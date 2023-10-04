using System;
using System.Collections.Generic;
using FluentValidation;

namespace ClienteAPI.Models;

public partial class TipoCorreoDTO
{
    public byte IdTipoCorreo { get; set; }

    public int IdCli { get; set; }

    public string TipoCorreo1 { get; set; } = null!;

    public string DesTipoCorreo { get; set; } = null!;
}


public class TipoCorreoDTOValidator : AbstractValidator<TipoCorreoDTO>
    {
        public TipoCorreoDTOValidator(){
            RuleFor(t => t.IdTipoCorreo).Empty();
            RuleFor(t => t.IdCli).NotEmpty();
            RuleFor(t => t.TipoCorreo1).NotEmpty().MaximumLength(50);
            RuleFor(t => t.DesTipoCorreo).NotEmpty().MaximumLength(50);
        }
    }
