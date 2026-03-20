namespace Immersion;

public class ThreadDelay : IDelay
{
    public void Wait(int milliseconds) => Thread.Sleep(milliseconds);
}