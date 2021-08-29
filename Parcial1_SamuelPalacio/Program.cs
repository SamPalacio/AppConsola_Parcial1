using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1_SamuelPalacio
{
    class Program
    {

        static void Main(string[] args)
        {
            Node _startingPoint = new Node(1,-3);
            Node _endingPoint = new Node(2,0);
            Stopwatch s = new Stopwatch();

            Dictionary<String, Node> _block = new Dictionary<String, Node>();
            Queue<Node> _queue = new Queue<Node>();
            List<Node> _path = new List<Node>();

            SearchPath.GenerateMaze(_block);

            s.Start();
            _path = SearchPath.GetPath(_block,_startingPoint, _endingPoint);
            s.Stop();


            SearchPath.Print(_path, _startingPoint, _endingPoint);
            
            Console.WriteLine("Breadth-first search took " + s.ElapsedTicks + " ticks and " + s.ElapsedMilliseconds +" ms");
            Console.WriteLine("Breadth-first search path contains " + _path.Count + " states");
            Console.WriteLine();

        }




    }









}
