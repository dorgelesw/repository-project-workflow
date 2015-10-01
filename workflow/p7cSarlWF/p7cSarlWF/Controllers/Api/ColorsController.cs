using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace p7cSarlWF.Controllers.Api
{
    public class ColorsController : ApiController
    {

        [HttpGet]
        public String GetColors()
        {
            var count = 0;
            var sb = new StringBuilder();
            sb.Append("<table width='100%'><tbody><tr>");

            foreach (var color in Enum.GetNames(typeof(KnownColor)))
            {
                var colorValue = ColorTranslator.FromHtml(color);
                var html = string.Format("#{0:X2}{1:X2}{2:X2}", colorValue.R, colorValue.G, colorValue.B);
                sb.AppendFormat("<td bgcolor='{0}'>&nbsp;</td>", html);
                if (count < 20)
                {
                    count++;
                }
                else
                {
                    sb.Append("</tr><tr>");
                    count = 0;
                }
            }
            sb.Append("</tbody></table>");
            return sb.ToString();
        }

    }
}
