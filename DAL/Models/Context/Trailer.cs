﻿using System;
using System.Collections.Generic;

namespace DAL.Models.Context;

public partial class Trailer
{
    public int Id { get; set; }

    public string Url { get; set; } = null!;

    public int MovieId { get; set; }

    public virtual Movie Movie { get; set; } = null!;
}
