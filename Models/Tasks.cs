﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SKL.Models;

public partial class Tasks
{
    [Map("id_task")]
    public int Id { get; set; }
    [Map("id_usr")]
    public int IdUser { get; set; }
    [Map("id_fase")]
    public int IdFase { get; set; }
    [Map("accion")]
    public string Accion { get; set; }
    [Map("id_aspect")]
    public int IdAspect { get; set; }
    [Map("id_evidences")]
    public int IdEvidences { get; set; }

}