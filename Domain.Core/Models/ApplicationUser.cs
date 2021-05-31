using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

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
