namespace LangVault.Management.Application.Common.Exceptions;
public class NotFoundException(string name, int key, int? code = null)
    : BaseException($"Entity \'{name}\' ({key}) was not found", code: code);
