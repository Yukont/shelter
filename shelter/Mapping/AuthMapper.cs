using BLL.DTO;
using shelter.Models;

namespace shelter.Mapping
{
    internal class AuthMapper : BaseMapper<AuthDTO, LoginViewModel>
    {
    }
    internal class AuthMapperReg : BaseMapper<AuthDTO, RegisterViewModel>
    {
    }
}
