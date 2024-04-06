using Microsoft.AspNetCore.Mvc;
using ApplicationProjetoBack.Interfaces;
using DomainProjetoBack.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System.Diagnostics;

namespace ServiceProjetoBack.Controllers
{
    public class BaseController : ControllerBase
    {
        protected Stopwatch _stopwatch;
        protected BaseController()
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }

        [NonAction]
        public async Task<ActionResult<TResult>> ResolveResponse<TResult>(Task<TResult> result, EnumeratorsCommons.DataOperation operation)
        {
            try
            {
                TResult val = await result;
                switch (operation)
                {
                    case EnumeratorsCommons.DataOperation.Insert:
                        return Created("", new ResponseMicroService<TResult>
                        {
                            StatusCode = 200,
                            Message = "Registro(s) inserido(s) com sucesso!",
                            Result = val,
                            ProcessingTime = ProcessingTime()
                        });
                    case EnumeratorsCommons.DataOperation.Update:
                        return Ok(new ResponseMicroService<TResult>
                        {
                            StatusCode = 200,
                            Message = "Registro(s) atualizado(s) com sucesso!",
                            Result = val,
                            ProcessingTime = ProcessingTime()
                        });
                    case EnumeratorsCommons.DataOperation.Delete:
                        if (val == null)
                        {
                            return NoContent();
                        }

                        return Ok(new ResponseMicroService<TResult>
                        {
                            StatusCode = 200,
                            Message = "Registro(s) excluído(s) com sucesso!",
                            Result = val,
                            ProcessingTime = ProcessingTime()
                        });
                    case EnumeratorsCommons.DataOperation.Select:
                        if (val == null)
                        {
                            return NotFound(new ResponseMicroService<TResult>
                            {
                                StatusCode = 404,
                                Message = "Nenhum registro encontrado!",
                                Result = val,
                                ProcessingTime = ProcessingTime()
                            });
                        }

                        return Ok(new ResponseMicroService<TResult>
                        {
                            StatusCode = 200,
                            Message = "Registro(s) retornado(s) com sucesso!",
                            Result = val,
                            ProcessingTime = ProcessingTime()
                        });
                    default:
                        return BadRequest(new ResponseMicroService<TResult>
                        {
                            StatusCode = 400,
                            Message = "Selecione a operação desejada!",
                            Result = val,
                            ProcessingTime = ProcessingTime()
                        });
                }
            }
            catch (Exception ex)
            {
                string result2 = null;
                return StatusCode(500, new ResponseMicroService<string>
                {
                    StatusCode = 500,
                    Result = result2,
                    Message = ex.Message
                });
            }
        }

        [NonAction]
        public async Task<ActionResult> ResolveResponse(Task result, EnumeratorsCommons.DataOperation operation)
        {
            try
            {
                await result;
                switch (operation)
                {
                    case EnumeratorsCommons.DataOperation.Insert:
                        return Created("", new ResponseMicroService<bool>
                        {
                            StatusCode = 200,
                            Message = "Registro(s) inserido(s) com sucesso!",
                            Result = result.IsCompletedSuccessfully,
                            ProcessingTime = ProcessingTime()
                        });
                    case EnumeratorsCommons.DataOperation.Update:
                        return Ok(new ResponseMicroService<bool>
                        {
                            StatusCode = 200,
                            Message = "Registro(s) atualizado(s) com sucesso!",
                            Result = result.IsCompletedSuccessfully,
                            ProcessingTime = ProcessingTime()
                        });
                    case EnumeratorsCommons.DataOperation.Delete:
                        if (result == null)
                        {
                            return NoContent();
                        }

                        return Ok(new ResponseMicroService<bool>
                        {
                            StatusCode = 200,
                            Message = "Registro(s) excluído(s) com sucesso!",
                            Result = result.IsCompletedSuccessfully,
                            ProcessingTime = ProcessingTime()
                        });
                    case EnumeratorsCommons.DataOperation.Select:
                        if (result == null)
                        {
                            return NotFound(new ResponseMicroService<bool>
                            {
                                StatusCode = 404,
                                Message = "Nenhum registro encontrado!",
                                Result = result.IsCompletedSuccessfully,
                                ProcessingTime = ProcessingTime()
                            });
                        }

                        return Ok(new ResponseMicroService<bool>
                        {
                            StatusCode = 200,
                            Message = "Registro(s) retornado(s) com sucesso!",
                            Result = result.IsCompletedSuccessfully,
                            ProcessingTime = ProcessingTime()
                        });
                    default:
                        return BadRequest(new ResponseMicroService<bool>
                        {
                            StatusCode = 400,
                            Message = "Selecione a operação desejada!",
                            Result = result.IsCompletedSuccessfully,
                            ProcessingTime = ProcessingTime()
                        });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseMicroService<string>
                {
                    StatusCode = 500,
                    Result = string.Empty,
                    Message = ex.Message,
                    ProcessingTime = ProcessingTime()
                });
            }
        }

        [NonAction]
        private string ProcessingTime()
        {
            _stopwatch.Stop();
            return $"{TimeSpan.FromMilliseconds(_stopwatch.ElapsedMilliseconds).Seconds} segundos e {TimeSpan.FromMilliseconds(_stopwatch.ElapsedMilliseconds).Milliseconds} milessegundos";
        }
    }
}
