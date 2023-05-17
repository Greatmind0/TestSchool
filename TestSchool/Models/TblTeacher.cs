using System;
using System.Collections.Generic;

namespace TestSchool.Models;

public partial class TblTeacher
{
    public int TeacherId { get; set; }

    public string TeacherName { get; set; } = null!;

    public string? Contact { get; set; }

    public int? ClassId { get; set; }

    public int? CityId { get; set; }

    public bool? IsDeleted { get; set; }
}
