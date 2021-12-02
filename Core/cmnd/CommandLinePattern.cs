using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerL.Core.cmnd
{
    public class CommandLinePattern
    {
        public string Name { get; set; }

        public List<string> Parameters { get; set; }

        public List<string> Options { get; set; }


        public CommandLinePattern HasOption(string name)
        {
            Options.Add(name);
            return this;
        }

        public CommandLinePattern HasParameter(string name)
        {
            Parameters.Add(name);
            return this;
        }

        public virtual bool TryParse(string[] args, out ICommand result)
        {
            result = null;
            // Конечно, наш шаблон не может соответствовать пустой командной строке.
            if (args.Length == 0)
            {
                return false;
            }
            // И он не может соответствовать какой-то другой команде.
            if (args[0] != Name)
            {
                return false;
            }
            //Собрать пробелы в директории

            var properties = new Dictionary<string, string>();
            var nextParameterIndex = 0;

            for (int i = 1; i < args.Length; i++)
            {
                if (args[i].StartsWith("-"))
                {
                    var parameterWithoutHyphen = args[i].Substring(1);
                    var nameValue = parameterWithoutHyphen.Split(':');
                    if (nameValue.Length == 1)
                        properties.Add(nameValue[0], null);
                    else
                        properties.Add(nameValue[0], nameValue[1]);
                }
                else
                {
                    var name = Parameters[nextParameterIndex++];

                    var value = args[i];
                    properties.Add(name, value);
                }
            }

            // Для команды с имененем Help мы найдём класс HelpCommand:
            var className = "FileManagerL.Core."+ Name + "Command";
            var type = Type.GetType(className);
            // И создадим его экземпляр:
            result = (ICommand)Activator.CreateInstance(type);

            // Теперь значения всех параметров запишем в свойства
            // только что созданного экземляра:
            foreach (var property in properties)
            {
                var name = property.Key;
                var value = property.Value;

                type.GetProperty(name)
                    .SetValue(result, value);
            }

            return true;
        }

        public virtual ICommand Parse(string[] args)
        {
            ICommand result;
            if (TryParse(args, out result))
            {
                return result;
            }
            throw new FormatException();
        }

        public static CommandLinePattern operator |(CommandLinePattern left, CommandLinePattern right)
        {
            return new OrCommandLinePattern(left, right);
        }

    }
}
