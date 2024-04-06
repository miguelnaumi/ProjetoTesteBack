using DomainProjetoBack.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteProjetoBack
{
    public static class ActionResultExtensions
    {
        public static ResponseMicroService<T> GetValue<T>(this ActionResult<T> actionResult)
        {
            if (actionResult.Result is OkObjectResult okObjectResult)
            {
                var responseMicroService = okObjectResult.Value as ResponseMicroService<T>;
                if (responseMicroService != null && responseMicroService.StatusCode == 200)
                {
                    return responseMicroService;
                }
            }
            throw new InvalidOperationException("O resultado não foi bem-sucedido ou não possui valor.");
        }
    }
}
