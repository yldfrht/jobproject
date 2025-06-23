using System;
using System.Collections.Generic;

namespace App.Domain.Entities;

public partial class Bran : BaseEntity
{
    public string? Adi { get; set; }

    public int Hastaneid { get; set; }
}
