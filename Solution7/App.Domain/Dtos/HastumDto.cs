using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Dtos
{
    public record HastumDto(int Id, long Kimliknumarasi, string Adsoyad);
}
