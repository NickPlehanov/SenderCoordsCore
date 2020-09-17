using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SenderCoordCore.Models {
    [Table("Coords")]
    public class Coords {
        [Key]
        public Guid coo_RecordID { get; set; }
        public string coo_imei { get; set; }
        public string coo_longitude { get; set; }
        public string coo_latitude { get; set; }
    }
}
