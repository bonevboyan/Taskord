﻿namespace Taskord.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Taskord.Data.Models.Enums;
    using Taskord.Data.Common;

    using static Taskord.Common.DataConstants.Card;

    public class Card : BaseModel
    {
        public Card()
            : base()
        {
            this.Tags = new HashSet<Tag>();
            this.Users = new HashSet<User>();
        }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public TaskCompletion State { get; set; }

        [Required]
        public DateTime? DueDate { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
