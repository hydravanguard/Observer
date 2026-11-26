
using System;
using System.Collections.Generic;

// Інтерфейс спостерігача
interface IObserver
{
    void Update(string message);
}

// Клас підписника
class Subscriber : IObserver
{
    public string Name { get; }

    public Subscriber(string name)
    {
        Name = name;
    }

    public void Update(string message)
    {
        Console.WriteLine($"{Name} отримав повідомлення: {message}");
    }
}

// Клас каналу новин
class NewsChannel
{
    private List<IObserver> subscribers = new List<IObserver>();

    // Додавання підписника
    public void Subscribe(IObserver observer)
    {
        subscribers.Add(observer);
        Console.WriteLine("Підписника додано.");
    }

    // Видалення підписника
    public void Unsubscribe(IObserver observer)
    {
        subscribers.Remove(observer);
        Console.WriteLine("Підписника видалено.");
    }

    // Розсилка повідомлення
    public void Notify(string message)
    {
        foreach (IObserver subscriber in subscribers)
        {
            subscriber.Update(message);
        }
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        NewsChannel channel = new NewsChannel();

        Subscriber anna = new Subscriber("Анна");
        Subscriber oleksii = new Subscriber("Олексій");

        channel.Subscribe(anna);
        channel.Subscribe(oleksii);

        Console.WriteLine("\nПублікація новини:");
        channel.Notify("Вийшла нова стаття!");

        Console.WriteLine("\nВидаляємо одного підписника:");
        channel.Unsubscribe(anna);

        Console.WriteLine("\nПублікація наступної новини:");
        channel.Notify("З'явилися нові подробиці!");
    }
}
