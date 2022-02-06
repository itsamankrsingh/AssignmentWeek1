using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentWeek1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of buildings:");
            int numberOfBuildings = Convert.ToInt32(Console.ReadLine());

            int[] buildings = new int[numberOfBuildings + 1];
            Console.WriteLine("Enter number of meters in the building:");
            for (int i = 1; i <= numberOfBuildings; i++)
            {
                buildings[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Enter number of modems:");
            int numberOfModems = Convert.ToInt32(Console.ReadLine());

            int[] modemLocation = new int[numberOfModems + 1];
            Console.WriteLine("Enter Modem location:");
            for (int i = 1; i <= numberOfModems; i++)
            {
                modemLocation[i] = Convert.ToInt32(Console.ReadLine());
            }

            int[] modemRange = new int[numberOfModems + 1];
            Console.WriteLine("Enter Modem range:");
            for (int i = 1; i <= numberOfModems; i++)
            {
                modemRange[i] = Convert.ToInt32(Console.ReadLine());
            }

            //Console.Write("Buildings -> ");
            //for (int i = 1; i <= 5; i++)
            //{
            //    Console.Write(buildings[i] + " ");
            //}
            //Console.WriteLine();
            //Console.Write("Modem Location -> ");
            //for (int i = 1; i <= 2; i++)
            //{
            //    Console.Write(modemLocation[i] + " ");
            //}
            //Console.WriteLine();
            //Console.Write("Modem Range -> ");
            //for (int i = 1; i <= 2; i++)
            //{
            //    Console.Write(modemRange[i] + " ");
            //}
            //Console.WriteLine();

            var modemCover = new List<(int, int)>();

            for(int i = 1;i<= numberOfModems; i++)
            {
                int minCover = modemLocation[i] - modemRange[i];
                if (minCover < 0)
                {
                    minCover = modemLocation[i];
                }
                int maxCover= modemLocation[i] + modemRange[i];
                modemCover.Add((minCover,maxCover));
            }

            /*for (int i = 0; i < numberOfModems; i++)
            {
                Console.WriteLine(modemCover[i].Item1 + " " + modemCover[i].Item2);

            }*/

            

            int[] numberOfModemCoverInBuilding=new int[numberOfBuildings + 1] ;
            for (int i = 1; i <= numberOfBuildings; i++)
            {
                numberOfModemCoverInBuilding[i] = 0;
            }

            for (int i = 1; i <= numberOfBuildings; i++) 
            { 
                foreach(var item in modemCover)
                {
                    if(i>=item.Item1 && i <= item.Item2)
                    {
                        numberOfModemCoverInBuilding[i] = numberOfModemCoverInBuilding[i] + 1;
                    }
                }
            }

            /*for (int i = 1; i <= numberOfBuildings; i++)
            {
                Console.Write(numberOfModemCoverInBuilding[i] + " ");
            }*/

            int countModemCoveredBuildings = 0;

            for (int i = 1; i <= numberOfBuildings; i++)
            {
                if (buildings[i] <= numberOfModemCoverInBuilding[i])
                {
                    countModemCoveredBuildings++;
                }
            }

            Console.WriteLine($"Number of buildings provided with Secure's service are: {countModemCoveredBuildings}");
                
            Console.ReadKey();

        }
    }
}
