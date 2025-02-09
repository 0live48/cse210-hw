public class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }
    public int Rating { get; set; } 

    public Entry(string prompt, string response, string date, int rating)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
        Rating = rating;
    }

    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\nRating: {Rating}/5\n";
    }
}
