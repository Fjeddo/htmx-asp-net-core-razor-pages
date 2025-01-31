namespace With.ASP.NET.RazorPages.Pages.Examples.ClickToLoad.Data;

public class Agent
{
    public string Name { get; init; }
    public string Email { get; init; }
    public string ID { get; init; }

    public static Agent[] GetAgents(int page)
    {
        return Enumerable.Range((page + 1) * 10, 10)
            .Select(x =>
                new Agent
                {
                    Name = "Agent Smith",
                    Email = $"void{x}@null.org",
                    ID = Guid.NewGuid().ToString("N").ToUpperInvariant()
                }).ToArray();
    }
}
