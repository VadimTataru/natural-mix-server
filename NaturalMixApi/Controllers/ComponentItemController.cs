using Microsoft.AspNetCore.Mvc;
using NaturalMixApi.DB;
using NaturalMixApi.Models;
using NaturalMixApi.Repository.Interface;

namespace NaturalMixApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentItemController : ControllerBase
    {
        private readonly IComponentItemRepository componentItemRepository;
        private readonly IRecognizeTextRepository recognizerTextRepository;
        public ComponentItemController(IComponentItemRepository componentItemRepository, IRecognizeTextRepository recognizerTextRepository)
        {
            this.componentItemRepository = componentItemRepository;
            this.recognizerTextRepository = recognizerTextRepository;
        }
        /// <summary>
        /// POST Запрос на получение списка компонентов из БД по списку строк.
        /// </summary>
        /// <param name="components">Список строк</param>
        /// <returns>Список компонентов ComponentItem</returns>
        [HttpPost]
        public async Task<List<ComponentItem>> GetComponentsInfo(List<string> components)
        {
            return await componentItemRepository.GetComponentsInfoAsync(components);
        }

        /// <summary>
        /// POST Запрос на получение списка компонентов из БД по данным изображения, представленным в виде массива байт.
        /// </summary>
        /// <param name="imageData">Массив байт, представляющий изображение</param>
        /// <returns>Модель RecognizedTextResponse</returns>
        [HttpPost("recognize")]
        public async Task<RecognizedTextResponse> RecognizeImage(byte[] imageData)
        {
            var text = await Task.Run(() => recognizerTextRepository.RecognizeText(imageData));
            var data = await componentItemRepository.GetComponentsInfoAsync(text.Item2);
            return new RecognizedTextResponse(text.Item1, data);
        }

        /*[HttpGet]
        public async Task<IActionResult> Create()
        {
            var data = new List<ComponentItem>()
            {
                new ComponentItem("water", "Основной компонент практически всей косметики (исключения безводная косметика). Обеспечивает необходимую структуру. В косметике используется в основном деминерализованная вода прощедшая очистку методом обратного осмоса. ", "Натуральное", 10f),
                new ComponentItem("sodium chloride", "Регулятор вязкости к косметических продуктах. ", "Натуральное", 10f),
                new ComponentItem("citric acid", "Белое кристаллическое вещество без запаха с приятным вкусом. Растворяется в воде и этаноле. Широко распространена в природе, получают из природных растительных источников, (лимон, брусника и др.) либо ферментацией из сахара. " +
                "Используется в косметических препаратах как консервант, разбавитель, модификатор рН, пеногаситель, хелатирующий агент. Оказывает на кожу вяжущее, очищающее и отбеливающее действие. " +
                "Вводится в состав очищающих кремов, депиляториев, ополаскивателей для, волос, красок для волос, кремов от веснушек. Иногда используется как регулятор рН, косметических изделий., Антиоксидант. ", "Натуральное / возможно синтетическое", 10f),

                new ComponentItem("glycol distearate", "загуститель, стабилизатор сотавов, смягчает кожу", "Синтетическое", 7f),
                new ComponentItem("hexylene glycol", "растворитель, снижает вязкость, стабилизатор составов", "Синтетическое", 7f),

                new ComponentItem("cl 60730", "Краситель. Может вызвать раздражение кожи", "Синтетическое", 4f),

                new ComponentItem("sodium laureth sulfate", "Поверхностно-активное вещество. Может вызвать аллергию и раздражение кожи", "Синтетическое", 2f),
                new ComponentItem("dimethicone", "Плёнкообразователь. Возможна индивидуальная непереносимость", "Синтетическое", 1f),
                new ComponentItem("cocamide mea", "Загуститель. Возможна индивидуальная непереносимость", "Синтетическое", 1f),
                new ComponentItem("carbomer", "Загуститель. Может вызвать аллергию и раздражение кожи", "Синтетическое", 1f),
                //10
                new ComponentItem("behenyl beeswax", "Консервант. Возможна индивидуальная непереносимость", "Натуральное", 9f),
                new ComponentItem("с9-12 alkane", "Растворитель.", "Синтетическое", 9f),
                new ComponentItem("isopropyl myristate", "В косметике используется для того, чтобы снизить жирность жирной фазы в кремах. " +
                "Он оказывается на кожу поверхностное действие, обладает хорошим смягчающим действием, славится своей способностью закреплять и удерживать ароматы, " +
                "не оставляет на коже неприятной жирной пленки, создает хорошее скольжение, способствует равномерному рассредоточению цветовых пигментов в косметике. " +
                "Являться комедогемном.", "Синтетическое", 9f),

                new ComponentItem("benzyl alcohol", "Растворитель. Допускается применение в качестве консерванта при низких концентрациях. Используется в основном в парфюмерии", "Натуральное / возможно синтетическое", 7f),
                new ComponentItem("triethyl citrate", "Растворитель.", "Синтетическое", 7f),
                new ComponentItem("citronellol", "Ароматизатор. Он напоминает свежий и одновременно тёплый цветочный тон.", "Натуральное", 7f),

                new ComponentItem("limoene", "Существует в виде двух изомерных форма, одна имеет яккий цитрусовый запах, другая - хвойный. Используется в качестве отдушки в косметических средствах. " +
                "Обладает сильным антимикробным действием", "Натуральное / возможно синтетическое", 4f),
                new ComponentItem("linalool", "Используется в качестве отдушки (аромат ландыша) в косметических средствах.", "Натуральное / возможно синтетическое", 4f),
                new ComponentItem("geraniol", "Ароматизатор с запахом розы. Может вызвать фотоаллергические реакции", "Натуральное / возможно синтетическое", 4f),

                new ComponentItem("butane", "Кондиционер. Может быть токсичным", "Синтетическое", 1f),
                new ComponentItem("propane", "Дезодорант. Может вызвать аллергию и раздражение кожи", "Синтетическое", 1f),

                new ComponentItem("allantoin", "Смягчает роговой слой, сужает поры. Обладает вяжущим, противовоспалительным заживляющим действиями.", "Натуральное", 9f),
                new ComponentItem("propylene glycol", "Универсальный растворитель, используется во многих косметических средствах.", "Синтетическое", 9f),
                new ComponentItem("octyldodecanol", "В целом ингредиент не является опасным, относится к классу жирных спиртов. " +
                "Может выступать в роли фиксатива аромата, стабилизатора эмульсий, так же является кондиционирующим агентом для кожи и для волос.", "Синтетическое", 8f),
                new ComponentItem("polyamino sugar condensate", "Кондиционирование кожи, Увлажнитель", "Синтетическое", 9f),

                new ComponentItem("cyclomethicone", "Кремнийорганический полимер. Легколетучая вязкая жидкость. Обеспечивает кондиционирующий эффект, уменьшает продолжительность сушки волос.", "Синтетическое", 7f),
                new ComponentItem("tocopheryl acetate", "Эффективен как антиоксидант, предотвращает окисление ненасыщенных липидов. " +
                "Обладает витаминной активностью, проникая в глубокие слои эпидермиса гидролизуется в витамин Е. " +
                "Вводится в состав средств по уходу за кожей.", "Синтетическое", 7f),
                new ComponentItem("white mineral oil", "Жидкое масло, продукт нефтепереработки высокой очистки. Применяется для смягчения, смачивания и растворения других ингредиентов.", "Натуральное", 6f),
                new ComponentItem("sodium polyacrylate", "Многофункциональный высокоэффективный полимер, обладающий эмульгирующими, стабилизирующими и загущающими свойствами и хорошими сенсорными характеристиками. Идеально подходит для создания рецептур без эмульгатора", "Синтетическое", 7f),

                new ComponentItem("methylisothiazolinone", "Бесцветная жидкость со слабым запахом. Консервант широко спектра действия против бактерий, менее активен против грибов.", "Синтетическое", 4f)


            };

            await context.ComponentItems.AddRangeAsync(data);
            await context.SaveChangesAsync();

            var res = await context.ComponentItems.ToListAsync();
            return Ok(res);
        }*/
    }
}
