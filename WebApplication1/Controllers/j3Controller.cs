using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class j3Controller : ControllerBase
    {
        [HttpGet(template: "secretinstructions")]
        public string secretinstructions([FromQuery] List<string> lnum)
        {
            string res= "";
            string dir= "";

            foreach (var num in lnum)
            {
                if (num == "99999")
                {
                    break;
                }

                if (num.Length != 5)
                {
                    res += "Enter five digits only\n";
                    continue;
                }

                int fnum = int.Parse(num.Substring(0, 1));
                int snum = int.Parse(num.Substring(1, 1));
                int total = fnum + snum;

                string steps = num.Substring(2);
                string fin_dir = "";
                if (total == 0)
                {
                    fin_dir = dir;
                }
                else if ((total % 2) != 0)
                {
                    fin_dir = "Left";
                }
                else
                {
                    fin_dir = "Right";
                }

                res += $"{fin_dir} {steps}\n";
                dir = fin_dir;
            }

            return res;
        }


    }
}
