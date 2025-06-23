using System;
using System.Collections.Generic;

namespace App.Domain.Entities;

public partial class Randevu : BaseEntity
{
    public int Hekimid { get; set; }

    public int Hastaid { get; set; }

    public DateOnly Randevuzamani { get; set; }

    public string? Randevuaciklama { get; set; }

    public int? Hastaneid { get; set; }

    public virtual Hastum Id1 { get; set; } = null!;

    public virtual Hekim Id2 { get; set; } = null!;

    public virtual Hastane IdNavigation { get; set; } = null!;
}
