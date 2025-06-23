using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Dtos.Randevu
{
    public record RandevuUpdateDto(int Id, int Hekimid, int Hastaid, int hastaneid, DateOnly RandevuZamani, string Randevuaciklama);
}
