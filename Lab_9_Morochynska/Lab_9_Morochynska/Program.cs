using System;

// Клас інтерфейсу для відео стріму
public interface IVideoStream
{
    void Display();
}

// Конкретний клас відео стріму
public class ConcreteVideoStream : IVideoStream
{
    public void Display()
    {
        Console.WriteLine("Відображення оригінального відеопотоку.");
    }
}

// Абстрактний клас декоратора
public abstract class VideoStreamDecorator : IVideoStream
{
    protected IVideoStream videoStream;

    public VideoStreamDecorator(IVideoStream videoStream)
    {
        this.videoStream = videoStream;
    }

    public virtual void Display()
    {
        videoStream.Display();
    }
}

// Конкретний декоратор для додавання графічних оверлеїв
public class GraphicOverlayDecorator : VideoStreamDecorator
{
    public GraphicOverlayDecorator(IVideoStream videoStream) : base(videoStream) { }

    public override void Display()
    {
        base.Display();
        AddGraphicOverlay();
    }

    private void AddGraphicOverlay()
    {
        Console.WriteLine("Додавання графічного оверлея до відеопотоку.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення початкового відео стріму
        IVideoStream videoStream = new ConcreteVideoStream();

        // Додавання декоратора з графічним оверлеєм
        videoStream = new GraphicOverlayDecorator(videoStream);

        // Відображення відео стріму з графічним оверлеєм
        videoStream.Display();

        Console.ReadLine();
    }
}
