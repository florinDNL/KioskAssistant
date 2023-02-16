using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using allGlobals;

namespace gridUI
{
    public class grid
    {   
        /*
          *The start menu group is represented graphically by a grid (Nested List).
          *The list contains 6 other lists (columns), each containing 4 boolean values representing the smallest unit (cell), equivalent to a 1x1 Tile or 50px.
          *This totals to 24 (6*4) cells which is the theoretical limit for a Group with 6 columns.
          *If the boolean corresponding to a cell is true, that means the cell is free and can be occupied by a tile or a part of a tile.
        */
        public static List<List<bool>> gridInit()
        {
            List<List<bool>> grid = new();
            for (int x = 0; x < 6; x++)
            {
                List<bool> col = new();
                for (int y = 0; y < 4; y++)
                {
                    col.Add(true);
                }
                grid.Add(col);
            }
            return grid;           
        }

        public static bool drawTile(Graphics g, string size, int x, int y)
        {            
            Pen p = new(Color.Black, 2);
            p.Alignment = PenAlignment.Center;
            SolidBrush b = new(Color.FromArgb(0, 191, 255));

            int w = 0;
            int h = 0;

            if      (size == "1x1")
            {
                w = 50;
                h = 50;
            }
            else if (size == "2x2")
            {
                w = 100;
                h = 100;
            }
            else if (size == "4x2")
            {
                w = 200;
                h = 100;
            }
            else if (size == "4x4")
            {
                w = 200;
                h = 200;
            }

            if (w + x > 300 | h + y > 200)
            {
                MessageBox.Show("Out of bounds.");
                return false;
            }
            /*The following computes whether the cells required for a tile are free. To calculate the position of a tile and its corresponding indexes
            inside the grid, we first calculate the total area of the tile by iterating through each 50px it occupies, first on the x axis, 
            and then on the y axis. We start from its initital position x / 50 (first index) until the (x + w) / 50 (last index). The same goes for the y axis and height.          

            If any free cells are found during the iterations, they are added to a list before being set to false. This is to ensure we do not commit
            any changes before finishing the iterations, whereby we would break the loop but the free cells would remain set to false.*/
            else
            { 
                List<List<int>> freeCells = new();
                for (int i = x / 50; i < (x + w) / 50; i++)
                {
                    for (int j = y / 50; j < (y + h) / 50; j++)
                    {
                        if (perFormObjects.tileGrid[i][j] == false)
                        {
                            return false;
                        }
                        else
                        {
                            List<int> indexes = new();
                            indexes.Add(i);
                            indexes.Add(j);
                            freeCells.Add(indexes);
                        }
                    }
                }
                foreach (List<int> indexes in freeCells)
                {
                    int k = indexes[0];
                    int l = indexes[1];
                    perFormObjects.tileGrid[k][l] = false;
                }
                g.DrawRectangle(p, x, y, w, h);
                g.FillRectangle(b, x, y, w, h);
                return true;
            }       
        }
    }
}