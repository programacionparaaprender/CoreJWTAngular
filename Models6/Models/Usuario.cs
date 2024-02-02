using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace Models.Models
{

    public class Usuario
    {
        [Key]
        public int id { get; set; }

        [StringLength(32)]
        [Required]
        public string nombre { get; set; }

        [StringLength(32)]
        [Required]
        public string email { get; set; }

        [StringLength(32)]
        [Required]
        public string password { get; set; }


        public class Mapeo
        {
            public Mapeo(EntityTypeBuilder<Usuario> mapeoUsuario)
            {
                mapeoUsuario.HasKey(x => x.id);
                mapeoUsuario.Property(x => x.email).HasColumnName("email");
                mapeoUsuario.ToTable("Usuario");
                //mapeoAutor.HasOne(x => x.Autor);
            }
        }
    }
}
