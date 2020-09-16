using System;

namespace PostgresCRUD.Models
{
    public class Patient
    {
        //public string Id { get; set; } = Guid.NewGuid().ToString();
        //public string Name { get; set; }
        //public string Address { get; set; }
        //public string City { get; set; }
        //public float Age { get; set; }
        //public string Gender { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public float age { get; set; }
        public string gender { get; set; }
    }
}
