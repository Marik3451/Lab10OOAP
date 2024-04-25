using System;

class Paragraph
{
    public string Content { get; set; }

    public Paragraph(string content)
    {
        Content = content;
    }
    public void Accept(ParagraphVisitor visitor)
    {
        visitor.Visit(this);
    }
}

abstract class ParagraphVisitor
{
    public abstract void Visit(Paragraph paragraph);
}

class InlineParagraphVisitor : ParagraphVisitor
{
    public override void Visit(Paragraph paragraph)
    {
        Console.WriteLine($"[Рядок] {paragraph.Content}");
    }
}

class ColumnParagraphVisitor : ParagraphVisitor
{
    public override void Visit(Paragraph paragraph)
    {
        Console.WriteLine($"[Стовпчик] {paragraph.Content}");
    }
}

class TextProcessorSimulator
{
    public void Simulate()
    {
        Paragraph paragraph1 = new Paragraph("Перший абзац");
        Paragraph paragraph2 = new Paragraph("Другий абзац");
        Paragraph paragraph3 = new Paragraph("Третій абзац");

        ParagraphVisitor visitor;

        Console.WriteLine("Виберіть стиль оформлення:");
        Console.WriteLine("1. У рядок");
        Console.WriteLine("2. У стовпець");

        string choice = Console.ReadLine();

        if (choice == "1")
        {
            visitor = new InlineParagraphVisitor();
        }
        else if (choice == "2")
        {
            visitor = new ColumnParagraphVisitor();
        }
        else
        {
            Console.WriteLine("Неправильний вибір. Використовуємо стиль у радок за замовчуванням.");
            visitor = new InlineParagraphVisitor();
        }

        paragraph1.Accept(visitor);
        paragraph2.Accept(visitor);
        paragraph3.Accept(visitor);
    }
}

class Program
{
    static void Main(string[] args)
    {
        TextProcessorSimulator simulator = new TextProcessorSimulator();
        simulator.Simulate();
    }
}
