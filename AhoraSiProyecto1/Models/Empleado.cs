using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhoraSiProyecto1.Models;

public partial class Empleado
{
    [Key] // Esto indica que es la clave primaria
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Esto indica que es autoincremental
    public int IdEmpleado { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public int? Edad { get; set; }

    public string? Email { get; set; }
}
