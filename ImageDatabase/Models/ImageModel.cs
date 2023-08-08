using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageDatabase.Models
{
    public class ImageModel
    {
        public int ImageId { get; set; }
        public byte[] ImageData { get; set; }
    }

}