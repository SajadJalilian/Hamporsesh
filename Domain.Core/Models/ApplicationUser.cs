using Microsoft.AspNetCore.Identity;
using System;

namespace Hamporsesh.Domain.Core.Models
{
    public class ApplicationUser : IdentityUser<long>
    {
        public ApplicationUser()
        {
            CreateDateTime = DateTime.Now;
            ShamsiYear = PersianDateTime.Now.Year;
            ShamsiMonth = PersianDateTime.Now.Month;
            ShamsiDay = PersianDateTime.Now.Day;
        }

        public DateTime CreateDateTime { get; set; }
        public int ShamsiYear { get; set; }
        public int ShamsiMonth { get; set; }
        public int ShamsiDay { get; set; }
        public bool IsDeleted { get; set; }
    }
}
