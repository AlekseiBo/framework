namespace Toolset
{
    public delegate void MediatorCallback<T>(T c) where T : IMediatorCommand;
}