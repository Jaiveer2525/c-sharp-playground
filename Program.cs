using System;

namespace HelloWorld
{
    class HelloWorlder
    {
        static void Main(String[] args){
            if (args.Length > 0 && args[0] == "-s"){}
            else{
                Console.WriteLine("Hello World");
            }
        }
    }
}
