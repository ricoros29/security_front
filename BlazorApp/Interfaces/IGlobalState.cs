using BlazorApp.DTO.Security;

namespace BlazorApp.Interfaces
{
    public interface IGlobalState
    {
        ResultLoginDTO? Session { get; set; }
    }
}
