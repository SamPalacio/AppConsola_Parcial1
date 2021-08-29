using System;
using System.Collections.Generic;
using System.Text;

namespace Parcial1_SamuelPalacio
{
    public class Coordinates
    {
        public int x;
        public int y;

        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return "(" + x + "," + y + ")";
        }
    }

    public class Node
    {
        public Coordinates cords;
        public Node(int posX, int posY)
        {
            cords = new Coordinates(posX, posY);
        }
        public bool isExplored = false;
        public Node isExploredFrom = null;


        public override string ToString()
        {
            return cords.ToString();
        }

    }
    public class SearchPath
    {
         

        public static  void GenerateMaze(Dictionary<String, Node> block)
        {
       

            Node[] nodes = new Node[19];
            nodes[0] = new Node(0,0);
            nodes[1] = new Node(0,-1);
            nodes[2] = new Node(0,-2);
            nodes[3] = new Node(0,-3);
            nodes[4] = new Node(1,-1);
            nodes[5] = new Node(1,-3);
            nodes[6] = new Node(1,-4);
            nodes[7] = new Node(2,0);
            nodes[8] = new Node(2,-1);
            nodes[9] = new Node(2,-2);
            nodes[10] = new Node(2,-4);
            nodes[11] = new Node(3,-1);
            nodes[12] = new Node(3,-2);
            nodes[13] = new Node(3,-3);
            nodes[14] = new Node(3,-4);
            nodes[15] = new Node(4,0);
            nodes[16] = new Node(4,-1);
            nodes[17] = new Node(4,-2);
            nodes[18] = new Node(4,-4);

            
            foreach (Node node in nodes)
            {
                String pos = node.ToString();

                if (block.ContainsKey(pos))
                {
                    Console.WriteLine("2 Nodes present in same position. i.e nodes overlapped.");
                }
                else
                {
                    block.Add(pos, node);
                }
            }

            Console.WriteLine("Hacia abajo es la Y negativa| hacia la derecha es la X positiva");
           
            
            //construccion del tablero, tiene muchos for :C
            int contador = 0;
            string[,] tablero = new string[5, 5];
            for (int i = 0; i < 5; i++)
            {

                for (int j = 0; j < 5; j++)
                {
                    
                    if (nodes[contador].cords.x == i && nodes[contador].cords.y == -j)
                    {
                        contador++;
                        tablero[i, j] = ("O");
                    }
                    else
                    {
                        tablero[i, j] = ("x");
                    }
                   
                }
            }
            for (int i = 0; i < 5; i++)//perdon por tantos for :C
            {
                Console.WriteLine();

                for (int j = 0; j < 5; j++)
                {
                    Console.Write(tablero[j, i]+" ");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        public static List<Node> GetPath(Dictionary<String, Node> block, Node _startingPoint, Node _endingPoint)
        {

            BFS(block, _startingPoint, _endingPoint);


            List<Node> _path = new List<Node>();

            _path.Add(_endingPoint);

            Node previousNode = block[_endingPoint.ToString()].isExploredFrom;
            while (previousNode != _startingPoint)
            {
                _path.Add(previousNode);
                previousNode = block[previousNode.ToString()].isExploredFrom;
            }

            _path.Add(_startingPoint);
            _path.Reverse();
            return _path;
        }

        public static void BFS(Dictionary<String, Node> _block, Node _startingPoint, Node _endingPoint)
        {

              Queue<Node> _queue = new Queue<Node>();
              
              Node _searchingPoint;      
            
              bool _isExploring = true;
              Coordinates[] _directions = { new Coordinates(0, 1), new Coordinates(1, 0), new Coordinates(0, -1), new Coordinates(-1, 0) };    

            _queue.Enqueue(_startingPoint);
            while (_queue.Count > 0 && _isExploring)
            {
           
                _searchingPoint = _queue.Dequeue(); 
                if (_searchingPoint == _endingPoint) 
                {
                    _isExploring = false;
                }
                else
                {
                    _isExploring = true;
                }
                if(!_isExploring) { return; } 

                foreach (Coordinates direction in _directions)
                {
                    Coordinates neighbourPos = new Coordinates(_searchingPoint.cords.x + direction.x, _searchingPoint.cords.y + direction.y);     
                    
                    if (_block.ContainsKey(neighbourPos.ToString()))            
                    {
                       
                        Node node = _block[neighbourPos.ToString()];

                        if (!node.isExplored)
                        {
                            _queue.Enqueue(node); 
                            node.isExplored = true;
                            node.isExploredFrom = _searchingPoint;
                            
                        }
                    }
                }

            }


        } 
        public static void Print(List<Node> _path, Node _startingPoint, Node _endingPoint)
        {
            Console.WriteLine("Starting point:" + _startingPoint);
            Console.WriteLine("Ending point:" + _endingPoint);
            
            foreach (var item in _path)
            {
                Console.WriteLine(item);
            }
        }

    }
    




}
