using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Dtos.Randevu
{
    public record RandevuCreateDto(int Hekimid, int Hastaid, int Hastaneid, DateOnly RandevuZamani, string Randevuaciklama);
}
