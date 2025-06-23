using System;
using System.Collections.Generic;

namespace App.Domain.Entities;

public partial class Hastane : BaseEntity
{
    public string? Adi { get; set; }

    public virtual Randevu? Randevu { get; set; }
}
