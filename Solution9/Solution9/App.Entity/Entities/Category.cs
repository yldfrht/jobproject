using App.Entity.Entities;
using System;
using System.Collections.Generic;

namespace App.Entity.Entities;

public partial class Category : BaseEntity
{
    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = [];
}
