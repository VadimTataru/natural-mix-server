namespace NaturalMixApi.Repository.Interface
{
    public interface IRecognizeTextRepository
    {
        /// <summary>
        /// Распознавание текста на основе массива байт представляющих изображение.
        /// </summary>
        /// <param name="imageData">Массив байт, представляющий изображение</param>
        /// <returns>Tuple состоящий из: Item1 - текст, который удалось распознать; Item2 - отдельные строки</returns>
        public (string, List<string>) RecognizeText(byte[] imageData);
    }
}
