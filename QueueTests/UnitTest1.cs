using Enqueue;

namespace QueueTests;

public class Tests
{
    Queue queue = new();
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void EqualPriorityTest() // тест на корректность работы элементов с одинаковым приоритетом
    {
        queue.Enqueue(1, 1);
        queue.Enqueue(2, 1);
        queue.Enqueue(3, 1);

        int[] x = new int[3];
        for (int i = 0; i < 3; i++)
        {
            x[i] = queue.Dequeue();
        }
        Assert.That(x[0] == 1 & x[1] == 2 & x[2] == 3);
    }

    public void CorrectPriorityTest()   // тест на корректность работы системы приоритетов
    {
        queue.Enqueue(1, 1);
        queue.Enqueue(2, 5);
        queue.Enqueue(3, 3);

        int[] x = new int[3];
        for (int i = 0; i < 3; i++)
        {
            x[i] = queue.Dequeue();
        }
        Assert.That(x[0] == 2 & x[1] == 1 & x[2] == 3);
    }
}
