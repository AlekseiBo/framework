namespace Toolset
{
    public interface IMediatorCommand
    {
        string Type => this.GetType().ToString();
    }
}