using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudCert
{
    public class StampUserAgreement
    {
        public string userId { get; set; }
        public float xPos { get; set; }
        public float yPos { get; set; }
        public int pageIndex { get; set; }
        public float width { get; set; }
        public float height { get; set; }


        public string toString()
        {

            StringBuilder sb = new StringBuilder();

            sb.Append(userId);
            sb.Append(",");
            sb.Append(xPos);
            sb.Append(",");
            sb.Append(yPos);
            sb.Append(",");
            sb.Append(pageIndex);
            sb.Append(",");
            if (width > 0)
            {
                sb.Append(width);
                sb.Append(",");
            }
            if (height > 0)
            {
                sb.Append(width);
                sb.Append(",");
            }

            return sb.ToString().Trim(',');

        }
    }
}
