using System;
using System.Collections.Generic;

namespace TestSchool.Models;

public partial class TblStudent
{
    public int StudentId { get; set; }

    public string StudentName { get; set; } = null!;

    public string? Contact { get; set; }

    public int? ClassId { get; set; }

    public int? CityId { get; set; }

    public bool? IsActive { get; set; }
}
