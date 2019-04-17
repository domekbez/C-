using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class FuzzySet
{
    public Dictionary<int, float> dict;

    public FuzzySet(params (int a, float b)[] m)
    {

        dict = new Dictionary<int, float>();
        foreach ((int a, float b) value in m)
        {
            if(!dict.ContainsKey(value.a))
            dict.Add(value.a, value.b);
        }

    }
    public override string ToString()
    {
       
        string a = "{";
        for(int i=0;i<dict.Count();i++)
        {
            a += "(";
            a += dict.ElementAt(i).Key;
            a += ",";
            a += dict.ElementAt(i).Value;
            a += ")";
        }
        a += "}";
        return a;
    }

    public static FuzzySet operator +(FuzzySet a, (int b,float c) val)
    {
        if (!a.dict.ContainsKey(val.b))
            a.dict.Add(val.b, val.c);
        else
        {
            if (a.dict[val.b] < val.c)
                a.dict[val.b] = val.c;
        }
        return a;
    }
    public static FuzzySet operator +(FuzzySet a, FuzzySet b)
    {
        FuzzySet c = new FuzzySet();
        for (int i = 0; i < a.dict.Count(); i++)
        {
            c.dict.Add(a.dict.ElementAt(i).Key, a.dict.ElementAt(i).Value);
        }
        for(int j=0;j<b.dict.Count();j++)
        {
            if (!c.dict.ContainsKey(b.dict.ElementAt(j).Key))
                c.dict.Add(b.dict.ElementAt(j).Key, b.dict.ElementAt(j).Value);
            else
            {
                if (b.dict.ElementAt(j).Value > c.dict[b.dict.ElementAt(j).Key])
                    c.dict[b.dict.ElementAt(j).Key] = b.dict.ElementAt(j).Value;
            }
        }
        return c;
    }
    public static FuzzySet operator/(FuzzySet a, FuzzySet b)
    {
        FuzzySet c = new FuzzySet();
        for (int i = 0; i < a.dict.Count(); i++)
        {
            c.dict.Add(a.dict.ElementAt(i).Key, a.dict.ElementAt(i).Value);
        }
        for (int j = 0; j < b.dict.Count(); j++)
        {
            if (c.dict.ContainsKey(b.dict.ElementAt(j).Key))
            {
                if (b.dict.ElementAt(j).Value > c.dict[b.dict.ElementAt(j).Key])
                    c.dict[b.dict.ElementAt(j).Key] = b.dict.ElementAt(j).Value - c.dict[b.dict.ElementAt(j).Key];
                if (b.dict.ElementAt(j).Value < c.dict[b.dict.ElementAt(j).Key])
                    c.dict[b.dict.ElementAt(j).Key] = c.dict[b.dict.ElementAt(j).Key] - b.dict.ElementAt(j).Value;
                else
                    c.dict.Remove(b.dict.ElementAt(j).Key);
            }
            
        }
        return c;
    }
    public static FuzzySet operator-(FuzzySet a)
    {
        FuzzySet c = new FuzzySet();
        for (int i = 0; i < a.dict.Count(); i++)
        {
            c.dict.Add(a.dict.ElementAt(i).Key, 1-a.dict.ElementAt(i).Value);
        }
        
        return c;
    }
    public static bool operator ==(FuzzySet a, FuzzySet b)
    {
        if (a.dict.Count != b.dict.Count)
            return false;
        for (int i = 0; i < a.dict.Count(); i++)
        {
            if (!b.dict.ContainsKey(a.dict.ElementAt(i).Key))
            {
                return false;
            }
            else
            {
                if (b.dict[a.dict.ElementAt(i).Key] != a.dict.ElementAt(i).Value)
                    return false;
            }
        }
        return true;
    }

    public static bool operator !=(FuzzySet a, FuzzySet b)
    {
        return !(a == b);
    }
    public static bool operator >(FuzzySet a, FuzzySet b)
    {
        FuzzySet c = new FuzzySet();
        c = a + b;
        if (c.dict.Count() > a.dict.Count())
            return false;
        for (int i = 0; i < a.dict.Count(); i++)
        {
            if (a.dict.ElementAt(i).Value != c.dict.ElementAt(i).Value)
            {
                return false;
            }
        }
        return true;
    }
    public static bool operator <(FuzzySet a, FuzzySet b)
    {
        FuzzySet c = new FuzzySet();
        c = b + a;
        if (c.dict.Count() > b.dict.Count())
            return false;
        for (int i = 0; i < a.dict.Count(); i++)
        {
            if (b.dict.ElementAt(i).Value != c.dict.ElementAt(i).Value)
            {
                return false;
            }
        }
        return true;
    }

    public override bool Equals(object obj)
    {
        return this == (FuzzySet)obj;
    }


}
