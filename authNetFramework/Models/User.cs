using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace authNetFramework.Models
{
    public class User
    {
        [DisplayName("Логин")]
        public string Name { get; set; }
    }
}
