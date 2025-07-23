using BlazorApp.DTO.Security;
using BlazorApp.Interfaces;

namespace BlazorApp.DTO
{
    public class GlobalState : IGlobalState
    {
        public ResultLoginDTO? Session { get; set; }

    }
}
