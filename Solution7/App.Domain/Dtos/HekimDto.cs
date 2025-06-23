using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Dtos
{
    public record HekimDto(int Id, long Kimliknumarasi, string AdiSoyadi, int Bransid, int Hastaneid);
}