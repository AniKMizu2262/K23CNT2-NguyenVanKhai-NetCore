using System;
using System.Collections.Generic;

namespace Nvk_Lesson11.Models;

public partial class NvkEmployee
{
    public int NvkEmpId { get; set; }

    public string? NvkEmpName { get; set; }

    public string? NvkEmpLevel { get; set; }

    public DateOnly? NvkEmpStartDate { get; set; }

    public bool? NvkEmpStatus { get; set; }
}
