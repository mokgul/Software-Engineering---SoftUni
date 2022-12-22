
namespace CommandPattern.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] commandTokens = args.Split(' ');

            string command = commandTokens[0];
            string[] commandArgs = commandTokens.Skip(1).ToArray();

            Assembly assembly = Assembly.GetEntryAssembly();

            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name.StartsWith(command));
            string result = null;
            if (type != null)
            {
                object obj = Activator.CreateInstance(type);
                MethodInfo method = obj.GetType().GetMethod("Execute");
                result = (string)method.Invoke(obj, new object[] { commandArgs });
            }
            return result;
        }
    }
}
