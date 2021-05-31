using System;

namespace Hamporsesh.Domain.Core.Models
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreateDateTime = DateTime.Now;
            ShamsiYear = PersianDateTime.Now.Year;
            ShamsiMonth = PersianDateTime.Now.Month;
            ShamsiDay = PersianDateTime.Now.Day;
        }
        public long Id { get; set; }

        public DateTime CreateDateTime { get; set; }
        public int ShamsiYear { get; set; }
        public int ShamsiMonth { get; set; }
        public int ShamsiDay { get; set; }
        public bool IsDeleted { get; set; }
    }
}
