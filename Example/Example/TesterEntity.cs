using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

public class Tester
{
    [Key]
    public int id_tester { get; set; }
    
    public string name_tester { get; set; }

    public string Avatar { get; set; }
}
