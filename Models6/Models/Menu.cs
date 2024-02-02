using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace Models.Models
{
    public class Menu
    {
        [Key]
        public int id { get; set; }

        [StringLength(32)]
        [Required]
        public string nombre { get; set; }

        [StringLength(32)]
        [Required]
        public string url { get; set; }

        [Required]
        public int hijo { get; set; }

        public class Mapeo
        {
            public Mapeo(EntityTypeBuilder<Menu> mapeoMenu)
            {
                mapeoMenu.HasKey(x => x.id);
                mapeoMenu.Property(x => x.nombre).HasColumnName("nombre");
                mapeoMenu.ToTable("Menu");
            }
        }
    }
}
