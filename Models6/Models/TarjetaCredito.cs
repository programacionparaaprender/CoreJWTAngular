using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace Models.Models
{
    public class TarjetaCredito
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Titular { get; set; }

        //[Column(Order = 2, TypeName = "VARCHAR", IsUnique = true)]
        [StringLength(16)]
        [Required]
        public string NumeroTarjeta { get; set; }

        [StringLength(5)]
        [Required]
        public string fechaExpiracion { get; set; }

        [StringLength(3)]
        [Required]
        public string CVV { get; set; }


        public TarjetaCredito()
        {
            this.Id = 0;
        }

        public class Mapeo
        {
            public Mapeo(EntityTypeBuilder<TarjetaCredito> mapeoTarjetaCredito)
            {
                mapeoTarjetaCredito.HasKey(x => x.Id);
                mapeoTarjetaCredito.Property(x => x.Titular).HasColumnName("Titular");
                mapeoTarjetaCredito.ToTable("TarjetaCredito");
                //mapeoAutor.HasOne(x => x.Autor);
            }
        }
    }
}
