public class Order
{
    public string Id { get; set; } //get; & set; это так называемые аксессоры get разрешает давать значение свойства, а set изменять его
    public string ItemName { get; set; }
    public decimal Price { get; set; } // Это тип для денег и денежных расчётов. Он хранит число точно, без погрешностей округления, в отличие от double
                                       // Буква m в записи 0.0m (увидим ниже) как раз и говорит компилятору: «это литерал типа decimal, а не double
    public int Quantity { get; set; }

    public Order(string id, string itemName, decimal price, int quantity) // id, itemName, price, quantity — с типами, совпадающими со свойствами.
    {                                                                     // Это и делает его «главным»: через него проходит создание любого заказа.
        Id = id;                                                          // Это конструктор — специальный метод, который вызывается при создании объекта через new
        ItemName = itemName;                                              // Присваиваем значение параметра id свойству Id
        Price = price;
        Quantity = quantity;
    }

    public Order() : this("Неизвестный", "Продукты", 0.0m, 1) { } //this(...) — цепочка конструкторов. "Неизвестный" уходит в Id, "Продукты" уходит в ItemName,
                                                                  //0.0m ноль типа decimal (суффикс m — от слова money), уйдёт в Price, 1 в Quantity

    public Order(string id, string itemName, decimal price) : this(id, itemName, price, 1) { } // Принимаем от пользователя только id,
                                                                                               // itemName и price — про количество он не думает, потому что штучный товар покупают одну штуку. 
                                                                                              //: this(id, itemName, price,
                                                                                              //1) — вызываем главный конструктор,
                                                                                              //передавая три полученных значения как есть и подставляя четвёрку (1) вручную.
    public void Deconstruct(out string itemName, out decimal price, out int quantity) 
        // void — метод не возвращает значение через return. out-параметры — способ передать результат наружу: метод обязан им присвоить значение,
        // снаружи его можно прочитать. Синтаксис var (name, price, qty) = order3; работает благодаря методу Deconstruct(out ...) — он «разбирает» объект на выходные параметры.
    {
        itemName = ItemName; // Записываем в выходной параметр значение свойства ItemName. Слева — локальный out-параметр, справа — свойство.
        price = Price;
        quantity = Quantity;
    }
}