﻿using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace APIEmpresarial.Model
{
    public sealed class Gastos
    {
        public int GastosId { get; set; }   
        [JsonIgnore]
        public Collection<Vendas> _Vendas { get; set; }
        public DateTime  DataGasto { get; set; }
        public double TotalGasto { get; set; }
        
        
    }
}
