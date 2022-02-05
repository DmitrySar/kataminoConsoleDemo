//1. Вывод фигур по номеру
//2. Поворот фигур
//3. Вертикальное/горизонтальное отображение

Dictionary<int, string> figures = new Dictionary<int, string>()
{
    {1, @"
  *
***
 * 
" },
    {2, @"
****
  * 
" },
    {3, @"
  *
***
*  " }
};

string template = figures[2];
ConsoleColor color = ConsoleColor.Blue;
char background = '·';
char symbol = '▓';

Figure f = new Figure(template, color, symbol, background);
ToConsole(f);
bool isContinue = true;
while(isContinue)
{
    ConsoleKey key = Console.ReadKey().Key;
    if (key == ConsoleKey.Escape) isContinue = false;
    else ToConsole(transform(f, key));
}

Figure transform(Figure f, ConsoleKey key)
{
    switch(key)
    {
        case ConsoleKey.R: return f.RotateRight();
        case ConsoleKey.L: return f.RotateLeft();
        case ConsoleKey.H: return f.HorizontalFlip();
        case ConsoleKey.V: return f.VerticalFlip();
        default: return f;
    }
}
void ToConsole(Figure figure)
{
    Console.Clear();
    Console.ForegroundColor = figure.Color;
    Console.WriteLine(figure);
    Console.ResetColor();
}

