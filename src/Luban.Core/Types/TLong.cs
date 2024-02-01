using Luban.TypeVisitors;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Luban.Types;

public class TLong : TType
{
    string sInType = "";
    public static TLong Create(bool isNullable, Dictionary<string, string> tags, string inType)
    {
        return new TLong(isNullable, tags, inType);
    }

    public override string TypeName => sInType;

    private TLong(bool isNullable, Dictionary<string, string> tags, string inType) : base(isNullable, tags)
    {
        sInType = inType;
    }

    public override bool TryParseFrom(string s)
    {
        if (TypeName.IndexOf('u') < 0)
        {
            return long.TryParse(s, out _);
        }
        else
        {
            return ulong.TryParse(s, out _);
        }
    }

    public override void Apply<T>(ITypeActionVisitor<T> visitor, T x)
    {
        visitor.Accept(this, x);
    }

    public override void Apply<T1, T2>(ITypeActionVisitor<T1, T2> visitor, T1 x, T2 y)
    {
        visitor.Accept(this, x, y);
    }

    public override TR Apply<TR>(ITypeFuncVisitor<TR> visitor)
    {
        return visitor.Accept(this);
    }

    public override TR Apply<T, TR>(ITypeFuncVisitor<T, TR> visitor, T x)
    {
        return visitor.Accept(this, x);
    }

    public override TR Apply<T1, T2, TR>(ITypeFuncVisitor<T1, T2, TR> visitor, T1 x, T2 y)
    {
        return visitor.Accept(this, x, y);
    }

    public override TR Apply<T1, T2, T3, TR>(ITypeFuncVisitor<T1, T2, T3, TR> visitor, T1 x, T2 y, T3 z)
    {
        return visitor.Accept(this, x, y, z);
    }
}
