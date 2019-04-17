using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Matrix
{
    public int Rows;
    public int Columns;
    public Matrix(int r, int c, double[,] tab)
    {
        if(tab==null || r<0|| c<0 || r>tab.GetLength(0) || c>tab.GetLength(1))
        {
            Rows = -1;
            Columns = -1;
            return;
        }
        Rows = r;
        Columns = c;
    }
    public abstract double GetValue(int r, int c);
    public abstract void SetValue(int r, int c, double val);

    public void Print()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
                Console.Write("{0} ", GetValue(i, j));
            Console.Write("\n");
        }
    }


}
public class ArrayMatrix : Matrix
{
    public double[,] elems;

    public ArrayMatrix(int r, int c, double[,] tab):base(r,c,tab)
    {
        if (tab == null ||  Rows==-1 || Columns==-1)
        {
            elems = null;
            return;
        }

        elems = new double[r, c];
        Rows = r;
        Columns = c;
        for (int i = 0; i < Rows; i++)
            for (int j = 0; j < Columns; j++)
                elems[i, j] = tab[i, j];      
            
    }
    public override double GetValue(int r, int c)
    {
        if (r < 0 || c < 0 || r >= elems.GetLength(0) || c >= elems.GetLength(1))
            return double.MinValue;
        return elems[r, c];
    }
    public override void SetValue(int r, int c, double val)
    {
        if (r >= 0 && c >= 0 && r < elems.GetLength(0) && c < elems.GetLength(1))
            elems[r, c] = val;
    }

    //public override void Print()
    //{
        
    //    for (int i = 0; i < Rows; i++)
    //    {
    //        for (int j = 0; j < Columns; j++)
    //            Console.Write("{0} ", elems[i, j]);
    //        Console.Write("\n");
    //    }
    //}


}
public class SparseMatrix:Matrix
{
    public double[][,] elems;
    public SparseMatrix(int r, int c, double[,] tab):base(r,c,tab)
    {
        int ilezer = 0;
        int m = 0, n = 0;

        if (tab == null || Rows == -1 || Columns == -1)
        {
            elems = null;
            return;
        }
        elems = new double[r][,];
        Rows = r;
        Columns = c;
        for (int i = 0; i < Rows; i++)
        {
            ilezer = 0;
            for(int j=0;j<Columns;j++)
            {
                if (tab[i,j] == 0)
                    ilezer++;
            }
            elems[i] = new double[Columns - ilezer,2];
        }
        for (int i = 0; i < Rows; i++, m++)
        {
            n = 0;
            for (int j = 0; j < Columns; j++)
            {
                if (tab[i, j] != 0)
                {
                    elems[m][n,0] = tab[i, j];
                    elems[m][n, 1] = j;
                    n++;
                }
            }
        }
    }
    public override double GetValue(int r, int c)
    {
        if (r < 0 || c < 0 || r >= Rows || c >= Columns)
            return double.MinValue;
        for(int i=0;i<elems[r].GetLength(0);i++)
        {
            if (elems[r][i, 1] == c)
                return elems[r][i, 0];
        }
        return 0;

         
    }
    public override void SetValue(int r, int c, double val)
    {
        if (r < 0 || c < 0 || r >= Rows || c >= Columns)
            return;
        for (int i = 0; i < elems[r].GetLength(0); i++)
        {
            if (elems[r][i, 1] == c)
                elems[r][i, 0] = val;
        }
        
    }

    //public override void Print()
    //{
    //    for (int i = 0; i < Rows; i++)
    //    {
    //        for (int j = 0; j < elems[i].GetLength(0); j++)
    //            Console.Write("{0} ", elems[i][j,0]);
    //        Console.Write("\n");
    //    }
    //}


}

