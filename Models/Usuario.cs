﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace SKL.Models;

public partial class Usuario
{
    [Map("id_usr")]
    public int IdUser { get; set; }
    [Map("name")]
    public string Name { get; set; }
    [Map("usr_name")]
    public string UserName { get; set; }
    [Map("usr_pass")]
    public string UserPassword { get; set; }
    [Map("id_usr_type")]
    public int IdRole { get; set; }
    [Map("usr_type_name")]
    public string RoleName { get; set; }
    [Map("id_usr_position")]
    public int IdPosition { get; set; }
    [Map("position_name")]
    public string PositionName { get; set; }
    [Map("id_shift")]
    public int IdShift { get; set; }
    [Map("shift_name")]
    public string ShiftName { get; set; }
    [Map("id_usr_department")]
    public int IdDepartment { get; set; }
    [Map("department_name")]
    public string DepartmentName { get; set; }
    [Map("emp_no")]
    public int EmpNo { get; set; }
    [Map("usr_img")]
    public string ImagePath { get; set; }
    [Map("Email")]
    public string Email { get; set; }



    public virtual ICollection<Tasks> Actions { get; set; } = new List<Tasks>();

    public virtual Shift IdShiftNavigation { get; set; }

    public virtual Department IdUsrDepartmentNavigation { get; set; }

    public virtual Position IdUsrPositionNavigation { get; set; }

    public virtual UserType IdUsrTypeNavigation { get; set; }
}