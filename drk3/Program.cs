bool drk3(Queue<char> queue)
{
    if (queue is null) return false;

    // Variables Auxiliares
    var openSimbols = "{[(";
    var closeSimbols = "}])";
    Dictionary<char, int> type = new()
    {
        { '{', 1 },
        { '}', 1 },
        { '[', 2 },
        { ']', 2 },
        { '(', 3 },
        { ')', 3 }
    };
    Stack<char> stack = new();

    // Mientras la cola tenga elementos.
    while (queue.Count > 0)
    {
        // Sacamos el primer elemento.
        char currentSimbol = queue.Dequeue();

        // ¿Es de Apertura? entonces lo agregamos a la Pila.
        if (openSimbols.Contains(currentSimbol))
        {
            stack.Push(currentSimbol);
        }
        // ¿Es de cierre? entonces verificamos...
        else if (closeSimbols.Contains(currentSimbol))
        {
            // ¿El stack esta vacio? o ¿son del mismo tipo? (Ej: "[" y "]" son brackets) entonces falso 
            if (stack.Count == 0 || type[stack.Pop()] != type[currentSimbol]) return false;
        }
    }

    // Terminamos de recorrer ¿el stack esta vacio? entonces verdadero.
    if (stack.Count == 0) return true;
    return false;
}

List<Queue<char>> test = new()
{
    new("{[()]}".ToCharArray()),
    new("{[[()()]()][()]}".ToCharArray()),
    new("[[]]".ToCharArray()),
    new("[()((()))]".ToCharArray()),
    new("{[]}".ToCharArray()),
    new("(())".ToCharArray()),
    new("{[))]}".ToCharArray()),
    new("[]]".ToCharArray()),
    new("[(}]".ToCharArray()),
    new("[((())])".ToCharArray()),
    new("}}}".ToCharArray())
};

foreach (var item in test)
{
    Console.WriteLine($"input: {string.Join(" ", item),-31} ouput: {drk3(item)}");
}