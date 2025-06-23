using System;
using System.Collections.Generic;

namespace App.Domain.Entities;

public partial class Hekim : BaseEntity
{
    public long Kimliknumarasi { get; set; }

    public string? AdiSoyadi { get; set; }

    public int Bransid { get; set; }

    public int Hastaneid { get; set; }

    public virtual Randevu? Randevu { get; set; }
}
