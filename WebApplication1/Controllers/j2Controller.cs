using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class j2Controller : ControllerBase
    {
        ///<summary>
        /// An http Get method that takes the name of the pepper from user and 
        /// outputs the total spiceness in SHU(Scolville Heat Units).
        /// </summary>
        /// <param name="ingredients">A list of pepper names that are separated by ,(commas)</param>
        /// <returns>
        /// It returns an INT value that represents the total spiceness level in SHU (Scolville Heat Units) .
        /// </returns>
        /// <remarks>
        ///The available peppers and their SHU values are:
        /// Poblano = 1500
        /// Mirasol = 6000
        /// Serrano = 15500
        /// Cayenne = 40000
        /// Thai = 75000
        /// Habanero = 125000
        /// </remarks>
        /// <example>
        /// GET : api/J2/ChiliPeppers?Ingredients=Poblano,Cayenne,Thai,Poblano  -> 118000
        /// GET : api/J2/ChiliPeppers?Ingredients=Habanero,Habanero,Habanero,Habanero,Habanero  -> 625000
        /// GET : api/J2/ChiliPeppers?Ingredients=Poblano,Mirasol,Serrano,Cayenne,Thai,Habanero,Serrano  -> 278500
        /// </example>

        [HttpGet(template: "chilipeppers")]
        public int chilipeppers(string ingridients)
        {
            int Poblano = 1500;
            int Mirasol = 6000;
            int Serrano = 15500;
            int Cayenne = 40000;
            int Thai = 75000;
            int Habanero = 125000;

            int total_spice = 0;

            string[] list_peppers = ingridients.Split(',');

            foreach (string pepper in list_peppers)
            {
                string trim_pepper = pepper.Trim();

                if (trim_pepper == "Poblano")
                {
                    total_spice += Poblano;
                }
                else if (trim_pepper == "Mirasol")
                {
                    total_spice += Mirasol;
                }
                else if (trim_pepper == "Serrano")
                {
                    total_spice += Serrano;
                }
                else if (trim_pepper == "Cayenne")
                {
                    total_spice += Cayenne;
                }
                else if (trim_pepper == "Thai")
                {
                    total_spice += Thai;
                }
                else
                {
                    total_spice += Habanero;
                }
            }

            return total_spice;
        }




        /// <summary>
        /// An HttpPost request to get the amount of days it will take to go over the amount
        /// of infected people given by user (Pram. M)
        /// based on infected people on day 0 and the amount of people they would infect
        /// </summary>
        /// <param name="p">determine when a total of more than user given amouny of people have had the disease</param>
        /// <param name="n">the number of people who have the disease on Day 0.</param>
        /// <param name="r">The number of infected people</param>
        /// <returns>it returns a value of the total days it will take to surpass the p no. of infected people.</returns>
        /// <example>
        /// p=750, n=1, r=5 GET /api/j2/epidemiology -> 4
        /// p=10, n=2, r=1 GET /api/j2/epidemiology -> 5
        /// </example>

        [HttpPost(template: "epidemiology")]
        public int epidemiology([FromForm]int p, [FromForm]int n, [FromForm]int r) 
        {
            int total = 0;
            int infected = n;
            int newinfected = n;
            while(infected <= p)
            {
                total++;
                newinfected = newinfected * r;
                infected = infected + newinfected;
            }
            return total;
        }
    }
}
