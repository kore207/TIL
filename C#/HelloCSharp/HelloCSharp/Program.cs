using System; //namespace 안에 많은 툴들이 들어있다. (보따리)
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloCSharp //내가 만드는 보따리
{
    class Program
    {
        static void Main(string[] args)//가장 먼저 실행되는 함수(운영체제에 의해서 직접 호출되는 유일한 함수)
        {
            Console.WriteLine("Hello C#") ;
            Console.WriteLine("Hello " + args[0]);
            Console.ReadKey() ;            
        }
    }
}
