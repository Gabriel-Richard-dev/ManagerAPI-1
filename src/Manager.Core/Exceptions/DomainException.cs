using System;

namespace Manager.Core.Exceptions;

public class DomainException : Exception
{

    internal List<string> _erros;
    public IReadOnlyCollection<string> Erros => _erros;
    
    public DomainException()
    { }

    public DomainException(string message, List<string> erros) : base(message)
    {
        _erros = erros;
    }

    public DomainException(string message) : base(message)
    { }

    public DomainException(string message, Exception innerException) : base(message, innerException)
    { }
    
}