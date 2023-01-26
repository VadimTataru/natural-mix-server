using NaturalMixApi.DB;
using NaturalMixApi.Repository.Interface;
using System.Diagnostics;
using Tesseract;

namespace NaturalMixApi.Repository.Implementation
{
    public class RecognizeTextRepository: IRecognizeTextRepository
    {
        public (string, List<string>) RecognizeText(byte[] imageData)
        {
            (string, List<string>) result = new();
            try
            {
                var path = Path.GetFullPath("tessdata");
                using (var engine = new TesseractEngine(path, "eng", EngineMode.Default))
                {
                    using (var image = Pix.LoadFromMemory(imageData))
                    {
                        using (var page = engine.Process(image))
                        {
                            var text = page.GetText();
                            result.Item1 = text;
                            if (text != null)
                                result.Item2 = text.Split(new string[] { ",", ".", " - ", "- ", " -", " « ", " : ", ": ", "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
                Console.WriteLine("Unexpected Error: " + e.Message);
                Console.WriteLine("Details: ");
                Console.WriteLine(e.ToString());
            }

            return result;
        }
    }
}
