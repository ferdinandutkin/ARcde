namespace Auto.Command.Arguments;

internal class TradingCommandArguments
{
    public TradingCommandArguments(string model, int count)
    {
        Model = model;
        Count = count;
    }

    public int Count { get; }

    public string Model { get; }
}