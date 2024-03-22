using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTIC.Application.DTOs;
using WebApiTIC.Application.DTOs.Autenticacion;

namespace WebApiTIC.Application.Contracts
{
    public interface IJwtGenerator
    {
        Task<AutorizacionResponse> DevolverToken(AutenticacionResultDto autorizacion);
        Task<AutorizacionResponse> DevolverRefreshToken(RefreshTokenRequest refreshTokenRequest, AutenticacionResultDto autorizacion);
    }
}
