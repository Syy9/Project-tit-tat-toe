using System;

public static class ActionExtention
{
    public static void Call(this Action self)
    {
        if(self != null)
        {
            self();
        }
    }

    public static void Call<T1>(this Action<T1> self, T1 arg1)
    {
        if(self != null)
        {
            self(arg1);
        }
    }

    public static void Call<T1,T2>(this Action<T1,T2> self, T1 arg1, T2 arg2)
    {
        if (self != null)
        {
            self(arg1, arg2);
        }
    }
}
