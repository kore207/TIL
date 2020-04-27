using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DronMap.Models
{
    public class DronIndex
    {
        [Key]
        public int Id { get; set; } //for database

        [Required]
        //[MaxLength(20)]
        public string CusID { get; set; } //자바나 다른 프로그램과 다르게 따로 함수로 작성안해도 get set 이라고만 해도 된다.
        [Required]
        //[MaxLength(20)]
        public string PW { get; set; }
        

    }
}
