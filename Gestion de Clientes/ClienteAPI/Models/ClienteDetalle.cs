using System;
using System.Collections.Generic;

namespace ClienteAPI.Models;

public partial class ClienteDetalle
{
    public byte IdCliDet { get; set; }

    public int IdCli { get; set; }

    public string Correo { get; set; } = null!;

    public string Seguro { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public int Documento { get; set; }

    public string Residencia { get; set; } = null!;

    public virtual Cliente IdCliNavigation { get; set; } = null!;
}
