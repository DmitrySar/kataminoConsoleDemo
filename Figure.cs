internal class Figure
{
    private string template;
    private ConsoleColor color;
    private char symbol;
    private char background;

    public Figure(string template, ConsoleColor color, char symbol, char background)
    {
        this.template = template;
        this.color = color;
        this.symbol = symbol;
        this.background = background;
        format();
    }

    public ConsoleColor Color
    {
        get { return color; }
    }
    private void format()
    {
        template = template
        .Replace(' ', background)
        .Replace('*', symbol)
        .Replace("\r\n", "\n")
        .Trim();
    }
    public override string ToString()
    {
        return template;
    }
    public Figure RotateLeft()
    {
        string res = "";
        string[] lines = template.Split("\n");
        for (int i = lines[0].Length - 1; i >= 0; i--)
        {
            foreach (string line in lines)
                res += line[i];
            res += "\n";
        }
        template = res.Trim();
        return this;
    }
    public Figure RotateRight()
    {
        return this.RotateLeft().RotateLeft().RotateLeft();
    }
    public Figure HorizontalFlip()
    {
        string[] lines = template.Split('\n');
        string res = "";
        foreach (string line in lines)
        {
            char[] chars = line.ToArray();
            Array.Reverse(chars);
            foreach (char c in chars) res += c;
            res += "\n";
        }
        template = res.Trim();
        return this;
    }
    public Figure VerticalFlip()
    {
        return this.RotateLeft()
            .HorizontalFlip()
            .RotateRight();
    }
}