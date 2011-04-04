﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CitizenJournalismNetworkServer.Domain.Models
{
    public class Collection
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.DatabaseGenerationOption.Identity)]
        public int Id { get; set; }

        public string Href { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public bool AreCategoriesFixed { get; set; }

        public virtual ICollection<ContentType> AcceptedTypes { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public DateTime DateCreated { get; set; }

        public string AtomId { get; set; }

    }

}