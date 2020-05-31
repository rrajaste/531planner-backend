﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.Domain;
using Domain.App.Enums;
using Domain.Base;

namespace Domain.App
{
    public class TrainingDayType : TrainingDayType<Guid>, IDomainEntityIdMetadata
    {
    }

    public class TrainingDayType<TKey> : DomainEntityIdMetadata<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        [MaxLength(255)]
        public string Name_eng { get; set; } = default!;
        
        [MaxLength(1024)]
        public string Description_eng { get; set; } = default!;
        
        [MaxLength(255)]
        public string Name_et { get; set; } = default!;
        
        
        [MaxLength(1024)]
        public string Description_et { get; set; } = default!;
    }
}