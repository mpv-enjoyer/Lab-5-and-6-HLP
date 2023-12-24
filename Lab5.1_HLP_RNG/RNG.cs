return;
public static class Rng
{
    static Random rng = new Random();
    public static int Next(int min, int max)
    {
        return rng.Next(min, max + 1);
    }
}