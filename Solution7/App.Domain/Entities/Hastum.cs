using System;
using System.Collections.Generic;

namespace App.Domain.Entities;

public partial class Hastum : BaseEntity
{
    public long Kimliknumarasi { get; set; }

    public string? Adsoyad { get; set; }

    public virtual Randevu? Randevu { get; set; }
}
