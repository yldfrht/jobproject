using System;
using System.Collections.Generic;

namespace App.Entity.Entities;

public partial class Product : BaseEntity
{
    public string Name { get; set; } = null!;

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;
}
