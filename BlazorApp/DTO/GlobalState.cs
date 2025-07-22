using BlazorApp.DTO.Security;
using BlazorApp.Interfaces;

namespace BlazorApp.DTO
{
    public class GlobalState : IGlobalState
    {
        public string Token { get; set; } = string.Empty;

        public ResultLoginDTO? Session { get; set; }

    }
}
