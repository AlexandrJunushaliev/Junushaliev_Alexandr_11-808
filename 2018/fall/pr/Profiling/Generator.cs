using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profiling
{
    class Generator
    {
        public static string GenerateDeclarations()
        {
            var result = new StringBuilder("\n");
            var power = 0;
            while (power < 10)
            {
                result.Append($"struct S{Math.Pow(2, power)}{{");
                for (var i = 0; i < Math.Pow(2, power); i++)
                {
                    result.Append($"byte Value{i}; ");
                }
                result.Append($"}}class C{Math.Pow(2, power)}{{");

                for (var i = 0; i < Math.Pow(2, power); i++)
                {
                    result.Append($"byte Value{i}; ");
                }
                result.Append($"}}");
                power++;
            }
            return result.ToString();
        }

        public static string GenerateArrayRunner()
        {
            var result = new StringBuilder($"public class ArrayRunner : IRunner{{");
            var power = 0;
            while (power < 10)
            {
                result.Append($"\tvoid PC{Math.Pow(2, power)}(){{" +
                $"var array = new C{Math.Pow(2, power)}[Constants.ArraySize];" +
                $"for (int i = 0; i < Constants.ArraySize; i++) array[i] = new C{Math.Pow(2, power)}();}}" +
                $"void PS{Math.Pow(2, power)}(){{" +
                $"var array = new S{Math.Pow(2, power)}[Constants.ArraySize];}}");
                power++;
            }
            result.Append("" + GenerateCallRunner() + "}");
            return result.ToString();
        }

        public static string GenerateCallRunner()
        {
            var result = GenerateDeclaration(0);
            result.Append($"public void Call(bool isClass, int size, int count){{");
            var power = 0;
            while (power < 10)
            {
                result.Append($"if(isClass && size == {Math.Pow(2, power)}){{" +
                    $"var o = new C{Math.Pow(2, power)}(); " +
                    $"for (int i = 0; i < count; i++) PC{Math.Pow(2, power)}(o);" +
                    $"return;}}" +
                    $"if(!isClass && size == {Math.Pow(2, power)}){{" +
                    $"var o = new S{Math.Pow(2, power)}(); " +
                    $"for (int i = 0; i < count; i++) PS{Math.Pow(2, power)}(o);" +
                    $"return;}}");
                power++;
            }
            result.Append($"throw new ArgumentException();" +
                $"}}}}");
            return result.ToString();
        }

        public static StringBuilder GenerateDeclaration(int power)
        {
            var result = new StringBuilder();
            result.Append($"public class CallRunner : IRunner{{");
            while (power < 10)
            {
                result.Append($"void PC{Math.Pow(2, power)}(C{Math.Pow(2, power)} o){{ }}" +
                    $"void PS{Math.Pow(2, power)}(S{Math.Pow(2, power)} o){{ }}");
                power++;
            }
            return result;
        }
    }
}