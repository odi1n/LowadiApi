namespace Lowadi.Models
{
    public class Skills
    {
        /// <summary>
        /// Итого
        /// </summary>
        public double Total { get; set; }

        /// <summary>
        /// Выносливость
        /// </summary>
        public double Endurance { get; set; }

        /// <summary>
        /// Скорость
        /// </summary>
        public double Speed { get; set; }

        /// <summary>
        /// Выездка
        /// </summary>
        public double Dressage { get; set; }

        /// <summary>
        /// Галоп
        /// </summary>
        public double Gallop { get; set; }

        /// <summary>
        /// Рысь
        /// </summary>
        public double Lynx { get; set; }

        /// <summary>
        /// Прыжки
        /// </summary>
        public double Jumps { get; set; }
    }

    public class Characteristics
    {
        /// <summary>
        /// Порода
        /// </summary>
        public string Breed { get; set; }

        /// <summary>
        /// Виды
        /// </summary>
        public string Types { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Цвет
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Заводчик
        /// </summary>
        public string Breeder { get; set; }

        /// <summary>
        /// Возраст
        /// </summary>
        public string Age { get; set; }

        /// <summary>
        /// Рост
        /// </summary>
        public string Height { get; set; }

        /// <summary>
        /// Вес
        /// </summary>
        public string Weight { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public string DateBirth { get; set; }
    }

    public class Horses : Base
    {
        /// <summary>
        /// Завод
        /// </summary>
        public string Factory { get; set; }

        /// <summary>
        /// Энергия
        /// </summary>
        public int Energy { get; set; }

        /// <summary>
        /// Здоровье
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// Настроение
        /// </summary>
        public int Mood { get; set; }

        /// <summary>
        /// Навыки
        /// </summary>
        public Skills Skills { get; set; }

        /// <summary>
        /// Характеристики
        /// </summary>
        public Characteristics Characteristics { get; set; }

        /// <summary>
        /// Проверка, спит ли лошадь
        /// </summary>
        public bool IsSleep { get; set; }

        public string Params_1 { get; set; }
        public string Params_2 { get; set; }
        public string Params_3 { get; set; }
        public string Params_4 { get; set; }
        public string Value_1 { get; set; }
    }
}