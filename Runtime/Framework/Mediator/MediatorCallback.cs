namespace Framework
{
    public delegate void MediatorCallback<T>(T c) where T : IMediatorCommand;
}