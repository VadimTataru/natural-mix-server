using Microsoft.EntityFrameworkCore;
using NaturalMixApi.DB;
using NaturalMixApi.Models;
using NaturalMixApi.Repository.Interface;
using System.Diagnostics;
using Tesseract;

namespace NaturalMixApi.Repository.Implementation
{
    public class ComponentItemRepository : IComponentItemRepository
    {
        private readonly NaturalMixDbContext context;

        public ComponentItemRepository(NaturalMixDbContext context)
        {
            this.context = context;
        }

        public async Task<List<ComponentItem>> GetComponentsInfoAsync(List<string> components)
        {
            List<ComponentItem> result = new();
            for(int i = 0; i < components.Count; i++)
            {
                try
                {
                    components[i] = components[i].Trim(new char[] { ',', ' ', '!' }).ToLower();
                    var item = await context.ComponentItems.FirstOrDefaultAsync(j => j.Name == components[i]);
                    if (item != null)
                        result.Add(item);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            }
            return result;
        }

        public async Task<RecognizedTextResponse> GetComponentsFromImageData(byte[] imageData)
        {
            var text = await Task.Run(() => RecognizeText(imageData));
            var data = await GetComponentsInfoAsync(text.Item2);

            return new RecognizedTextResponse(text.Item1, data);
        }

        /// <summary>
        /// Распознавание текста на основе массива байт представляющих изображение.
        /// </summary>
        /// <param name="imageData">Массив байт, представляющий изображение</param>
        /// <returns>Tuple состоящий из: Item1 - текст, который удалось распознать; Item2 - отдельные строки</returns>
        private static (string, List<string>) RecognizeText(byte[] imageData)
        {
            (string, List<string>) result = new();
            try
            {
                using (var engine = new TesseractEngine(@"E:/VSStudioProjects/TestTesseract/TestTesseract/tessdata", "eng", EngineMode.Default))
                {
                    using (var image = Pix.LoadFromMemory(imageData))
                    {
                        using (var page = engine.Process(image))
                        {
                            var text = page.GetText();
                            result.Item1 = text;
                            if(text != null)
                                result.Item2 = text.Split(new string[] { ",", ".", " - ","- "," -", " « ", " : ", ": ", "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
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
