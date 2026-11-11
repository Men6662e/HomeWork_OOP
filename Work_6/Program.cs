class Program
{
    static void Main()
    {
        Order order1 = new Order(); // Конструктор по умолчанию задаёт: Id = "UNKNOWN", ItemName = "Продукты", Price = 0.0m, Quantity = 1
        Order order2 = new Order("ORD-002", "Клавиатура", 2499.99m); // quantity = 1 добавится внутри, передастся в главный конструктор; m — тип decimal
        Order order3 = new Order("ORD-003", "Ноутбук", 59999.00m, 3); // 4 аргумента → прямой вызов главного конструктора; quantity = 3; объект годится для деконструкции
        Order order4 = new Order { ItemName = "Мышь", Price = 1499.00m }; // Конструктор по умолчанию + инициализатор свойств; Id="UNKNOWN", Quantity=1, остальные переопределены

        Console.WriteLine($"order1: {order1.Id}, {order1.ItemName}, {order1.Price}, x{order1.Quantity}"); // Интерполяция ($) подставляет значения из выражений в { } — без склеивания через +
        Console.WriteLine($"order2: {order2.Id}, {order2.ItemName}, {order2.Price}, x{order2.Quantity}"); // Вывод для order2, order3, order4 — проверка корректности каждого способа создания объекта
        Console.WriteLine($"order3: {order3.Id}, {order3.ItemName}, {order3.Price}, x{order3.Quantity}");
        Console.WriteLine($"order4: {order4.Id}, {order4.ItemName}, {order4.Price}, x{order4.Quantity}");

        var (name, price, qty) = order3; // Компилятор найдёт Deconstruct(out string, out decimal, out int) и разложит объект: name ← ItemName, price ← Price, qty ← Quantity

        Console.WriteLine($"\nДеконструкция order3: название = {name}, цена = {price}, количество = {qty}"); // \n в начале — пустая строка для отделения вывода деконструкции от списка заказов
    }
}