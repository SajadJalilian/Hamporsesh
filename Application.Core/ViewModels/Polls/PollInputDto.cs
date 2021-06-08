﻿using Hamporsesh.Domain.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Hamporsesh.Application.Core.ViewModels.Polls
{
    public class PollInputDto
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "فیلد باید پر شورد")]
        public string Title { get; set; }
        [Required(ErrorMessage = "فیلد باید پر شود")]
        public string Description { get; set; }
        public long UserId { get; set; }
        public PollStatus PollStatus { get; set; }

    }
}
