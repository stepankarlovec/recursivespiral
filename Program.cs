    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace RecursiveSpiral
    {
        enum Direction { right, down, left, up,};

        class Program
        {


            static void Main(string[] args)
            {
                Controller Control = new Controller();
                Control.generateEmpty();
                Control.generateSpiral(30, 3, Direction.right);
                Control.displayGraphic();
                Console.ReadKey();
            }
        }
        class Controller
        {
            public string[,] graphic = new string[30, 30];
            public int repeat = 1;  
            public void generateSpiral(int len, int delta, Direction direction, int curX = 0, int curY = 0)
            {
            if (len <= 0)
            {
                return;
            }
            (curX, curY) = move(curX, curY, len, direction);
            direction = this.rotate(direction);

            (curX, curY) = move(curX, curY, len, direction);
            direction = this.rotate(direction);

            generateSpiral(len - delta, delta, direction, curX, curY);
            /*
            int currentX = curX;
            int currentY =curY;

                for (int i = 1; i < 5; i++)
                {
                //Trace.WriteLine("XXX - current i = " + i);
                //Trace.WriteLine("XXX - my direction" + direction);
                            Trace.WriteLine("x"+x);
                            Trace.WriteLine("y"+y);
                            //Trace.WriteLine("current i = " + i);
                            //Trace.WriteLine("my direction" + direction);
                        break;
                        case Direction.down:
                        if (repeat > 1)
                        {
                            currentX = 0;
                            currentY = 0;
                        }
                            (int xo, int yo) = this.move(currentX, currentY, len, direction);
                            currentX = xo;
                            currentY = yo;
                            Trace.WriteLine("x" + xo);
                        Trace.WriteLine("y" + yo);
                        break;
                        default:
                                (int xa, int ya) = move(currentX, currentY, len, direction);
                                currentX = xa;
                                currentY = ya;
                                Trace.WriteLine("xa:" + xa);
                                Trace.WriteLine("ya:" + ya);
                                //Trace.WriteLine("current i = " + i);
                                //Trace.WriteLine("my direction" + direction);
                            break;
                    }
                    direction = this.rotate(direction);
                }


            repeat++;
            Trace.WriteLine(len);
                generateSpiral(len, delta, direction, currentX, currentY);
            */
        }

            public (int, int) move(int baseX, int baseY, int delka, Direction direction)
            {
                int lastX = 0;
                int lastY = 0;
                for (int i = 0; i < delka; i++)
                {
                    if (direction == Direction.right)
                    {
                        graphic[baseY, baseX + i] = "@";
                        lastX = baseX + i;
                        lastY = baseY;
                    }
                    if (direction == Direction.down)
                    {
                        graphic[baseY + i, baseX] = "@";
                        lastX = baseX;
                        lastY = baseY + i;
                    }
                    if (direction == Direction.left)
                    {
                        graphic[baseY, baseX - i] = "@";
                        lastX = baseX - i;
                        lastY = baseY;
                    }
                    if (direction == Direction.up)
                    {
                        graphic[baseY - i, baseX] = "@";
                        lastX = baseX;
                        lastY = baseY - i;
                    }
                }
                return (lastX, lastY);
            }

            public Direction rotate(Direction direction)
            {
                if (direction == Direction.right) { return Direction.down; }
                if (direction == Direction.down) { return Direction.left; }
                if (direction == Direction.left) { return Direction.up; }
                if (direction == Direction.up) { return Direction.right; }
                return Direction.right;
            }

            public void generateEmpty()
            {
                for (int i = 0; i < graphic.GetLength(0); i++)
                {
                    for (int d = 0; d < graphic.GetLength(1); d++)
                    {
                        graphic[i, d] = ".";
                    }
                }
            }

            public void displayGraphic()
            {
                for (int i = 0; i < graphic.GetLength(0); i++)
                {
                    for (int d = 0; d < graphic.GetLength(1); d++)
                    {
                        Console.Write(graphic[i, d]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
