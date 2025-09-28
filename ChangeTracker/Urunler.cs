using System;
using System.Collections.Generic;

namespace ChangeTracker;

public partial class Urunler
{
    public int Id { get; set; }

    public string UrunAdi { get; set; } = null!;

    public float Fiyat { get; set; }

    public virtual ICollection<Parcalar> Parcalars { get; set; } = new List<Parcalar>();
}
