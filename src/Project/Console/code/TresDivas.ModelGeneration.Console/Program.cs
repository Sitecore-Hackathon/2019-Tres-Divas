using System.IO;
using Feature.Marketing.Model.Collection;

namespace TresDivas.ModelGeneration.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("Generating your model...");

            var model = ProductTrackingModel.Model;

            var serializedModel = Sitecore.XConnect.Serialization.XdbModelWriter.Serialize(model);

            File.WriteAllText("c:\\temp\\" + model.Name + ".json", serializedModel);

            System.Console.WriteLine("Press any key to continue! Your model is here: " + "c:\\temp\\" + model.Name + ".json");
            System.Console.ReadKey();
        }
    }
}
