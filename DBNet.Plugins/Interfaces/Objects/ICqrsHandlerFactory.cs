namespace DBNet.Plugins.Interfaces.Objects
{
    public interface ICqrsHandlerFactory
    {
        ICqrsResponse Handle(ICqrsObject @object);
    }
}