using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using CommonSnappableTypes;
namespace MyExtendableApp
{
    /*
    1 Assembly имяСборки
    2 имяСборки = Assembly.LoadFrom(путьКСборке) //получить путь из opf или с консоси
    3 Assembly.GetTypes() LINQ фильтруем какие типы нам нужны
    4 проходимся по полученынм типам
    5 создаем нужный тип 
        НужныйТип имяПеременной = (НужныйТип)имяСборки.CreateInstance(type.FullName, true) бул для регистра
    6 имяПеременной?.НужныйМетод()
    7 потом у каждого типа можно получить атрибуты GetAttributes(false), проверить нужный ли нам атрибут и обратиться к
    свойствам
    */
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("***** Welcome to MyTypeViewer *****");
            do
            {
                Console.WriteLine("Would you like to load a snap-in? [Y/N]");
                string answer = Console.ReadLine();
                if (answer.Equals("N", StringComparison.OrdinalIgnoreCase)) break;
                try
                {
                    LoadSnapin();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (true); 
        }

        public static void LoadSnapin()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                InitialDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                Filter = "(assemblies (*.dll) |*.dll|All files (*.*) |*.*",
                FilterIndex = 1
            };
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                Console.WriteLine("User cancelled out of the open file dialog.");
                return;
            }
            if (ofd.FileName.Contains("CommonSnappableTypes"))
            {
                Console.WriteLine("CommonSnappableTypes has no snap-ins!");
            }
            else if (!LoadExternalModule(ofd.FileName))
            {
                Console.WriteLine("Nothing Implements IAppFunctionality");
            }   
        }

        private static bool LoadExternalModule(string fileName)
        {
            bool foundSnapIn = false;
            Assembly theSnapInAsm = null;
            try
            {
                theSnapInAsm = Assembly.LoadFrom(fileName);
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error occuried during download:{0}", ex.Message);
                return foundSnapIn;
            }
            var getTypes = from t in theSnapInAsm.GetTypes()
                           where t.IsClass && (t.GetInterface("IAppFunctionality") != null) 
                           select t;
            foreach (Type type in getTypes)
            {
                foundSnapIn = true;
                IAppFunctionality itfApp = (IAppFunctionality)theSnapInAsm.CreateInstance(type.FullName, true);
                itfApp?.DoIt();
                DisplayCompanyData(type);
            }
            return foundSnapIn;
        }

        private static void DisplayCompanyData(Type type)
        {
            var compInfo = from ci in type.GetCustomAttributes(false)
                     where (ci is CompanyInfoAttribute) 
                     select ci;
            foreach(CompanyInfoAttribute attribute in compInfo)
            {
                Console.WriteLine($"More info about {attribute.CompanyName} you can find on {attribute.CompanyUrl}");
            }
        }
    }
}
