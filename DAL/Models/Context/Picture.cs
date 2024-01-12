﻿using System;
using System.Collections.Generic;

namespace DAL.Models.Context;

public partial class Picture
{
    public int Id { get; set; }

    public string Url { get; set; } = null!;

    public int MovieId { get; set; }

    public virtual Movie IdNavigation { get; set; } = null!;
}
