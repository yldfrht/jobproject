using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entity.Dtos
{
    public record ProductRequestDto(int Id, string Name, int CategoryId);
}
