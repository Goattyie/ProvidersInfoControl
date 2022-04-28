using System.Text.Json.Serialization;
using ProvidersInfoControl.Domain.Dtos.Get;

namespace ProvidersInfoControl.Tools.Dtos;

public enum CodeResult
{
    Ok,
    Bad,
    NoContext
}

public interface IOperationResult
{
    public CodeResult CodeResult { get; }
}
public class OkOperationResult<TResultDto> : IOperationResult
{
    public OkOperationResult(TResultDto obj)
    {
        Result = obj;
    }
    [JsonIgnore]
    public CodeResult CodeResult => CodeResult.Ok;
    public TResultDto Result { get; }
}
public class BadOperationResult : IOperationResult
{
    public BadOperationResult(params string[] errors)
    {
        Errors = errors;
    }
    [JsonIgnore]
    public CodeResult CodeResult => CodeResult.Bad;
    public IEnumerable<string> Errors { get; }
}
public class NoContentOperationResult : IOperationResult
{
    [JsonIgnore]
    public CodeResult CodeResult => CodeResult.NoContext;
}

public static class OperationResult
{
    public static IOperationResult Ok<TResultDto>(TResultDto obj)  => new OkOperationResult<TResultDto>(obj);
    public static IOperationResult NoContent() => new NoContentOperationResult();
    public static IOperationResult Bad(params string[] errors) => new BadOperationResult(errors);
}