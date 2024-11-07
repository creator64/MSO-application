namespace core.Parsing;

public interface ArgumentParser<T>
{
    public T parse(string argument);
}