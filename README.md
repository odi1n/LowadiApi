# Lowadi Bot

![GitHub release (latest by date)](https://img.shields.io/badge/C%23%20-%20.Net%20Framework%204.6.1-blueviolet)

## Обертка над игрой:
- [Lowadi](https://www.lowadi.com/)
- [Howrse](https://www.howrse.com/)

## Возможности:
| **Функционал**                | **Сделано** | **В планах** |
|:----------------------------- |:-----------:|:------------:|
|                               |             |              |
| Авторизация                   |      +      |      -       |
|                               |             |              |
| ***Магазин***                 |             |              |
| Покупка                       |      +      |      -       |
| Продажа                       |      +      |      -       |
| Информация о моих продуктах   |      +      |      -       |
|                               |             |              |
| ***Получить все заводы***     |      +      |      -       |
|                               |             |              |
| ***Получить лошадей завода*** |      +      |      -       |
|                               |             |              |
| ***Лошадь***                  |             |              |
| **Уход**                      |             |              |
| Дать молоко                   |      +      |      -       |
| Кормить                       |      +      |      -       |
| Поиск                         |      +      |      -       |
| Ласкать                       |      +      |      -       |
| Чистить                       |      +      |      -       |
| Морковь                       |      +      |      -       |
| Смесь                         |      +      |      -       |
| Играть                        |      +      |      -       |
|                               |             |              |
| ***Ночь***                    |             |              |
| Отправить спать               |      +      |      -       |
| Вырастить                     |      +      |      -       |
|                               |             |              |
| ***Кск***                     |      +      |      -       |
|                               |             |              |
| ***Миссия***                  |      +      |      -       |
|                               |             |              |
| ***Прогулки***                |             |              |
| Лес                           |      +      |      -       |
| Гор                           |      +      |      -       |
|                               |             |              |
| ***Тренировка***              |             |              |
| Выносливость                  |      +      |      -       |
| Скорость                      |      +      |      -       |
| Выездка                       |      +      |      -       |
| Галоп                         |      +      |      -       |
| Рысь                          |      +      |      -       |
| Прыжки                        |      +      |      -       |
|                               |             |              |
| **Соревнование**              |      -      |      +       |
|                               |             |              |
| **Размножение**               |      -      |      +       |

## Документация
### Авторизация
```C#  
string userName = "UserName";  
string password = "Password";  
  
ILowadiApi lowApi = new LowadiApi();  
var info = await lowApi.Login(userName, password);  
if (info.Errors.Count > 0)  
    Console.WriteLine("не удалось авторизоваться");    
```
### Покупка
```C#
var buy = await lowApi.Shop.Buy(new ShopData() { 
    Id = ItemsType.Apple, 
    Nombre = 15, 
}); # Купить 15 яблок
```
### Продажа
```C#
var sell = await lowApi.Shop.Sale(new ShopData() { 
    Id = ItemsType.Apple, 
    Nombre = 15, 
}); # Продать 15 яблок
```
### Получить мои продукты
```C#
List<ItemsType> data = await lowApi.Shop.GetInformation(new List<ItemsType>() {  
    ItemsType.CompoundFeed,  
    ItemsType.Apple,  
    ItemsType.SeedsPass,  
    ItemsType.Carrot,  
    ItemsType.Fertilizer_1,  
    ItemsType.Fertilizer_2  
});
```
