using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class j1Controller : ControllerBase
    {
        /// <summary>
        /// it is a score of a game where a robot droid has to deliver packages while avoiding obstacles. 
        /// At the end of the game, the final score is calculated based on the following point system: 
        /// Gain 50 points for every package delivered.
        /// Lose 10 points for every collision with an obstacle.
        /// Earn a bonus 500 points if the number of packages delivered is greater than the number of collisions 
        /// with obstacles. 
        /// Your job is to determine the final score at the end of a game
        /// </summary>
        /// <param name="deliveries">Number of packages delivered</param>
        /// <param name="collisions">the number of collisions with an abstacle</param>
        /// <remarks>Here the robot will get bonus points if the number of deliveries are greater than collisions</remarks>
        /// <returns>it returns a int value that are the total points of for that robot</returns>
        /// <example>
        /// deliveries = 5,collisions = 2  POST /api/j1/Delevedroid -> 730
        /// deliveries = 0,collisions = 10 POST /api/j1/Delevedroid -> -100
        /// deliveries = 2,collisions = 3  POST /api/j1/Delevedroid -> 70
        /// </example>
        [HttpPost (template:"delevedroid")]
        public int delevedroid([FromForm]int deliveries, [FromForm] int collisions)
        {
            int total = 0;
            int del = deliveries * 50;
            int col = collisions * 10;
            total = del - col;
            if (deliveries > collisions)
            {
                total = total + 500;
            }
            return total;
        }




        /// <summary>
        /// it is a Post request that will return a string for a dog who love having treats by the mood i.e. either happy or sad based on:
        /// number and size of treats he receives throughout the day. The treats come in three sizes: small, medium, and large. 
        /// His happiness score can be measured using the following formula: (1 * s) + (2 * m) + (3 * l)
        /// </summary>
        /// <param name="s">Number of small Treats</param>
        /// <param name="m">Number of Medium Treats</param>
        /// <param name="l">Number of large Treats</param>
        /// <returns>it returns a string value that is either 'Sad' or 'Happy'</returns>
        /// <example>
        /// s = 3,m = 1,l = 0 POST /api/j1/dogtreats -> Sad
        /// s = 3,m = 2,l = 1 POST /api/j1/dogtreats -> Happy
        /// </example>



        [HttpPost(template: "dogtreats")]
        public string dogtreats([FromForm]int s, [FromForm]int m, [FromForm]int l)
        {
            int total = (1 * s) + (2 * m) + (3 * l);
            if (total >= 10)
            {
                return "Happy";
            }
            else
            {
                return "Sad";
            }

        }

    }
}
