using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class MovieDTO:ResultDTO
    {
        public MovieDTO()
        {
            DirectorId= 1;
        }
        public int ID { get; set; }
        public string MovieName { get; set; }
        public string Description { get; set; }
        public int DirectorId { get; }
    }
}
