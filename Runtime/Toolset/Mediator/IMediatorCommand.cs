namespace Toolset
{
    public interface IMediatorCommand
    {
        string AsString => this.GetType().ToString();
    }
}