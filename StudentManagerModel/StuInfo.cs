using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagerModel
{
    public class StuInfo
    {
      
        [Description("学生编号")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
               
        [Description("学生姓名")]
        public string UserName { get; set; }

        [Description("学生性别")]
        public string Sex { get; set; }

        [Description("学生联系电话")]
        public string Phone { get; set; }

        [Description("学生描述")]
        public string Description { get; set; }

        [Description("学生爱好")]
        public string Hobby { get; set; }
    }
}
