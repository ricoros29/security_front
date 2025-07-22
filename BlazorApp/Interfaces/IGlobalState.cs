using BlazorApp.DTO.Security;

namespace BlazorApp.Interfaces
{
    public interface IGlobalState
    {
        string Token { get; set; }
        ResultLoginDTO? Session { get; set; }
    }
}
