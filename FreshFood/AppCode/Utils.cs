using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshFood.AppCode
{
    public class Utils
    {
        public static Image ConvertBinaryToImage(byte[] data)
        {
            if(data == null)
            {
                return null;
            } 
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }
    }
}
