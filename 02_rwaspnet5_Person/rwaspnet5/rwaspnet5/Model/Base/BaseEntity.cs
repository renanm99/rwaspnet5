﻿using System.ComponentModel.DataAnnotations.Schema;

namespace rwaspnet5.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
