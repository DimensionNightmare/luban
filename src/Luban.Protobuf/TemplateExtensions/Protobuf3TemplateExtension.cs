
using Luban.CodeFormat;
using Luban.Defs;
using Luban.Protobuf.TypeVisitors;
using Luban.Types;
using Luban.Utils;
using Scriban.Runtime;

namespace Luban.Protobuf.TemplateExtensions;

public class Protobuf3TemplateExtension : ScriptObject
{
    public static string PreDecorator(TType type)
    {
        if (type.IsNullable)
        {
            return "optional";
        }
        else if (type.IsCollection)
        {
            if (type is TMap)
            {
                return "";
            }
            else
            {
                return "repeated";
            }
        }
        else
        {
            return "";
        }
    }

    public static string PreExtend(Dictionary<string, string> extends)
    {
        if (extends == null || extends.Count == 0)
        {
            return "";       
        }

        string str = "";

        foreach (var pair in extends)
        {
            str += string.Format("({0})={1}", pair.Key, pair.Value);
            if(pair.Value != extends.Last().Value)
            {
                str += ",";
            }
        }

        return $"[{str}]";
    }
}
