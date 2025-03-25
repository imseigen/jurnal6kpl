public class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        if (title == null)
        {
            throw new ArgumentNullException("Judul video tidak boleh null");
        }

        if (title.Length > 200)
        {
            throw new ArgumentException("Judul video tidak boleh lebih dari 200  karakter");
        }
        Random random = new Random();
        this.id = random.Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        try
        {
            if (count < 0)
                throw new ArgumentException("Play count tidak boleh negatif");

            if (count > 25000000)
                throw new ArgumentException("Penambahan play count maksimal 25.000.000 per panggilan");

            checked
            {
                playCount += count;
            }
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("[ERROR] Overflow play count: " + ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("[ERROR] " + ex.Message);
        }
    }

    public void printVideoDetails()
    {
        Console.WriteLine("ID: " + this.id);
        Console.WriteLine("Title: " + this.title);
        Console.WriteLine("PlayCount: " + this.playCount); 
    }

    public int GetPlayCount()
    {
        return playCount;
    }

    public string GetTitle()
    {
        return title;
    }
}

class Program
{
    static void Main(string[] args)
    {
        SayaTubeVideo video = new SayaTubeVideo("Testing --- Testing");
        video.printVideoDetails();

    }
}