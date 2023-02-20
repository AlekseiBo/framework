namespace Package.Runtime.Framework.Mediator
{
    public delegate void MediatorCallback<T>(T c) where T : IMediatorCommand;
}