using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class j3Controller : ControllerBase
    {

        /// <summary>
        /// An Http Get request that takes use inputs in form of sequences(five number code) 
        /// that would be saved as list of strings and then it will give out instructions 
        /// including direction from first two digits and number of steps to take from the 
        /// last three digits.
        /// </summary>
        /// <param name="sequences">List of five-digit sequences given by user</param>
        /// <remarks>
        /// Each instruction need to be five digits.  
        /// The first two digits are the direction of the code:
        /// If their addition is odd than the direction is "left".
        /// Or if their sum is even and not zero, the direction is "right".
        /// Or if their sum is zero, the direction remains the same as the previous instruction.
        /// The last three digits represent the number of steps from the code.
        /// And if the sequence is "99999" process will end and won't take any other input.
        /// </remarks>
        /// <returns>A list of decoded instructions that consists of direction and steps.</returns>
        /// <example>
        /// GET api/J3/code?sequences=57234&sequences=00907&sequences=34100&sequences=99999  ->  
        /// right 234
        /// right 907
        /// left 100
        /// </example>

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
